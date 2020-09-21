using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RobloxFiles
{
    /// <summary>
    /// Describes an object in Roblox's DataModel hierarchy.
    /// Instances can have sets of properties loaded from *.rbxl/*.rbxm files.
    /// </summary>

    public class Instance
    {
        public Instance()
        {
            Name = ClassName;
        }
        
        /// <summary>The ClassName of this Instance.</summary>
        public string ClassName => GetType().Name;

        /// <summary>Internal list of properties that are under this Instance.</summary>
        private readonly Dictionary<string, Property> props = new Dictionary<string, Property>();

        /// <summary>A list of properties that are defined under this Instance.</summary>
        public IReadOnlyDictionary<string, Property> Properties => props;

        /// <summary>The raw list of children for this Instance.</summary>
        internal HashSet<Instance> Children = new HashSet<Instance>();

        /// <summary>The raw unsafe value of the Instance's parent.</summary>
        private Instance ParentUnsafe;

        /// <summary>The name of this Instance.</summary>
        public string Name;

        /// <summary>Indicates whether this Instance should be serialized.</summary>
        public bool Archivable = true;

        /// <summary>The source AssetId this instance was created in.</summary>
        public long SourceAssetId = -1;
        
        /// <summary>The name of this Instance, if a Name property is defined.</summary>
        public override string ToString() => Name;

        /// <summary>A unique identifier for this instance when being serialized.</summary>
        public string Referent { get; set; }

        /// <summary>Indicates whether the parent of this object is locked.</summary>
        public bool ParentLocked { get; internal set; }

        /// <summary>Indicates whether this Instance is a Service.</summary>
        public bool IsService { get; internal set; }

        /// <summary>Indicates whether this Instance has been destroyed.</summary>
        public bool Destroyed { get; internal set; }

        /// <summary>A list of CollectionService tags assigned to this Instance.</summary>
        public List<string> Tags { get; } = new List<string>();

        /// <summary>The attributes defined for this Instance.</summary>
        public Attributes Attributes { get; private set; }

        /// <summary>The internal serialized data of this Instance's attributes</summary>
        internal byte[] AttributesSerialize
        {
            get
            {
                return Attributes?.Serialize() ?? Array.Empty<byte>();
            }
            set
            {
                MemoryStream data = new MemoryStream(value);
                Attributes = new Attributes(data);
            }
        }

        /// <summary>
        /// Internal format of the Instance's CollectionService tags.
        /// Property objects will look to this member for serializing the Tags property.
        /// </summary>
        internal byte[] SerializedTags
        {
            get
            {
                string fullString = string.Join("\0", Tags.ToArray());

                byte[] buffer = fullString.ToCharArray()
                    .Select(ch => (byte)ch)
                    .ToArray();

                return buffer;
            }
            set
            {
                int length = value.Length;

                List<byte> buffer = new List<byte>();
                Tags.Clear();
                
                for (int i = 0; i < length; i++)
                {
                    byte id = value[i];

                    if (id != 0)
                        buffer.Add(id);

                    if (id == 0 || i == (length - 1))
                    {
                        byte[] data = buffer.ToArray();
                        buffer.Clear();

                        string tag = Encoding.UTF8.GetString(data);
                        Tags.Add(tag);
                    }
                }
            }
        }

        /// <summary>Returns true if this Instance is an ancestor to the provided Instance.</summary>
        /// <param name="descendant">The instance whose descendance will be tested against this Instance.</param>
        public bool IsAncestorOf(Instance descendant)
        {
            while (descendant != null)
            {
                if (descendant == this)
                    return true;

                descendant = descendant.Parent;
            }

            return false;
        }

        /// <summary>Returns true if this Instance is a descendant of the provided Instance.</summary>
        /// <param name="ancestor">The instance whose ancestry will be tested against this Instance.</param>
        public bool IsDescendantOf(Instance ancestor)
        {
            Contract.Requires(ancestor != null);
            return ancestor.IsAncestorOf(this);
        }

        /// <summary>
        /// Returns true if the provided instance inherits from the provided instance type.
        /// </summary>
        [Obsolete("Use the `is` operator instead.")]
        public bool IsA<T>() where T : Instance
        {
            Type myType = GetType();
            Type classType = typeof(T);
            return classType.IsAssignableFrom(myType);
        }

        /// <summary>
        /// Attempts to cast this Instance to an inherited class of type '<typeparamref name="T"/>'.
        /// Returns null if the instance cannot be casted to the provided type.
        /// </summary>
        /// <typeparam name="T">The type of Instance to cast to.</typeparam>
        /// <returns>The instance as the type '<typeparamref name="T"/>' if it can be converted, or null.</returns>
        public T Cast<T>() where T : Instance
        {
            T result = null;

            if (this is T)
                result = this as T;

            return result;
        }

        /// <summary>
        /// The parent of this Instance, or null if the instance is the root of a tree.<para/>
        /// Setting the value of this property will throw an exception if:<para/>
        /// - The parent is currently locked.<para/>
        /// - The value is set to itself.<para/>
        /// - The value is a descendant of the Instance.
        /// </summary>
        public Instance Parent
        {
            get => ParentUnsafe;

            set
            {
                if (ParentLocked)
                {
                    string newParent = value?.Name ?? "NULL",
                           currParent = Parent?.Name ?? "NULL";

                    throw new InvalidOperationException($"The Parent property of {Name} is locked, current parent: {currParent}, new parent {newParent}");
                }

                if (IsAncestorOf(value))
                {
                    string pathA = GetFullName("."),
                           pathB = value.GetFullName(".");

                    throw new InvalidOperationException($"Attempt to set parent of {pathA} to {pathB} would result in circular reference");
                }

                if (Parent == this)
                    throw new InvalidOperationException($"Attempt to set {Name} as its own parent");

                ParentUnsafe?.Children.Remove(this);
                value?.Children.Add(this);
                ParentUnsafe = value;
            }
        }

        /// <summary>
        /// Returns an array containing all the children of this Instance.
        /// </summary>
        public Instance[] GetChildren()
        {
            return Children.ToArray();
        }

        /// <summary>
        /// Returns an array containing all the children of this Instance, whose type is '<typeparamref name="T"/>'.
        /// </summary>
        public T[] GetChildrenOfType<T>() where T : Instance
        {
            T[] ofType = GetChildren()
                .Where(child => child is T)
                .Cast<T>()
                .ToArray();

            return ofType;
        }

        /// <summary>
        /// Returns an array containing all the descendants of this Instance.
        /// </summary>
        public Instance[] GetDescendants()
        {
            var results = new List<Instance>();

            foreach (Instance child in Children)
            {
                // Add this child to the results.
                results.Add(child);

                // Add its descendants to the results.
                Instance[] descendants = child.GetDescendants();
                results.AddRange(descendants);
            }

            return results.ToArray();
        }

        /// <summary>
        /// Returns an array containing all the descendants of this Instance, whose type is '<typeparamref name="T"/>'.
        /// </summary>
        public T[] GetDescendantsOfType<T>() where T : Instance
        {
            T[] ofType = GetDescendants()
                .Where(desc => desc is T)
                .Cast<T>()
                .ToArray();

            return ofType;
        }

        /// <summary>
        /// Returns the first child of this Instance whose Name is the provided string name.
        /// If the instance is not found, this returns null.
        /// </summary>
        /// <param name="name">The Name of the Instance to find.</param>
        /// <param name="recursive">Indicates if we should search descendants as well.</param>
        public T FindFirstChild<T>(string name, bool recursive = false) where T : Instance
        {
            T result = null;

            var query = Children
                .Where(child => child is T)
                .Where(child => name == child.Name)
                .Cast<T>();

            if (query.Any())
            {
                result = query.First();
            }
            else if (recursive)
            {
                foreach (Instance child in Children)
                {
                    T found = child.FindFirstChild<T>(name, true);

                    if (found != null)
                    {
                        result = found;
                        break;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Returns the first child of this Instance whose Name is the provided string name.
        /// If the instance is not found, this returns null.
        /// </summary>
        /// <param name="name">The Name of the Instance to find.</param>
        /// <param name="recursive">Indicates if we should search descendants as well.</param>
        public Instance FindFirstChild(string name, bool recursive = false)
        {
            return FindFirstChild<Instance>(name, recursive);
        }

        /// <summary>
        /// Returns the first ancestor of this Instance whose Name is the provided string name.
        /// If the instance is not found, this returns null.
        /// </summary>
        /// <param name="name">The Name of the Instance to find.</param>
        public T FindFirstAncestor<T>(string name) where T : Instance
        {
            Instance ancestor = Parent;

            while (ancestor != null)
            {
                if (ancestor is T && ancestor.Name == name)
                    return ancestor as T;
                
                ancestor = ancestor.Parent;
            }

            return null;
        }

        /// <summary>
        /// Returns the first ancestor of this Instance whose Name is the provided string name.
        /// If the instance is not found, this returns null.
        /// </summary>
        /// <param name="name">The Name of the Instance to find.</param>
        public Instance FindFirstAncestor(string name)
        {
            return FindFirstAncestor<Instance>(name);
        }

        /// <summary>
        /// Returns the first ancestor of this Instance whose ClassName is the provided string className.
        /// If the instance is not found, this returns null.
        /// </summary>
        /// <param name="name">The Name of the Instance to find.</param>
        public T FindFirstAncestorOfClass<T>() where T : Instance
        {
            Instance ancestor = Parent;

            while (ancestor != null)
            {
                if (ancestor is T)
                    return ancestor as T;
                
                ancestor = ancestor.Parent;
            }

            return null;
        }

        /// <summary>
        /// Returns the first ancestor of this Instance which derives from the provided type <typeparamref name="T"/>.
        /// If the instance is not found, this returns null.
        /// </summary>
        /// <param name="name">The Name of the Instance to find.</param>
        public T FindFirstAncestorWhichIsA<T>() where T : Instance
        {
            T ancestor = null;
            Instance check = Parent;

            while (check != null)
            {
                if (check is T)
                {
                    ancestor = check as T;
                    break;
                }

                check = check.Parent;
            }

            return ancestor;
        }

        /// <summary>
        /// Returns the first Instance whose ClassName is the provided string className.
        /// If the instance is not found, this returns null.
        /// </summary>
        /// <param name="className">The ClassName of the Instance to find.</param>
        public T FindFirstChildOfClass<T>(bool recursive = false) where T : Instance
        {
            var query = Children
                .Where(child => child is T)
                .Cast<T>();

            T result = null;
            
            if (query.Any())
            {
                result = query.First();
            }
            else if (recursive)
            {
                foreach (Instance child in Children)
                {
                    T found = child.FindFirstChildOfClass<T>(true);

                    if (found != null)
                    {
                        result = found;
                        break;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Disposes of this instance and its descendants, and locks its parent.
        /// All property bindings, tags, and attributes are cleared.
        /// </summary>
        public void Destroy()
        {
            Destroyed = true;
            props.Clear();
            
            Parent = null;
            ParentLocked = true;

            Tags?.Clear();
            Attributes?.Clear();

            while (Children.Any())
            {
                var child = Children.First();
                child.Destroy();
            }
        }

        /// <summary>
        /// Returns the first child of this Instance which derives from the provided type <typeparamref name="T"/>.
        /// If the instance is not found, this returns null.
        /// </summary>
        /// <param name="recursive">Whether this should search descendants as well.</param>
        public T FindFirstChildWhichIsA<T>(bool recursive = false) where T : Instance
        {
            var query = Children
                .Where(child => child is T)
                .Cast<T>();

            if (query.Any())
                return query.First();
            
            if (recursive)
            {
                foreach (Instance child in Children)
                {
                    T found = child.FindFirstChildWhichIsA<T>(true);

                    if (found == null)
                        continue;

                    return found;
                }
            }

            return null;
        }

        /// <summary>
        /// Returns a string describing the index traversal of this Instance, starting from its root ancestor.
        /// </summary>
        public string GetFullName(string separator = "\\")
        {
            string fullName = Name;
            Instance at = Parent;

            while (at != null)
            {
                fullName = at.Name + separator + fullName;
                at = at.Parent;
            }

            return fullName;
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
        /// Adds a property by reference to this Instance's property list.
        /// </summary>
        /// <param name="prop">A reference to the property that will be added.</param>
        internal void AddProperty(ref Property prop)
        {
            prop.Instance = this;

            if (props.ContainsKey(prop.Name))
                props.Remove(prop.Name);

            props.Add(prop.Name, prop);
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
                prop.Instance = null;
            }

            return props.Remove(name);
        }

        /// <summary>
        /// Ensures that all serializable properties of this Instance have
        /// a registered Property object with the correct PropertyType.
        /// </summary>
        internal IReadOnlyDictionary<string, Property> RefreshProperties()
        {
            Type instType = GetType();
            FieldInfo[] fields = instType.GetFields(Property.BindingFlags);

            foreach (FieldInfo field in fields)
            {
                string fieldName = field.Name;
                Type fieldType = field.FieldType;

                if (field.GetCustomAttribute<ObsoleteAttribute>() != null)
                    continue;

                // A few specific edge case hacks. I wish these didn't need to exist :(

                if (fieldName == "Archivable" || fieldName.EndsWith("k__BackingField"))
                    continue;
                else if (fieldName == "Bevel_Roundness")
                    fieldName = "Bevel Roundness";

                PropertyType propType = PropertyType.Unknown;
                
                if (Property.Types.ContainsKey(fieldType))
                    propType = Property.Types[fieldType];
                else if (fieldType.IsEnum)
                    propType = PropertyType.Enum;
                
                if (propType != PropertyType.Unknown)
                {
                    if (fieldName.EndsWith("_"))
                        fieldName = instType.Name;

                    string xmlToken = fieldType.Name;

                    if (fieldType.IsEnum)
                        xmlToken = "token";

                    switch (xmlToken)
                    {
                        case "String":
                        case "Double":
                        case "Int64":
                            xmlToken = xmlToken.ToLowerInvariant();
                            break;
                        case "Boolean":
                            xmlToken = "bool";
                            break;
                        case "Single":
                            xmlToken = "float";
                            break;
                        case "Int32":
                            xmlToken = "int";
                            break;
                        case "Rect":
                            xmlToken = "Rect2D";
                            break;
                        case "CFrame":
                            xmlToken = "CoordinateFrame";
                            break;
                        default: break;
                    }

                    if (!props.ContainsKey(fieldName))
                    {
                        var newProp = new Property()
                        {
                            Value = field.GetValue(this),
                            XmlToken = xmlToken,
                            Name = fieldName,
                            Type = propType,
                            Instance = this
                        };

                        AddProperty(ref newProp);
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

            Property tags = GetProperty("Tags");
            Property attributes = GetProperty("AttributesSerialize");
            
            if (tags == null)
            {
                tags = new Property("Tags", PropertyType.String);
                AddProperty(ref tags);
            }

            if (attributes == null)
            {
                attributes = new Property("AttributesSerialize", PropertyType.String);
                AddProperty(ref attributes);
            }

            return Properties;
        }
    }
}
