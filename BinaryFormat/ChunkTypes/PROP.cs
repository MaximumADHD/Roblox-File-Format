using System;
using System.IO;
using System.Linq;

using Roblox.Enums;
using Roblox.DataTypes;
using Roblox.DataTypes.Utility;

namespace Roblox.BinaryFormat.Chunks
{
    public class PROP
    {
        public int Index { get; private set; }
        public string Name { get; private set; }

        public readonly PropertyType Type;
        public RobloxProperty[] Properties => props;

        private RobloxBinaryReader reader;
        private RobloxProperty[] props;

        public override string ToString()
        {
            Type PropertyType = typeof(PropertyType);
            return '[' + Enum.GetName(PropertyType, Type) + "] " + Name;
        }

        public PROP(RobloxBinaryChunk chunk)
        {
            reader = chunk.GetReader("PROP");

            Index = reader.ReadInt32();
            Name = reader.ReadString();

            try
            {
                byte propType = reader.ReadByte();
                Type = (PropertyType)propType;
            }
            catch
            {
                Type = PropertyType.Unknown;
            }
        }

        public void ReadPropertyValues(INST instChunk, RobloxInstance[] instMap)
        {
            int[] ids = instChunk.InstanceIds;
            int instCount = ids.Length;

            props = new RobloxProperty[instCount];

            for (int i = 0; i < instCount; i++)
            {
                RobloxProperty prop = new RobloxProperty();
                prop.Name = Name;
                prop.Type = Type;

                Properties[i] = prop;
                instMap[ids[i]].Properties.Add(prop);
            }

            // Setup some short-hand functions for frequently used actions.
            var readInstanceInts = new Func<int[]>(() => reader.ReadInts(instCount));
            var readInstanceFloats = new Func<float[]>(() => reader.ReadFloats(instCount));

            var loadProperties = new Action<Func<int, object>>(read =>
            {
                for (int i = 0; i < instCount; i++)
                {
                    object result = read(i);
                    props[i].Value = result;
                }
            });

            // Process the property data based on the property type.
            switch (Type)
            {
                case PropertyType.String:
                    loadProperties(i => reader.ReadString());
                    break;
                case PropertyType.Bool:
                    loadProperties(i => reader.ReadBoolean());
                    break;
                case PropertyType.Int:
                    int[] ints = readInstanceInts();
                    loadProperties(i => ints[i]);
                    break;
                case PropertyType.Float:
                    float[] floats = readInstanceFloats();
                    loadProperties(i => floats[i]);
                    break;
                case PropertyType.Double:
                    loadProperties(i => reader.ReadDouble());
                    break;
                case PropertyType.UDim:
                    float[] scales = readInstanceFloats();
                    int[] offsets = readInstanceInts();

                    loadProperties(i =>
                    {
                        float scale = scales[i];
                        int offset = offsets[i];
                        return new UDim(scale, offset);
                    });

                    break;
                case PropertyType.UDim2:
                    float[] scalesX = readInstanceFloats(), scalesY = readInstanceFloats();
                    int[] offsetsX = readInstanceInts(), offsetsY = readInstanceInts();

                    loadProperties(i =>
                    {
                        float scaleX = scalesX[i], scaleY = scalesY[i];
                        int offsetX = offsetsX[i], offsetY = offsetsY[i];
                        return new UDim2(scaleX, offsetX, scaleY, offsetY);
                    });

                    break;
                case PropertyType.Ray:
                    loadProperties(i =>
                    {
                        float[] rawOrigin = reader.ReadFloats(3);
                        Vector3 origin = new Vector3(rawOrigin);

                        float[] rawDirection = reader.ReadFloats(3);
                        Vector3 direction = new Vector3(rawDirection);

                        return new Ray(origin, direction);
                    });

                    break;
                case PropertyType.Faces:
                    loadProperties(i =>
                    {
                        byte faces = reader.ReadByte();
                        return (Faces)faces;
                    });

                    break;
                case PropertyType.Axes:
                    loadProperties(i =>
                    {
                        byte axes = reader.ReadByte();
                        return (Axes)axes;
                    });

                    break;
                case PropertyType.BrickColor:
                    int[] brickColors = readInstanceInts();

                    loadProperties(i =>
                    {
                        int number = brickColors[i];
                        return BrickColor.New(number);
                    });

                    break;
                case PropertyType.Color3:
                    float[] color3_R = readInstanceFloats(),
                            color3_G = readInstanceFloats(),
                            color3_B = readInstanceFloats();

                    loadProperties(i =>
                    {
                        float r = color3_R[i],
                              g = color3_G[i],
                              b = color3_B[i];

                        return new Color3(r, g, b);
                    });

                    break;
                case PropertyType.Vector2:
                    float[] vector2_X = readInstanceFloats(),
                            vector2_Y = readInstanceFloats();

                    loadProperties(i =>
                    {
                        float x = vector2_X[i],
                              y = vector2_Y[i];

                        return new Vector2(x, y);
                    });

                    break;
                case PropertyType.Vector3:
                    float[] vector3_X = readInstanceFloats(),
                            vector3_Y = readInstanceFloats(),
                            vector3_Z = readInstanceFloats();

                    loadProperties(i =>
                    {
                        float x = vector3_X[i],
                              y = vector3_Y[i],
                              z = vector3_Z[i];

                        return new Vector3(x, y, z);
                    });

                    break;
                case PropertyType.CFrame:
                case PropertyType.Quaternion:
                    // Temporarily load the rotation matrices into their properties.
                    // We'll update them to CFrames once we iterate over the position data.

                    loadProperties(i =>
                    {
                        byte orientId = reader.ReadByte();

                        if (orientId > 0)
                        {
                            NormalId normX = (NormalId)((orientId - 1) / 6);
                            Vector3 R0 = Vector3.FromNormalId(normX);

                            NormalId normY = (NormalId)((orientId - 1) % 6);
                            Vector3 R1 = Vector3.FromNormalId(normY);

                            // Compute R2 using the cross product of R0 and R1.
                            Vector3 R2 = R0.Cross(R1);

                            // Generate the rotation matrix and return it.
                            return new float[9]
                            {
                                R0.X, R0.Y, R0.Z,
                                R1.X, R1.Y, R1.Z,
                                R2.X, R2.Y, R2.Z,
                            };
                        }
                        else if (Type == PropertyType.Quaternion)
                        {
                            float qx = reader.ReadSingle(),
                                  qy = reader.ReadSingle(),
                                  qz = reader.ReadSingle(),
                                  qw = reader.ReadSingle();

                            Quaternion quat = new Quaternion(qx, qy, qz, qw);
                            var rotation = quat.ToCFrame();

                            return rotation.GetComponents();
                        }
                        else
                        {
                            float[] matrix = new float[9];

                            for (int m = 0; m < 9; m++)
                            {
                                float value = reader.ReadSingle();
                                matrix[m] = value;
                            }

                            return matrix;
                        }
                    });

                    float[] cframe_X = readInstanceFloats(),
                            cframe_Y = readInstanceFloats(),
                            cframe_Z = readInstanceFloats();

                    loadProperties(i =>
                    {
                        float[] matrix = props[i].Value as float[];

                        float x = cframe_X[i],
                              y = cframe_Y[i],
                              z = cframe_Z[i];

                        float[] position = new float[3] { x, y, z };
                        float[] components = position.Concat(matrix).ToArray();

                        return new CFrame(components);
                    });

                    break;
                case PropertyType.Enum:
                    uint[] enums = reader.ReadInterwovenValues(instCount, BitConverter.ToUInt32);
                    loadProperties(i => enums[i]);
                    break;
                case PropertyType.Ref:
                    int[] instIds = reader.ReadInstanceIds(instCount);

                    loadProperties(i =>
                    {
                        int instId = instIds[i];
                        return instId >= 0 ? instMap[instId] : null;
                    });

                    break;
                case PropertyType.Vector3int16:
                    loadProperties(i =>
                    {
                        short x = reader.ReadInt16(),
                              y = reader.ReadInt16(),
                              z = reader.ReadInt16();

                        return new Vector3int16(x, y, z);
                    });

                    break;
                case PropertyType.NumberSequence:
                    loadProperties(i =>
                    {
                        int keys = reader.ReadInt32();
                        var keypoints = new NumberSequenceKeypoint[keys];

                        for (int key = 0; key < keys; key++)
                        {
                            float time = reader.ReadSingle(),
                                  value = reader.ReadSingle(),
                                  envelope = reader.ReadSingle();

                            keypoints[key] = new NumberSequenceKeypoint(time, value, envelope);
                        }

                        return new NumberSequence(keypoints);
                    });

                    break;
                case PropertyType.ColorSequence:
                    loadProperties(i =>
                    {
                        int keys = reader.ReadInt32();
                        var keypoints = new ColorSequenceKeypoint[keys];

                        for (int key = 0; key < keys; key++)
                        {
                            float time = reader.ReadSingle(),
                                  R = reader.ReadSingle(),
                                  G = reader.ReadSingle(),
                                  B = reader.ReadSingle(),
                                  envelope = reader.ReadSingle(); // unused, but still written

                            keypoints[key] = new ColorSequenceKeypoint(time, new Color3(R, G, B));
                        }

                        return new ColorSequence(keypoints);
                    });

                    break;
                case PropertyType.NumberRange:
                    loadProperties(i =>
                    {
                        float min = reader.ReadSingle();
                        float max = reader.ReadSingle();

                        return new NumberRange(min, max);
                    });

                    break;
                case PropertyType.Rect:
                    float[] Rect_X0 = readInstanceFloats(),
                            Rect_Y0 = readInstanceFloats(),
                            Rect_X1 = readInstanceFloats(),
                            Rect_Y1 = readInstanceFloats();

                    loadProperties(i =>
                    {
                        float x0 = Rect_X0[i],
                              y0 = Rect_Y0[i],
                              x1 = Rect_X1[i],
                              y1 = Rect_Y1[i];

                        return new Rect(x0, y0, x1, y1);
                    });

                    break;
                case PropertyType.PhysicalProperties:
                    loadProperties(i =>
                    {
                        bool custom = reader.ReadBoolean();
                        
                        if (custom)
                        {
                            float density = reader.ReadSingle(),
                                  friction = reader.ReadSingle(),
                                  elasticity = reader.ReadSingle(),
                                  frictionWeight = reader.ReadSingle(),
                                  elasticityWeight = reader.ReadSingle();

                            return new PhysicalProperties
                            (
                                density,
                                friction,
                                elasticity,
                                frictionWeight, 
                                elasticityWeight
                            );
                        }

                        return null;
                    });

                    break;
                case PropertyType.Color3uint8:
                    byte[] color3uint8_R = reader.ReadBytes(instCount),
                           color3uint8_G = reader.ReadBytes(instCount),
                           color3uint8_B = reader.ReadBytes(instCount);
                    
                    loadProperties(i =>
                    {
                        byte r = color3uint8_R[i],
                             g = color3uint8_G[i],
                             b = color3uint8_B[i];

                        return Color3.fromRGB(r, g, b);
                    });

                    break;
                case PropertyType.Int64:
                    long[] int64s = reader.ReadInterwovenValues(instCount, (buffer, start) =>
                    {
                        long result = BitConverter.ToInt64(buffer, start);
                        return (long)((ulong)result >> 1) ^ (-(result & 1));
                    });

                    loadProperties(i => int64s[i]);
                    break;
                
            }
        }
    }
}