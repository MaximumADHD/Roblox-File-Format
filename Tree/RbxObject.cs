using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RobloxFiles
{
    public class RbxObject
    {
        public RbxObject()
        {
            RefreshProperties();
        }

        /// <summary>The ClassName of this Object.</summary>
        public string ClassName => GetType().Name;

        /// <summary>A context-dependent unique identifier for this object when being serialized.</summary>
        public string Referent { get; set; }

        /// <summary>Internal list of properties that are under this Object.</summary>
        internal readonly Dictionary<string, Property> props = new Dictionary<string, Property>();

        /// <summary>A list of properties that are defined under this Object.</summary>
        public IReadOnlyDictionary<string, Property> Properties => props;

        /// <summary>Indicates whether this Object has been destroyed.</summary>
        public bool Destroyed { get; internal set; }

        /// <summary>
        /// Returns true if the provided instance inherits from the provided instance type.
        /// </summary>
        public bool IsA<T>() where T : RbxObject
        {
            return this is T;
        }

        /// <summary>
        /// Attempts to cast this Instance to an inherited class of type '<typeparamref name="T"/>'.
        /// Returns null if the instance cannot be casted to the provided type.
        /// </summary>
        /// <typeparam name="T">The type of Instance to cast to.</typeparam>
        /// <returns>The instance as the type '<typeparamref name="T"/>' if it can be converted, or null.</returns>
        public T Cast<T>() where T : RbxObject
        {
            return this as T;
        }

        public virtual void Destroy()
        {
            props.Clear();
        }

        /// <summary>
        /// Returns a Property object whose name is the provided string name.
        /// </summary>
        public Property GetProperty(string name)
        {
            Property result = null;

            if (props.ContainsKey(name))
                result = props[name];

            return result;
        }

        /// <summary>
        /// Adds a property by reference to this Object's property list.
        /// </summary>
        /// <param name="prop">A reference to the property that will be added.</param>
        internal void AddProperty(Property prop)
        {
            string name = prop.Name;
            RemoveProperty(name);

            prop.Object = this;
            props.Add(name, prop);
        }

        /// <summary>
        /// Removes a property with the provided name if a property with the provided name exists.
        /// </summary>
        /// <param name="name">The name of the property to be removed.</param>
        /// <returns>True if a property with the provided name was removed.</returns> 
        internal bool RemoveProperty(string name)
        {
            if (props.ContainsKey(name))
            {
                Property prop = Properties[name];
                prop.Object = null;
            }

            return props.Remove(name);
        }

        /// <summary>
        /// Ensures that all serializable properties of this Instance have
        /// a registered Property object with the correct PropertyType.
        /// </summary>
        internal virtual IReadOnlyDictionary<string, Property> RefreshProperties()
        {
            Type instType = GetType();
            FieldInfo[] fields = instType.GetFields(Property.BindingFlags);

            foreach (FieldInfo field in fields)
            {
                string fieldName = field.Name;
                Type fieldType = field.FieldType;

                // A few specific edge case hacks. I wish these didn't need to exist :(
                if (fieldName == "Archivable" || fieldName.EndsWith("k__BackingField"))
                    continue;
                else if (fieldName == "Bevel_Roundness")
                    fieldName = "Bevel Roundness";

                PropertyType propType = PropertyType.Unknown;
                var flagAttribute = Attribute.GetCustomAttribute(fieldType, typeof(FlagsAttribute));

                if (fieldType.IsEnum && flagAttribute == null)
                    propType = PropertyType.Enum;
                else if (Property.Types.ContainsKey(fieldType))
                    propType = Property.Types[fieldType];
                else if (typeof(Instance).IsAssignableFrom(fieldType))
                    propType = PropertyType.Ref;

                if (propType != PropertyType.Unknown)
                {
                    if (fieldName.EndsWith("_"))
                        fieldName = instType.Name;

                    string xmlToken = fieldType.Name;

                    if (fieldType.IsEnum && flagAttribute == null)
                        xmlToken = "token";
                    else if (propType == PropertyType.Ref)
                        xmlToken = "Ref";

                    switch (xmlToken)
                    {
                        case "String":
                        case "Double":
                        case "Int64":
                        {
                            xmlToken = xmlToken.ToLowerInvariant();
                            break;
                        }
                        case "Boolean":
                        {
                            xmlToken = "bool";
                            break;
                        }
                        case "Single":
                        {
                            xmlToken = "float";
                            break;
                        }
                        case "Int32":
                        {
                            xmlToken = "int";
                            break;
                        }
                        case "Rect":
                        {
                            xmlToken = "Rect2D";
                            break;
                        }
                        case "CFrame":
                        {
                            xmlToken = "CoordinateFrame";
                            break;
                        }
                        case "FontFace":
                        {
                            xmlToken = "Font";
                            break;
                        }
                        case "Optional`1":
                        {
                            // TODO: If more optional types are added,
                            //       this needs disambiguation.

                            xmlToken = "OptionalCoordinateFrame";
                            break;
                        }
                    }

                    if (!props.ContainsKey(fieldName))
                    {
                        var newProp = new Property()
                        {
                            Value = field.GetValue(this),
                            XmlToken = xmlToken,
                            Name = fieldName,
                            Type = propType,
                            Object = this
                        };

                        AddProperty(newProp);
                    }
                    else
                    {
                        Property prop = props[fieldName];
                        prop.Value = field.GetValue(this);
                        prop.XmlToken = xmlToken;
                        prop.Type = propType;
                    }
                }
            }

            return Properties;
        }
    }
}
