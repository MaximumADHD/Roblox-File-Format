﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using RobloxFiles.BinaryFormat.Chunks;
using RobloxFiles.DataTypes;
using RobloxFiles.Utility;

namespace RobloxFiles
{
    public enum PropertyType
    {
        Unknown,
        String,
        Bool,
        Int,
        Float,
        Double,
        UDim,
        UDim2,
        Ray,
        Faces,
        Axes,
        BrickColor,
        Color3,
        Vector2,
        Vector3,
        CFrame = 16,
        Quaternion,
        Enum,
        Ref,
        Vector3int16,
        NumberSequence,
        ColorSequence,
        NumberRange,
        Rect,
        PhysicalProperties,
        Color3uint8,
        Int64,
        SharedString,
        ProtectedString,
        OptionalCFrame,
        UniqueId,
        FontFace
    }

    public class Property
    {
        public string Name { get; internal set; }
        public Instance Instance { get; internal set; }
        public PropertyType Type { get; internal set; }

        public string XmlToken { get; internal set; }
        public byte[] RawBuffer { get; internal set; }

        internal object RawValue;
        
        internal static BindingFlags BindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy | BindingFlags.IgnoreCase;

        // TODO: Map typeof(ProtectedString) to PropertyType.ProtectedString
        //       if binary files are ever publicly allowed to read it.

        public static readonly IReadOnlyDictionary<Type, PropertyType> Types = new Dictionary<Type, PropertyType>()
        {
            { typeof(Axes),   PropertyType.Axes  },
            { typeof(Faces),  PropertyType.Faces },

            { typeof(int),     PropertyType.Int    },
            { typeof(bool),    PropertyType.Bool   },
            { typeof(long),    PropertyType.Int64  },
            { typeof(float),   PropertyType.Float  },
            { typeof(double),  PropertyType.Double },
            { typeof(string),  PropertyType.String },

            { typeof(Ray),       PropertyType.Ray      },
            { typeof(Rect),      PropertyType.Rect     },
            { typeof(UDim),      PropertyType.UDim     },
            { typeof(UDim2),     PropertyType.UDim2    },
            { typeof(CFrame),    PropertyType.CFrame   },
            { typeof(Color3),    PropertyType.Color3   },
            { typeof(Content),   PropertyType.String   },
            { typeof(Vector2),   PropertyType.Vector2  },
            { typeof(Vector3),   PropertyType.Vector3  },
            { typeof(FontFace),  PropertyType.FontFace },
            
            { typeof(BrickColor),    PropertyType.BrickColor   },
            { typeof(Quaternion),    PropertyType.Quaternion   },
            { typeof(Color3uint8),   PropertyType.Color3uint8  },
            { typeof(NumberRange),   PropertyType.NumberRange  },
            { typeof(SharedString),  PropertyType.SharedString },
            { typeof(Vector3int16),  PropertyType.Vector3int16 },

            { typeof(ColorSequence),     PropertyType.ColorSequence  },
            { typeof(NumberSequence),    PropertyType.NumberSequence },
            { typeof(Optional<CFrame>),  PropertyType.OptionalCFrame },

            { typeof(ProtectedString),     PropertyType.String             }, 
            { typeof(PhysicalProperties),  PropertyType.PhysicalProperties },
        };

        private void ImproviseRawBuffer()
        {
            if (RawValue is byte[])
            {
                RawBuffer = RawValue as byte[];
                return;
            }
            else if (RawValue is SharedString sharedString)
            {
                if (sharedString != null)
                {
                    RawBuffer = sharedString.SharedValue;
                    return;
                }
            }
            else if (RawValue is ProtectedString protectedString)
            {
                if (protectedString != null)
                {
                    RawBuffer = protectedString.RawBuffer;
                    return;
                }
            }

            if (RawValue is long)
                Type = PropertyType.Int64;
            
            switch (Type)
            {
                case PropertyType.Int:
                {
                    if (Value is long)
                    {
                        Type = PropertyType.Int64;
                        goto case PropertyType.Int64;
                    }

                    RawBuffer = BitConverter.GetBytes((int)Value);
                    break;
                }
                case PropertyType.Bool:
                {
                    RawBuffer = BitConverter.GetBytes((bool)Value);
                    break;
                }
                case PropertyType.Int64:
                {
                    RawBuffer = BitConverter.GetBytes((long)Value);
                    break;
                }
                case PropertyType.Float:
                {
                    RawBuffer = BitConverter.GetBytes((float)Value);
                    break;
                }
                case PropertyType.Double:
                {
                    RawBuffer = BitConverter.GetBytes((double)Value);
                    break;
                }
            }
        }

        private string ImplicitName
        {
            get
            {
                if (Instance != null)
                {
                    Type instType = Instance.GetType();
                    string typeName = instType.Name;

                    if (typeName == Name)
                    {
                        FieldInfo directField = instType.GetFields()
                            .Where(field => field.Name.StartsWith(Name, StringComparison.InvariantCulture))
                            .Where(field => field.DeclaringType == instType)
                            .FirstOrDefault();
                        
                        if (directField != null)
                        {
                            var implicitName = Name + '_';
                            return implicitName;
                        }
                    }
                }

                if (Name.Contains(" "))
                    return Name.Replace(' ', '_');
                
                return Name;
            }
        }

        public object Value
        {
            get
            {
                if (Instance != null)
                {
                    if (Name == "Tags")
                    {
                        byte[] data = Instance.SerializedTags;
                        RawValue = data;
                    }
                    else
                    {
                        var type = Instance.GetType();
                        var member = ImplicitMember.Get(type, ImplicitName);

                        if (member != null)
                        {
                            object value = member.GetValue(Instance);
                            RawValue = value;
                        }
                        else
                        {
                            RobloxFile.LogError($"RobloxFiles.Property - Property {Instance.ClassName}.{Name} does not exist!");
                        }
                    }
                }

                return RawValue;
            }
            set
            {
                if (Instance != null)
                {
                    if (Name == "Tags" && value is byte[] data)
                    {
                        Instance.SerializedTags = data;
                    }
                    else
                    {
                        var type = Instance.GetType();
                        var member = ImplicitMember.Get(type, ImplicitName);

                        if (member != null)
                        {
                            var valueType = value?.GetType();
                            Type memberType = member.MemberType;
                            
                            if (value == null || memberType.IsAssignableFrom(valueType))
                            {
                                try
                                {
                                    member.SetValue(Instance, value);
                                }
                                catch
                                {
                                    RobloxFile.LogError($"RobloxFiles.Property - Failed to cast value {value} into property {Instance.ClassName}.{Name}");
                                }
                            }
                            else if (valueType != null)
                            {
                                MethodInfo implicitCast = memberType.GetMethod("op_Implicit", new Type[] { valueType });

                                if (implicitCast != null)
                                {
                                    try
                                    {
                                        object castedValue = implicitCast.Invoke(null, new object[] { value });
                                        member.SetValue(Instance, castedValue);
                                    }
                                    catch
                                    {
                                        RobloxFile.LogError($"RobloxFiles.Property - Failed to implicitly cast value {value} into property {Instance.ClassName}.{Name}");
                                    }
                                }
                            }
                        }
                    }
                }

                RawValue = value;
                RawBuffer = null;

                ImproviseRawBuffer();
            }
        }

        public bool HasRawBuffer
        {
            get
            {
                // Improvise what the buffer should be if this is a primitive.

                if (RawBuffer == null && Value != null)
                    ImproviseRawBuffer();

                return (RawBuffer != null);
            }
        }

        public Property(string name = "", PropertyType type = PropertyType.Unknown, Instance instance = null)
        {
            Instance = instance;
            Name = name;
            Type = type;
        }

        public Property(Instance instance, PROP property)
        {
            Instance = instance;
            Name = property.Name;
            Type = property.Type;
        }

        public string GetFullName()
        {
            string result = Name;

            if (Instance != null)
                result = Instance.GetFullName() + "->" + result;

            return result;
        }

        public override string ToString()
        {
            string typeName = Enum.GetName(typeof(PropertyType), Type);
            string valueLabel = (Value != null ? Value.ToString() : "null");

            if (Type == PropertyType.String)
                valueLabel = '"' + valueLabel + '"';

            return string.Join(" ", typeName, Name, '=', valueLabel);
        }

        public T CastValue<T>()
        {
            object result;

            if (typeof(T) == typeof(string))
                result = Value?.ToString() ?? "";
            else if (Value is T typedValue)
                result = typedValue;
            else
                result = default(T);
            
            return (T)result;
        }
    }
}