﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RobloxFiles.Enums;
using RobloxFiles.DataTypes;
using RobloxFiles.Utility;
using System.IO;

namespace RobloxFiles.BinaryFormat.Chunks
{
    public class PROP : IBinaryFileChunk
    {
        private BinaryRobloxFile File;
        
        public string Name { get; internal set; }
        public int ClassIndex { get; internal set; }

        private INST Class => File.Classes[ClassIndex];
        public string ClassName => Class?.ClassName;

        public PropertyType Type { get; internal set; }

        internal byte TypeId
        {
            get { return (byte)Type; }
            set { Type = (PropertyType)value; }
        }

        public override string ToString()
        {
            return $"{Type} {ClassName}.{Name}";
        }

        public void Load(BinaryRobloxFileReader reader)
        {
            File = reader.File;
            ClassIndex = reader.ReadInt32();
            Name = reader.ReadString();
            
            try
            {
                byte propType = reader.ReadByte();
                Type = (PropertyType)propType;
            }
            catch (EndOfStreamException)
            {
                RobloxFile.LogError($"Got corrupted PROP chunk (@ {this})!");
                return;
            }

            if (Class == null)
            {
                RobloxFile.LogError($"Unknown class index {ClassIndex} (@ {this})!");
                return;
            }

            var ids = Class.InstanceIds;
            int instCount = Class.NumInstances;
            var props = new Property[instCount];

            for (int i = 0; i < instCount; i++)
            {
                int id = ids[i];
                Instance instance = File.Instances[id];

                if (instance == null)
                {
                    RobloxFile.LogError($"PROP: No instance @{id} for property {ClassName}.{Name}");
                    continue;
                }

                var prop = new Property(instance, this);
                props[i] = prop;

                instance.AddProperty(ref prop);
            }

            // Setup some short-hand functions for actions used during the read procedure.
            var readInts = new Func<int[]>(() => reader.ReadInterleaved(instCount, reader.RotateInt32));
            var readFloats = new Func<float[]>(() => reader.ReadInterleaved(instCount, reader.RotateFloat));
            
            var readProperties = new Action<Func<int, object>>(read =>
            {
                for (int i = 0; i < instCount; i++)
                {
                    var prop = props[i];

                    if (prop == null)
                        continue;

                    prop.Value = read(i);
                }
            });
            
            switch (Type)
            {
                case PropertyType.String:
                {
                    readProperties(i =>
                    {
                        string value = reader.ReadString();

                        // Leave an access point for the original byte sequence, in case this is a BinaryString.
                        // This will allow the developer to read the sequence without any mangling from C# strings.
                        byte[] buffer = reader.GetLastStringBuffer();
                        props[i].RawBuffer = buffer;

                        // Check if this is going to be casted as a BinaryString.
                        // BinaryStrings should use a type of byte[] instead.

                        switch (Name)
                        {
                            case "Tags":
                            case "AttributesSerialize":
                            {
                                return buffer;
                            }
                            default:
                            {
                                Property prop = props[i];
                                Instance instance = prop.Instance;

                                Type instType = instance.GetType();
                                var member = ImplicitMember.Get(instType, Name);

                                if (member != null)
                                {
                                    object result = value;
                                    Type memberType = member.MemberType;

                                    if (memberType == typeof(byte[]))
                                        result = buffer;

                                    return result;
                                }

                                return value;
                            }
                        }
                    });

                    break;
                }
                case PropertyType.Bool:
                {
                    readProperties(i => reader.ReadBoolean());
                    break;
                }
                case PropertyType.Int:
                {
                    int[] ints = readInts();
                    readProperties(i => ints[i]);
                    break;
                }
                case PropertyType.Float:
                {
                    float[] floats = readFloats();
                    readProperties(i => floats[i]);
                    break;
                }
                case PropertyType.Double:
                {
                    readProperties(i => reader.ReadDouble());
                    break;
                }
                case PropertyType.UDim:
                {
                    float[] UDim_Scales = readFloats();
                    int[] UDim_Offsets = readInts();

                    readProperties(i =>
                    {
                        float scale = UDim_Scales[i];
                        int offset = UDim_Offsets[i];
                        return new UDim(scale, offset);
                    });

                    break;
                }
                case PropertyType.UDim2:
                {
                    float[] UDim2_Scales_X = readFloats(),
                            UDim2_Scales_Y = readFloats();

                    int[] UDim2_Offsets_X = readInts(),
                          UDim2_Offsets_Y = readInts();

                    readProperties(i =>
                    {
                        float scaleX = UDim2_Scales_X[i],
                              scaleY = UDim2_Scales_Y[i];

                        int offsetX = UDim2_Offsets_X[i],
                            offsetY = UDim2_Offsets_Y[i];

                        return new UDim2(scaleX, offsetX, scaleY, offsetY);
                    });

                    break;
                }
                case PropertyType.Ray:
                {
                    readProperties(i =>
                    {
                        float posX = reader.ReadFloat(),
                              posY = reader.ReadFloat(),
                              posZ = reader.ReadFloat();

                        float dirX = reader.ReadFloat(),
                              dirY = reader.ReadFloat(),
                              dirZ = reader.ReadFloat();

                        var origin = new Vector3(posX, posY, posZ);
                        var direction = new Vector3(dirX, dirY, dirZ);

                        return new Ray(origin, direction);
                    });

                    break;
                }
                case PropertyType.Faces:
                {
                    readProperties(i =>
                    {
                        byte faces = reader.ReadByte();
                        return (Faces)faces;
                    });

                    break;
                }
                case PropertyType.Axes:
                {
                    readProperties(i =>
                    {
                        byte axes = reader.ReadByte();
                        return (Axes)axes;
                    });

                    break;
                }
                case PropertyType.BrickColor:
                {
                    int[] BrickColorIds = readInts();

                    readProperties(i =>
                    {
                        BrickColor color = BrickColorIds[i];
                        return color;
                    });

                    break;
                }
                case PropertyType.Color3:
                {
                    float[] Color3_R = readFloats(),
                            Color3_G = readFloats(),
                            Color3_B = readFloats();

                    readProperties(i =>
                    {
                        float r = Color3_R[i],
                              g = Color3_G[i],
                              b = Color3_B[i];

                        return new Color3(r, g, b);
                    });

                    break;
                }
                case PropertyType.Vector2:
                {
                    float[] Vector2_X = readFloats(),
                            Vector2_Y = readFloats();

                    readProperties(i =>
                    {
                        float x = Vector2_X[i],
                              y = Vector2_Y[i];

                        return new Vector2(x, y);
                    });

                    break;
                }
                case PropertyType.Vector3:
                {
                    float[] Vector3_X = readFloats(),
                            Vector3_Y = readFloats(),
                            Vector3_Z = readFloats();

                    readProperties(i =>
                    {
                        float x = Vector3_X[i],
                              y = Vector3_Y[i],
                              z = Vector3_Z[i];

                        return new Vector3(x, y, z);
                    });

                    break;
                }
                case PropertyType.CFrame:
                case PropertyType.Quaternion:
                case PropertyType.OptionalCFrame:
                {
                    float[][] matrices = new float[instCount][];

                    if (Type == PropertyType.OptionalCFrame)
                    {
                        byte cframeType = (byte)PropertyType.CFrame;
                        byte readType = reader.ReadByte();

                        if (readType != cframeType)
                        {
                            RobloxFile.LogError($"Unexpected property type in OptionalCFrame (expected {cframeType}, got {readType})");
                            readProperties(i => null);
                            break;
                        }
                    }
                    
                    for (int i = 0; i < instCount; i++)
                    {
                        byte rawOrientId = reader.ReadByte();
                        
                        if (rawOrientId > 0)
                        {
                            // Make sure this value is in a safe range.
                            int orientId = (rawOrientId - 1) % 36;
                            var cf = CFrame.FromOrientId(orientId);
                            matrices[i] = cf.GetComponents();
                        }
                        else if (Type == PropertyType.Quaternion)
                        {
                            float qx = reader.ReadFloat(),
                                  qy = reader.ReadFloat(),
                                  qz = reader.ReadFloat(),
                                  qw = reader.ReadFloat();

                            var quaternion = new Quaternion(qx, qy, qz, qw);
                            var rotation = quaternion.ToCFrame();

                            matrices[i] = rotation.GetComponents();
                        }
                        else
                        {
                            float[] matrix = new float[9];

                            for (int m = 0; m < 9; m++)
                            {
                                float value = reader.ReadFloat();
                                matrix[m] = value;
                            }

                            matrices[i] = matrix;
                        }
                    }

                    float[] CFrame_X = readFloats(),
                            CFrame_Y = readFloats(),
                            CFrame_Z = readFloats();

                    var CFrames = new CFrame[instCount];

                    for (int i = 0; i < instCount; i++)
                    {
                        float[] matrix = matrices[i];

                        float x = CFrame_X[i],
                              y = CFrame_Y[i],
                              z = CFrame_Z[i];

                        float[] components;

                        if (matrix.Length == 12)
                        {
                            matrix[0] = x;
                            matrix[1] = y;
                            matrix[2] = z;

                            components = matrix;
                        }
                        else
                        {
                            float[] position = new float[3] { x, y, z };
                            components = position.Concat(matrix).ToArray();
                        }

                        CFrames[i] = new CFrame(components);
                    }

                    if (Type == PropertyType.OptionalCFrame)
                    {
                        byte boolType = (byte)PropertyType.Bool;
                        byte readType = reader.ReadByte();

                        if (readType != boolType)
                        {
                            RobloxFile.LogError($"Unexpected property type in OptionalCFrame (expected {boolType}, got {readType})");
                            readProperties(i => null);
                            break;
                        }

                        for (int i = 0; i < instCount; i++)
                        {
                            CFrame cf = CFrames[i];
                            bool archivable = reader.ReadBoolean();

                            if (!archivable)
                                cf = null;
                            
                            CFrames[i] = new Optional<CFrame>(cf);
                        }
                    }

                    readProperties(i => CFrames[i]);
                    break;
                }
                case PropertyType.Enum:
                {
                    uint[] enums = reader.ReadInterleaved(instCount, BitConverter.ToUInt32);

                    readProperties(i =>
                    {
                        Property prop = props[i];
                        Instance instance = prop.Instance;

                        Type instType = instance.GetType();
                        uint value = enums[i];

                        try
                        {
                            var info = ImplicitMember.Get(instType, Name);

                            if (info == null)
                            {
                                RobloxFile.LogError($"Enum cast failed for {ClassName}.{Name} using value {value}!");
                                return value;
                            }

                            return Enum.Parse(info.MemberType, value.ToInvariantString());
                        }
                        catch
                        {
                            RobloxFile.LogError($"Enum cast failed for {ClassName}.{Name} using value {value}!");
                            return value;
                        }
                    });

                    break;
                }
                case PropertyType.Ref:
                {
                    var instIds = reader.ReadInstanceIds(instCount);

                    readProperties(i =>
                    {
                        int instId = instIds[i];

                        if (instId >= File.NumInstances)
                        {
                            RobloxFile.LogError($"Got out of bounds referent index in {ClassName}.{Name}!");
                            return null;
                        }

                        return instId >= 0 ? File.Instances[instId] : null;
                    });

                    break;
                }
                case PropertyType.Vector3int16:
                {
                    readProperties(i =>
                    {
                        short x = reader.ReadInt16(),
                              y = reader.ReadInt16(),
                              z = reader.ReadInt16();

                        return new Vector3int16(x, y, z);
                    });

                    break;
                }
                case PropertyType.NumberSequence:
                {
                    readProperties(i =>
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
                }
                case PropertyType.ColorSequence:
                {
                    readProperties(i =>
                    {
                        int numKeys = reader.ReadInt32();
                        var keypoints = new ColorSequenceKeypoint[numKeys];

                        for (int key = 0; key < numKeys; key++)
                        {
                            float Time = reader.ReadFloat(),
                                     R = reader.ReadFloat(),
                                     G = reader.ReadFloat(),
                                     B = reader.ReadFloat();

                            Color3 Value = new Color3(R, G, B);
                            int Envelope = reader.ReadInt32();

                            keypoints[key] = new ColorSequenceKeypoint(Time, Value, Envelope);
                        }

                        return new ColorSequence(keypoints);
                    });

                    break;
                }
                case PropertyType.NumberRange:
                {
                    readProperties(i =>
                    {
                        float min = reader.ReadFloat();
                        float max = reader.ReadFloat();

                        return new NumberRange(min, max);
                    });

                    break;
                }
                case PropertyType.Rect:
                {
                    float[] Rect_X0 = readFloats(), Rect_Y0 = readFloats(),
                            Rect_X1 = readFloats(), Rect_Y1 = readFloats();

                    readProperties(i =>
                    {
                        float x0 = Rect_X0[i], y0 = Rect_Y0[i],
                              x1 = Rect_X1[i], y1 = Rect_Y1[i];

                        return new Rect(x0, y0, x1, y1);
                    });

                    break;
                }
                case PropertyType.PhysicalProperties:
                {
                    readProperties(i =>
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
                }
                case PropertyType.Color3uint8:
                {
                    byte[] Color3uint8_R = reader.ReadBytes(instCount),
                           Color3uint8_G = reader.ReadBytes(instCount),
                           Color3uint8_B = reader.ReadBytes(instCount);

                    readProperties(i =>
                    {
                        byte r = Color3uint8_R[i],
                             g = Color3uint8_G[i],
                             b = Color3uint8_B[i];

                        Color3uint8 result = Color3.FromRGB(r, g, b);
                        return result;
                    });

                    break;
                }
                case PropertyType.Int64:
                {
                    var values = reader.ReadInterleaved(instCount, reader.RotateInt64);
                    readProperties(i => values[i]);
                    break;
                }
                case PropertyType.SharedString:
                {
                    var keys = reader.ReadInterleaved(instCount, BitConverter.ToUInt32);

                    readProperties(i =>
                    {
                        uint key = keys[i];
                        return File.SharedStrings[key];
                    });

                    break;
                }
                case PropertyType.ProtectedString:
                {
                    readProperties(i =>
                    {
                        int length = reader.ReadInt32();
                        byte[] buffer = reader.ReadBytes(length);

                        return new ProtectedString(buffer);
                    });

                    break;
                }
                case PropertyType.UniqueId:
                {
                    var uniqueIds = reader.ReadInterleaved(instCount, (buffer, offset) =>
                    {
                        var random = reader.RotateInt64(buffer, 0);
                        var time = BitConverter.ToUInt32(buffer, 8);
                        var index = BitConverter.ToUInt32(buffer, 12);

                        return new UniqueId(random, time, index);
                    });

                    readProperties(i => uniqueIds[i]);
                    break;
                }
                case PropertyType.FontFace:
                {
                    readProperties(i =>
                    {
                        string family = reader.ReadString();

                        var weight = (FontWeight)reader.ReadUInt16();
                        var style = (FontStyle)reader.ReadByte();
                        var cachedFaceId = reader.ReadString();

                        return new FontFace(family, weight, style, cachedFaceId);
                    });

                    break;
                }
                default:
                {
                    RobloxFile.LogError($"Unhandled property type: {Type} in {this}!");
                    break;
                }
            }

            reader.Dispose();
        }

        internal static Dictionary<string, PROP> CollectProperties(BinaryRobloxFileWriter writer, INST inst)
        {
            BinaryRobloxFile file = writer.File;
            var propMap = new Dictionary<string, PROP>();

            foreach (int instId in inst.InstanceIds)
            {
                Instance instance = file.Instances[instId];
                var props = instance.RefreshProperties();

                foreach (string propName in props.Keys)
                {
                    if (propName == "Archivable")
                        continue;

                    if (propName.Contains("__"))
                        continue;

                    if (!propMap.ContainsKey(propName))
                    {
                        Property prop = props[propName];

                        PROP propChunk = new PROP()
                        {
                            Name = prop.Name,
                            Type = prop.Type,

                            File = writer.File,
                            ClassIndex = inst.ClassIndex
                        };

                        propMap.Add(propName, propChunk);
                    }
                }
            }

            return propMap;
        }

        public void Save(BinaryRobloxFileWriter writer)
        {
            BinaryRobloxFile file = writer.File;
            File = file;

            INST inst = file.Classes[ClassIndex];
            var props = new List<Property>();

            foreach (int instId in inst.InstanceIds)
            {
                Instance instance = file.Instances[instId];
                var instProps = instance.Properties;

                if (!instProps.TryGetValue(Name, out Property prop))
                    throw new Exception($"Property {Name} must be defined in {instance.GetFullName()}!");
                else if (prop.Type != Type)
                    throw new Exception($"Property {Name} is not using the correct type in {instance.GetFullName()}!");

                props.Add(prop);
            }

            writer.Write(ClassIndex);
            writer.WriteString(Name);
            writer.Write(TypeId);

            switch (Type)
            {
                case PropertyType.String:
                    props.ForEach(prop =>
                    {
                        byte[] buffer = prop.HasRawBuffer ? prop.RawBuffer : null;

                        if (buffer == null)
                        {
                            string value = prop.CastValue<string>();
                            buffer = Encoding.UTF8.GetBytes(value);
                        }

                        writer.Write(buffer.Length);
                        writer.Write(buffer);
                    });

                    break;
                case PropertyType.Bool:
                {
                    props.ForEach(prop =>
                    {
                        bool value = prop.CastValue<bool>();
                        writer.Write(value);
                    });

                    break;
                }
                case PropertyType.Int:
                {
                    var ints = props
                        .Select(prop => prop.CastValue<int>())
                        .ToList();

                    writer.WriteInts(ints);
                    break;
                }
                case PropertyType.Float:
                {
                    var floats = props
                        .Select(prop => prop.CastValue<float>())
                        .ToList();

                    writer.WriteFloats(floats);
                    break;
                }
                case PropertyType.Double:
                {
                    props.ForEach(prop =>
                    {
                        double value = prop.CastValue<double>();
                        writer.Write(BinaryRobloxFileWriter.GetBytes(value));
                    });

                    break;
                }
                case PropertyType.UDim:
                {
                    var UDim_Scales = new List<float>();
                    var UDim_Offsets = new List<int>();

                    props.ForEach(prop =>
                    {
                        UDim value = prop.CastValue<UDim>();
                        UDim_Scales.Add(value.Scale);
                        UDim_Offsets.Add(value.Offset);
                    });

                    writer.WriteFloats(UDim_Scales);
                    writer.WriteInts(UDim_Offsets);

                    break;
                }
                case PropertyType.UDim2:
                {
                    var UDim2_Scales_X = new List<float>();
                    var UDim2_Scales_Y = new List<float>();

                    var UDim2_Offsets_X = new List<int>();
                    var UDim2_Offsets_Y = new List<int>();

                    props.ForEach(prop =>
                    {
                        UDim2 value = prop.CastValue<UDim2>();

                        UDim2_Scales_X.Add(value.X.Scale);
                        UDim2_Scales_Y.Add(value.Y.Scale);

                        UDim2_Offsets_X.Add(value.X.Offset);
                        UDim2_Offsets_Y.Add(value.Y.Offset);
                    });

                    writer.WriteFloats(UDim2_Scales_X);
                    writer.WriteFloats(UDim2_Scales_Y);

                    writer.WriteInts(UDim2_Offsets_X);
                    writer.WriteInts(UDim2_Offsets_Y);

                    break;
                }
                case PropertyType.Ray:
                {
                    props.ForEach(prop =>
                    {
                        Ray ray = prop.CastValue<Ray>();

                        Vector3 pos = ray.Origin;
                        writer.Write(pos.X);
                        writer.Write(pos.Y);
                        writer.Write(pos.Z);

                        Vector3 dir = ray.Direction;
                        writer.Write(dir.X);
                        writer.Write(dir.Y);
                        writer.Write(dir.Z);
                    });

                    break;
                }
                case PropertyType.Faces:
                case PropertyType.Axes:
                {
                    props.ForEach(prop =>
                    {
                        byte value = prop.CastValue<byte>();
                        writer.Write(value);
                    });

                    break;
                }
                case PropertyType.BrickColor:
                {
                    var brickColorIds = props
                        .Select(prop => prop.CastValue<BrickColor>())
                        .Select(value => value.Number)
                        .ToList();

                    writer.WriteInts(brickColorIds);
                    break;
                }
                case PropertyType.Color3:
                {
                    var Color3_R = new List<float>();
                    var Color3_G = new List<float>();
                    var Color3_B = new List<float>();

                    props.ForEach(prop =>
                    {
                        Color3 value = prop.CastValue<Color3>();
                        Color3_R.Add(value.R);
                        Color3_G.Add(value.G);
                        Color3_B.Add(value.B);
                    });

                    writer.WriteFloats(Color3_R);
                    writer.WriteFloats(Color3_G);
                    writer.WriteFloats(Color3_B);

                    break;
                }
                case PropertyType.Vector2:
                {
                    var Vector2_X = new List<float>();
                    var Vector2_Y = new List<float>();

                    props.ForEach(prop =>
                    {
                        Vector2 value = prop.CastValue<Vector2>();
                        Vector2_X.Add(value.X);
                        Vector2_Y.Add(value.Y);
                    });

                    writer.WriteFloats(Vector2_X);
                    writer.WriteFloats(Vector2_Y);

                    break;
                }
                case PropertyType.Vector3:
                {
                    var Vector3_X = new List<float>();
                    var Vector3_Y = new List<float>();
                    var Vector3_Z = new List<float>();

                    props.ForEach(prop =>
                    {
                        Vector3 value = prop.CastValue<Vector3>();
                        Vector3_X.Add(value.X);
                        Vector3_Y.Add(value.Y);
                        Vector3_Z.Add(value.Z);
                    });

                    writer.WriteFloats(Vector3_X);
                    writer.WriteFloats(Vector3_Y);
                    writer.WriteFloats(Vector3_Z);

                    break;
                }
                case PropertyType.CFrame:
                case PropertyType.Quaternion:
                case PropertyType.OptionalCFrame:
                {
                    var CFrame_X = new List<float>();
                    var CFrame_Y = new List<float>();
                    var CFrame_Z = new List<float>();

                    if (Type == PropertyType.OptionalCFrame)
                        writer.Write((byte)PropertyType.CFrame);

                    props.ForEach(prop =>
                    {
                        CFrame value = null;

                        if (prop.Value is Quaternion q)
                            value = q.ToCFrame();
                        else
                            value = prop.CastValue<CFrame>();

                        if (value == null)
                            value = new CFrame();

                        Vector3 pos = value.Position;
                        CFrame_X.Add(pos.X);
                        CFrame_Y.Add(pos.Y);
                        CFrame_Z.Add(pos.Z);

                        int orientId = value.GetOrientId();
                        writer.Write((byte)(orientId + 1));

                        if (orientId == -1)
                        {
                            if (Type == PropertyType.Quaternion)
                            {
                                Quaternion quat = new Quaternion(value);
                                writer.Write(quat.X);
                                writer.Write(quat.Y);
                                writer.Write(quat.Z);
                                writer.Write(quat.W);
                            }
                            else
                            {
                                float[] components = value.GetComponents();

                                for (int i = 3; i < 12; i++)
                                {
                                    float component = components[i];
                                    writer.Write(component);
                                }
                            }
                        }
                    });

                    writer.WriteFloats(CFrame_X);
                    writer.WriteFloats(CFrame_Y);
                    writer.WriteFloats(CFrame_Z);

                    if (Type == PropertyType.OptionalCFrame)
                    {
                        writer.Write((byte)PropertyType.Bool);

                        props.ForEach(prop =>
                        {
                            if (prop.Value is null)
                            {
                                writer.Write(false);
                                return;
                            }

                            if (prop.Value is Optional<CFrame> optional)
                            {
                                writer.Write(optional.HasValue);
                                return;
                            }

                            var cf = prop.Value as CFrame;
                            writer.Write(cf != null);
                        });
                    }

                    break;
                }
                case PropertyType.Enum:
                {
                    var enums = new List<uint>();

                    props.ForEach(prop =>
                    {
                        if (prop.Value is uint raw)
                        {
                            enums.Add(raw);
                            return;
                        }

                        int signed = (int)prop.Value;
                        uint value = (uint)signed;

                        enums.Add(value);
                    });

                    writer.WriteInterleaved(enums);
                    break;
                }
                case PropertyType.Ref:
                {
                    var InstanceIds = new List<int>();

                    props.ForEach(prop =>
                    {
                        int referent = -1;

                        if (prop.Value != null)
                        {
                            Instance value = prop.CastValue<Instance>();

                            if (value.IsDescendantOf(File))
                            {
                                string refValue = value.Referent;
                                int.TryParse(refValue, out referent);
                            }
                        }

                        InstanceIds.Add(referent);
                    });

                    writer.WriteInstanceIds(InstanceIds);
                    break;
                }
                case PropertyType.Vector3int16:
                {
                    props.ForEach(prop =>
                    {
                        Vector3int16 value = prop.CastValue<Vector3int16>();
                        writer.Write(value.X);
                        writer.Write(value.Y);
                        writer.Write(value.Z);
                    });

                    break;
                }
                case PropertyType.NumberSequence:
                {
                    props.ForEach(prop =>
                    {
                        NumberSequence value = prop.CastValue<NumberSequence>();

                        var keyPoints = value.Keypoints;
                        writer.Write(keyPoints.Length);

                        foreach (var keyPoint in keyPoints)
                        {
                            writer.Write(keyPoint.Time);
                            writer.Write(keyPoint.Value);
                            writer.Write(keyPoint.Envelope);
                        }
                    });

                    break;
                }
                case PropertyType.ColorSequence:
                {
                    props.ForEach(prop =>
                    {
                        ColorSequence value = prop.CastValue<ColorSequence>();

                        var keyPoints = value.Keypoints;
                        writer.Write(keyPoints.Length);

                        foreach (var keyPoint in keyPoints)
                        {
                            Color3 color = keyPoint.Value;
                            writer.Write(keyPoint.Time);

                            writer.Write(color.R);
                            writer.Write(color.G);
                            writer.Write(color.B);

                            writer.Write(keyPoint.Envelope);
                        }
                    });

                    break;
                }
                case PropertyType.NumberRange:
                {
                    props.ForEach(prop =>
                    {
                        NumberRange value = prop.CastValue<NumberRange>();
                        writer.Write(value.Min);
                        writer.Write(value.Max);
                    });

                    break;
                }
                case PropertyType.Rect:
                {
                    var Rect_X0 = new List<float>();
                    var Rect_Y0 = new List<float>();

                    var Rect_X1 = new List<float>();
                    var Rect_Y1 = new List<float>();

                    props.ForEach(prop =>
                    {
                        Rect value = prop.CastValue<Rect>();

                        Vector2 min = value.Min;
                        Rect_X0.Add(min.X);
                        Rect_Y0.Add(min.Y);

                        Vector2 max = value.Max;
                        Rect_X1.Add(max.X);
                        Rect_Y1.Add(max.Y);
                    });

                    writer.WriteFloats(Rect_X0);
                    writer.WriteFloats(Rect_Y0);

                    writer.WriteFloats(Rect_X1);
                    writer.WriteFloats(Rect_Y1);

                    break;
                }
                case PropertyType.PhysicalProperties:
                {
                    props.ForEach(prop =>
                    {
                        bool custom = (prop.Value != null);
                        writer.Write(custom);

                        if (custom)
                        {
                            PhysicalProperties value = prop.CastValue<PhysicalProperties>();

                            writer.Write(value.Density);
                            writer.Write(value.Friction);
                            writer.Write(value.Elasticity);

                            writer.Write(value.FrictionWeight);
                            writer.Write(value.ElasticityWeight);
                        }
                    });

                    break;
                }
                case PropertyType.Color3uint8:
                {
                    var Color3uint8_R = new List<byte>();
                    var Color3uint8_G = new List<byte>();
                    var Color3uint8_B = new List<byte>();

                    props.ForEach(prop =>
                    {
                        Color3uint8 value = prop.CastValue<Color3uint8>();
                        Color3uint8_R.Add(value.R);
                        Color3uint8_G.Add(value.G);
                        Color3uint8_B.Add(value.B);
                    });

                    byte[] rBuffer = Color3uint8_R.ToArray();
                    writer.Write(rBuffer);

                    byte[] gBuffer = Color3uint8_G.ToArray();
                    writer.Write(gBuffer);

                    byte[] bBuffer = Color3uint8_B.ToArray();
                    writer.Write(bBuffer);

                    break;
                }
                case PropertyType.Int64:
                {
                    var longs = new List<long>();

                    props.ForEach(prop =>
                    {
                        long value = prop.CastValue<long>();
                        longs.Add(value);
                    });

                    writer.WriteLongs(longs);
                    break;
                }
                case PropertyType.SharedString:
                {
                    var sharedKeys = new List<uint>();
                    SSTR sstr = file.SSTR;

                    if (sstr == null)
                    {
                        sstr = new SSTR();
                        file.SSTR = sstr;
                    }

                    props.ForEach(prop =>
                    {
                        var shared = prop.CastValue<SharedString>();

                        if (shared == null)
                        {
                            byte[] empty = Array.Empty<byte>();
                            shared = SharedString.FromBuffer(empty);
                        }

                        string key = shared.Key;

                        if (!sstr.Lookup.ContainsKey(key))
                        {
                            uint id = (uint)sstr.Lookup.Count;
                            sstr.Strings.Add(id, shared);
                            sstr.Lookup.Add(key, id);
                        }

                        uint hashId = sstr.Lookup[key];
                        sharedKeys.Add(hashId);
                    });

                    writer.WriteInterleaved(sharedKeys);
                    break;
                }
                case PropertyType.ProtectedString:
                {
                    props.ForEach(prop =>
                    {
                        var protect = prop.CastValue<ProtectedString>();
                        byte[] buffer = protect.RawBuffer;

                        writer.Write(buffer.Length);
                        writer.Write(buffer);
                    });

                    break;
                }
                case PropertyType.UniqueId:
                {
                    var uniqueIds = new List<UniqueId>();

                    props.ForEach(prop =>
                    {
                        var uniqueId = prop.CastValue<UniqueId>();
                        var rotated = writer.RotateLong(uniqueId.Random);
                        uniqueIds.Add(new UniqueId(rotated, uniqueId.Time, uniqueId.Index));
                    });

                    writer.WriteInterleaved(uniqueIds);
                    break;
                }
                case PropertyType.FontFace:
                {
                    props.ForEach(prop =>
                    {
                        var font = prop.CastValue<FontFace>();

                        string family = font.Family;
                        writer.WriteString(family);

                        var weight = (ushort)font.Weight;
                        writer.Write(weight);

                        var style = (byte)font.Style;
                        writer.Write(style);

                        var cachedFaceId = font.CachedFaceId;
                        writer.WriteString(cachedFaceId);
                    });

                    break;
                }
                default:
                {
                    RobloxFile.LogError($"Unhandled property type: {Type} in {this}!");
                    break;
                }
            }
        }

        public void WriteInfo(StringBuilder builder)
        {
            builder.AppendLine($"- Name:       {Name}");
            builder.AppendLine($"- Type:       {Type}");
            builder.AppendLine($"- TypeId:     {TypeId}");
            builder.AppendLine($"- ClassName:  {ClassName}");
            builder.AppendLine($"- ClassIndex: {ClassIndex}");

            builder.AppendLine($"| InstanceId |           Value           |");
            builder.AppendLine($"|-----------:|---------------------------|");

            INST inst = File.Classes[ClassIndex];

            foreach (var instId in inst.InstanceIds)
            {
                Instance instance = File.Instances[instId];
                Property prop = instance?.GetProperty(Name);

                object value = prop?.Value;
                string str = value?.ToInvariantString() ?? "null";

                if (value is byte[] buffer)
                    str = Convert.ToBase64String(buffer);

                if (str.Length > 25)
                    str = str.Substring(0, 22) + "...";

                str = str.Replace('\r', ' ');
                str = str.Replace('\n', ' ');

                string row = string.Format("| {0, 10} | {1, -25} |", instId, str);
                builder.AppendLine(row);
            }
        }
    }
}
