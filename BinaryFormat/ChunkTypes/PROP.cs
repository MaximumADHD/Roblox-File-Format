using System;
using System.Linq;

using Roblox.Enums;
using Roblox.DataTypes;
using Roblox.DataTypes.Utility;

namespace Roblox.BinaryFormat.Chunks
{
    public class PROP
    {
        public static void ReadProperties(RobloxBinaryFile file, RobloxBinaryChunk chunk)
        {
            RobloxBinaryReader reader = chunk.GetReader("PROP");

            // Read the property's header info.
            int typeIndex = reader.ReadInt32();
            string name = reader.ReadString();
            PropertyType propType;

            try
            {
                byte typeId = reader.ReadByte();
                propType = (PropertyType)typeId;
            }
            catch
            {
                propType = PropertyType.Unknown;
            }

            // Create access arrays for the objects we will be adding properties to.
            INST type = file.Types[typeIndex];
            Property[] props = new Property[type.NumInstances];

            int[] ids = type.InstanceIds;
            int instCount = type.NumInstances;

            for (int i = 0; i < instCount; i++)
            {
                int instId = ids[i];

                Property prop = new Property();
                prop.Name = name;
                prop.Type = propType;
                props[i] = prop;
                
                Instance inst = file.Instances[instId];
                inst.AddProperty(ref prop);
            }

            // Setup some short-hand functions for actions frequently used during the read procedure.
            var loadProperties = new Action<Func<int, object>>(read =>
            {
                for (int i = 0; i < instCount; i++)
                {
                    object result = read(i);
                    props[i].Value = result;
                }
            });

            var readInts = new Func<int[]>(() => reader.ReadInts(instCount));
            var readFloats = new Func<float[]>(() => reader.ReadFloats(instCount));
            
            // Read the property data based on the property type.
            switch (propType)
            {
                case PropertyType.String:
                    loadProperties(i =>
                    {
                        string result = reader.ReadString();

                        // Leave an access point for the original byte sequence, in case this is a BinaryString.
                        // This will allow the developer to read the sequence without any mangling from C# strings.
                        byte[] buffer = reader.GetLastStringBuffer();
                        props[i].SetRawBuffer(buffer);

                        return result;
                    });

                    break;
                case PropertyType.Bool:
                    loadProperties(i => reader.ReadBoolean());
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
                    loadProperties(i => reader.ReadDouble());
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
                    int[] brickColors = readInts();

                    loadProperties(i =>
                    {
                        int number = brickColors[i];
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
                    float[] vector2_X = readFloats(),
                            vector2_Y = readFloats();

                    loadProperties(i =>
                    {
                        float x = vector2_X[i],
                              y = vector2_Y[i];

                        return new Vector2(x, y);
                    });

                    break;
                case PropertyType.Vector3:
                    float[] vector3_X = readFloats(),
                            vector3_Y = readFloats(),
                            vector3_Z = readFloats();

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
                        int normXY = reader.ReadByte();

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
                        else if (propType == PropertyType.Quaternion)
                        {
                            float qx = reader.ReadFloat(), qy = reader.ReadFloat(),
                                  qz = reader.ReadFloat(), qw = reader.ReadFloat();

                            Quaternion quat = new Quaternion(qx, qy, qz, qw);
                            var rotation = quat.ToCFrame();

                            return rotation.GetComponents();
                        }
                        else
                        {
                            float[] matrix = new float[9];

                            for (int m = 0; m < 9; m++)
                            {
                                float value = reader.ReadFloat();
                                matrix[m] = value;
                            }

                            return matrix;
                        }
                    });

                    float[] cframe_X = readFloats(),
                            cframe_Y = readFloats(),
                            cframe_Z = readFloats();

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
                    // TODO: I want to map these values to actual Roblox enums, but I'll have to add an
                    //       interpreter for the JSON API Dump to do it properly.

                    uint[] enums = reader.ReadInterlaced(instCount, BitConverter.ToUInt32);
                    loadProperties(i => enums[i]);

                    break;
                case PropertyType.Ref:
                    int[] instIds = reader.ReadInstanceIds(instCount);

                    loadProperties(i =>
                    {
                        int instId = instIds[i];
                        return instId >= 0 ? file.Instances[instId] : null;
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
                        int numKeys = reader.ReadInt32();
                        var keypoints = new NumberSequenceKeypoint[numKeys];

                        for (int key = 0; key < numKeys; key++)
                        {
                            float Time = reader.ReadFloat(),
                                  Value = reader.ReadFloat(),
                                  Envelope = reader.ReadFloat();

                            keypoints[key] = new NumberSequenceKeypoint(Time, Value, Envelope);
                        }

                        return new NumberSequence(keypoints);
                    });

                    break;
                case PropertyType.ColorSequence:
                    loadProperties(i =>
                    {
                        int numKeys = reader.ReadInt32();
                        var keypoints = new ColorSequenceKeypoint[numKeys];

                        for (int key = 0; key < numKeys; key++)
                        {
                            float Time = reader.ReadFloat(),
                                  R = reader.ReadFloat(),
                                  G = reader.ReadFloat(),
                                  B = reader.ReadFloat();

                            Color3 Color = new Color3(R, G, B);
                            keypoints[key] = new ColorSequenceKeypoint(Time, Color);

                            // ColorSequenceKeypoint has an unused `Envelope` float which has to be read.
                            // Roblox Studio writes it because it does an std::memcpy call to the C++ type.
                            // If we skip it, the stream will become misaligned.
                            reader.ReadBytes(4);
                        }

                        return new ColorSequence(keypoints);
                    });

                    break;
                case PropertyType.NumberRange:
                    loadProperties(i =>
                    {
                        float min = reader.ReadFloat();
                        float max = reader.ReadFloat();

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
                        bool custom = reader.ReadBoolean();
                        
                        if (custom)
                        {
                            float Density = reader.ReadFloat(),
                                  Friction = reader.ReadFloat(),
                                  Elasticity = reader.ReadFloat(),
                                  FrictionWeight = reader.ReadFloat(),
                                  ElasticityWeight = reader.ReadFloat();

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
                    long[] int64s = reader.ReadInterlaced(instCount, (buffer, start) =>
                    {
                        long result = BitConverter.ToInt64(buffer, start);
                        return (long)((ulong)result >> 1) ^ (-(result & 1));
                    });

                    loadProperties(i => int64s[i]);
                    break;
            }

            reader.Dispose();
        }
    }
}
