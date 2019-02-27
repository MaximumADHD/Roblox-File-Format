using System;
using System.Linq;

using RobloxFiles.Enums;
using RobloxFiles.DataTypes;
using RobloxFiles.DataTypes.Utility;

namespace RobloxFiles.BinaryFormat.Chunks
{
    public class PROP
    {
        public readonly string Name;
        public readonly int TypeIndex;
        public readonly PropertyType Type;

        private BinaryRobloxReader Reader;

        public PROP(BinaryRobloxChunk chunk)
        {
            Reader = chunk.GetReader("PROP");

            TypeIndex = Reader.ReadInt32();
            Name = Reader.ReadString();

            try
            {
                byte propType = Reader.ReadByte();
                Type = (PropertyType)propType;
            }
            catch
            {
                Type = PropertyType.Unknown;
            }
        }

        public void ReadProperties(BinaryRobloxFile file)
        {
            INST type = file.Types[TypeIndex];
            Property[] props = new Property[type.NumInstances];

            int[] ids = type.InstanceIds;
            int instCount = type.NumInstances;

            for (int i = 0; i < instCount; i++)
            {
                int id = ids[i];
                Instance instance = file.Instances[id];

                Property prop = new Property();
                prop.Name = Name;
                prop.Type = Type;
                prop.Instance = instance;

                props[i] = prop;
                instance.AddProperty(ref prop);
            }

            // Setup some short-hand functions for actions frequently used during the read procedure.
            var readInts = new Func<int[]>(() => Reader.ReadInts(instCount));
            var readFloats = new Func<float[]>(() => Reader.ReadFloats(instCount));
            
            var loadProperties = new Action<Func<int, object>>(read =>
            {
                for (int i = 0; i < instCount; i++)
                {
                    object result = read(i);
                    props[i].Value = result;
                }
            });
            
            // Read the property data based on the property type.
            switch (Type)
            {
                case PropertyType.String:
                    loadProperties(i =>
                    {
                        string result = Reader.ReadString();

                        // Leave an access point for the original byte sequence, in case this is a BinaryString.
                        // This will allow the developer to read the sequence without any mangling from C# strings.
                        byte[] buffer = Reader.GetLastStringBuffer();
                        props[i].SetRawBuffer(buffer);

                        return result;
                    });

                    break;
                case PropertyType.Bool:
                    loadProperties(i => Reader.ReadBoolean());
                    break;
                case PropertyType.Int:
                    int[] ints = readInts();
                    loadProperties(i => ints[i]);
                    break;
                case PropertyType.Float:
                    float[] floats = readFloats();
                    loadProperties(i => floats[i]);
                    break;
                case PropertyType.Double:
                    loadProperties(i => Reader.ReadDouble());
                    break;
                case PropertyType.UDim:
                    float[] UDim_Scales = readFloats();
                    int[] UDim_Offsets = readInts();

                    loadProperties(i =>
                    {
                        float scale = UDim_Scales[i];
                        int offset = UDim_Offsets[i];
                        return new UDim(scale, offset);
                    });

                    break;
                case PropertyType.UDim2:
                    float[] UDim2_Scales_X = readFloats(), 
                            UDim2_Scales_Y = readFloats();

                    int[] UDim2_Offsets_X = readInts(), 
                          UDim2_Offsets_Y = readInts();

                    loadProperties(i =>
                    {
                        float scaleX = UDim2_Scales_X[i],
                              scaleY = UDim2_Scales_Y[i];

                        int offsetX = UDim2_Offsets_X[i],
                            offsetY = UDim2_Offsets_Y[i];

                        return new UDim2(scaleX, offsetX, scaleY, offsetY);
                    });

                    break;
                case PropertyType.Ray:
                    loadProperties(i =>
                    {
                        float[] rawOrigin = Reader.ReadFloats(3);
                        Vector3 origin = new Vector3(rawOrigin);

                        float[] rawDirection = Reader.ReadFloats(3);
                        Vector3 direction = new Vector3(rawDirection);

                        return new Ray(origin, direction);
                    });

                    break;
                case PropertyType.Faces:
                    loadProperties(i =>
                    {
                        byte faces = Reader.ReadByte();
                        return (Faces)faces;
                    });

                    break;
                case PropertyType.Axes:
                    loadProperties(i =>
                    {
                        byte axes = Reader.ReadByte();
                        return (Axes)axes;
                    });

                    break;
                case PropertyType.BrickColor:
                    int[] BrickColorIds = readInts();

                    loadProperties(i =>
                    {
                        int number = BrickColorIds[i];
                        return BrickColor.FromNumber(number);
                    });

                    break;
                case PropertyType.Color3:
                    float[] color3_R = readFloats(),
                            color3_G = readFloats(),
                            color3_B = readFloats();

                    loadProperties(i =>
                    {
                        float r = color3_R[i],
                              g = color3_G[i],
                              b = color3_B[i];

                        return new Color3(r, g, b);
                    });

                    break;
                case PropertyType.Vector2:
                    float[] Vector2_X = readFloats(),
                            Vector2_Y = readFloats();

                    loadProperties(i =>
                    {
                        float x = Vector2_X[i],
                              y = Vector2_Y[i];

                        return new Vector2(x, y);
                    });

                    break;
                case PropertyType.Vector3:
                    float[] Vector3_X = readFloats(),
                            Vector3_Y = readFloats(),
                            Vector3_Z = readFloats();

                    loadProperties(i =>
                    {
                        float x = Vector3_X[i],
                              y = Vector3_Y[i],
                              z = Vector3_Z[i];

                        return new Vector3(x, y, z);
                    });

                    break;
                case PropertyType.CFrame:
                case PropertyType.Quaternion:
                    // Temporarily load the rotation matrices into their properties.
                    // We'll update them to CFrames once we iterate over the position data.

                    loadProperties(i =>
                    {
                        int normXY = Reader.ReadByte();

                        if (normXY > 0)
                        {
                            // Make sure this value is in a safe range.
                            normXY = (normXY - 1) % 36;

                            NormalId normX = (NormalId)(normXY / 6);
                            Vector3 R0 = Vector3.FromNormalId(normX);

                            NormalId normY = (NormalId)(normXY % 6);
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
                            float qx = Reader.ReadFloat(), qy = Reader.ReadFloat(),
                                  qz = Reader.ReadFloat(), qw = Reader.ReadFloat();

                            Quaternion quaternion = new Quaternion(qx, qy, qz, qw);
                            var rotation = quaternion.ToCFrame();

                            return rotation.GetComponents();
                        }
                        else
                        {
                            float[] matrix = new float[9];

                            for (int m = 0; m < 9; m++)
                            {
                                float value = Reader.ReadFloat();
                                matrix[m] = value;
                            }

                            return matrix;
                        }
                    });

                    float[] CFrame_X = readFloats(),
                            CFrame_Y = readFloats(),
                            CFrame_Z = readFloats();

                    loadProperties(i =>
                    {
                        float[] matrix = props[i].Value as float[];

                        float x = CFrame_X[i],
                              y = CFrame_Y[i],
                              z = CFrame_Z[i];

                        float[] position = new float[3] { x, y, z };
                        float[] components = position.Concat(matrix).ToArray();

                        return new CFrame(components);
                    });

                    break;
                case PropertyType.Enum:
                    // TODO: I want to map these values to actual Roblox enums, but I'll have to add an
                    //       interpreter for the JSON API Dump to do it properly.

                    uint[] enums = Reader.ReadInterleaved(instCount, BitConverter.ToUInt32);
                    loadProperties(i => enums[i]);

                    break;
                case PropertyType.Ref:
                    int[] instIds = Reader.ReadInstanceIds(instCount);

                    loadProperties(i =>
                    {
                        int instId = instIds[i];
                        return instId >= 0 ? file.Instances[instId] : null;
                    });

                    break;
                case PropertyType.Vector3int16:
                    loadProperties(i =>
                    {
                        short x = Reader.ReadInt16(),
                              y = Reader.ReadInt16(),
                              z = Reader.ReadInt16();

                        return new Vector3int16(x, y, z);
                    });

                    break;
                case PropertyType.NumberSequence:
                    loadProperties(i =>
                    {
                        int numKeys = Reader.ReadInt32();
                        var keypoints = new NumberSequenceKeypoint[numKeys];

                        for (int key = 0; key < numKeys; key++)
                        {
                            float Time = Reader.ReadFloat(),
                                  Value = Reader.ReadFloat(),
                                  Envelope = Reader.ReadFloat();

                            keypoints[key] = new NumberSequenceKeypoint(Time, Value, Envelope);
                        }

                        return new NumberSequence(keypoints);
                    });

                    break;
                case PropertyType.ColorSequence:
                    loadProperties(i =>
                    {
                        int numKeys = Reader.ReadInt32();
                        var keypoints = new ColorSequenceKeypoint[numKeys];

                        for (int key = 0; key < numKeys; key++)
                        {
                            float Time = Reader.ReadFloat(),
                                     R = Reader.ReadFloat(),
                                     G = Reader.ReadFloat(),
                                     B = Reader.ReadFloat();

                            Color3 Value = new Color3(R, G, B);
                            byte[] Reserved = Reader.ReadBytes(4);

                            keypoints[key] = new ColorSequenceKeypoint(Time, Value, Reserved);
                        }

                        return new ColorSequence(keypoints);
                    });

                    break;
                case PropertyType.NumberRange:
                    loadProperties(i =>
                    {
                        float min = Reader.ReadFloat();
                        float max = Reader.ReadFloat();

                        return new NumberRange(min, max);
                    });

                    break;
                case PropertyType.Rect:
                    float[] Rect_X0 = readFloats(), Rect_Y0 = readFloats(),
                            Rect_X1 = readFloats(), Rect_Y1 = readFloats();

                    loadProperties(i =>
                    {
                        float x0 = Rect_X0[i], y0 = Rect_Y0[i],
                              x1 = Rect_X1[i], y1 = Rect_Y1[i];

                        return new Rect(x0, y0, x1, y1);
                    });

                    break;
                case PropertyType.PhysicalProperties:
                    loadProperties(i =>
                    {
                        bool custom = Reader.ReadBoolean();
                        
                        if (custom)
                        {
                            float Density = Reader.ReadFloat(),
                                  Friction = Reader.ReadFloat(),
                                  Elasticity = Reader.ReadFloat(),
                                  FrictionWeight = Reader.ReadFloat(),
                                  ElasticityWeight = Reader.ReadFloat();

                            return new PhysicalProperties
                            (
                                Density,
                                Friction,
                                Elasticity,
                                FrictionWeight,
                                ElasticityWeight
                            );
                        }

                        return null;
                    });

                    break;
                case PropertyType.Color3uint8:
                    byte[] Color3uint8_R = Reader.ReadBytes(instCount),
                           Color3uint8_G = Reader.ReadBytes(instCount),
                           Color3uint8_B = Reader.ReadBytes(instCount);
                    
                    loadProperties(i =>
                    {
                        byte r = Color3uint8_R[i],
                             g = Color3uint8_G[i],
                             b = Color3uint8_B[i];

                        return Color3.FromRGB(r, g, b);
                    });

                    break;
                case PropertyType.Int64:
                    long[] int64s = Reader.ReadInterleaved(instCount, (buffer, start) =>
                    {
                        long result = BitConverter.ToInt64(buffer, start);
                        return (long)((ulong)result >> 1) ^ (-(result & 1));
                    });

                    loadProperties(i => int64s[i]);
                    break;
            }

            Reader.Dispose();
        }
    }
}
