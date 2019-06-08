using System;
using System.Collections.Generic;
using System.Linq;

namespace RobloxFiles
{
    /// <summary>
    /// Describes an object in Roblox's DataModel hierarchy.
    /// Instances can have sets of properties loaded from *.rbxl/*.rbxm files.
    /// </summary>

    public class Instance
    {
        /// <summary>The ClassName of this Instance.</summary>
        public string ClassName;

        /// <summary>A list of properties that are defined under this Instance.</summary>
        private Dictionary<string, Property> props = new Dictionary<string, Property>();
        public IReadOnlyDictionary<string, Property> Properties => props;

        protected List<Instance> Children = new List<Instance>();
        private Instance parent;

        /// <summary>The name of this Instance, if a Name property is defined.</summary>
        public override string ToString() => Name;

        /// <summary>A unique identifier for this instance when being serialized.</summary>
        public string Referent { get; internal set; }

        /// <summary>Indicates whether the parent of this object is locked.</summary>
        public bool ParentLocked { get; internal set; }

        /// <summary>Indicates whether this Instance is marked as a Service in the binary file format.</summary>
        public bool IsService { get; internal set; }

        /// <summary>If this instance is a service, this indicates whether the service should be loaded via GetService when Roblox loads the place file.</summary>
        public bool IsRootedService { get; internal set; }

        /// <summary>Indicates whether this object should be serialized.</summary>
        public bool Archivable = true;

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
            return ancestor.IsAncestorOf(this);
        }

        public string Name
        {
            get
            {
                Property propName = GetProperty("Name");

                if (propName == null)
                    SetProperty("Name", "Instance");

                return propName.Value.ToString();
            }
            set
            {
                SetProperty("Name", value);
            }
        }

        /// <summary>
        /// The parent of this Instance, or null if the instance is the root of a tree.<para/>
        /// Setting the value of this property will throw an exception if:<para/>
        /// - The value is set to itself.<para/>
        /// - The value is a descendant of the Instance.
        /// </summary>
        public Instance Parent
        {
            get
            {
                return parent;
            }
            set
            {
                if (ParentLocked)
                    throw new Exception("The Parent property of this instance is locked.");

                if (IsAncestorOf(value))
                    throw new Exception("Parent would result in circular reference.");

                if (Parent == this)
                    throw new Exception("Attempt to set parent to self.");

                if (parent != null)
                    parent.Children.Remove(this);

                value.Children.Add(this);
                parent = value;
            }
        }

        /// <summary>
        /// Returns a snapshot of the Instances currently parented to this Instance, as an array.
        /// </summary>
        public Instance[] GetChildren()
        {
            return Children.ToArray();
        }

        /// <summary>
        /// Returns a snapshot of the Instances that are descendants of this Instance, as an array.
        /// </summary>
        public Instance[] GetDescendants()
        {
            List<Instance> results = new List<Instance>();

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
        /// Returns the first child of this Instance whose Name is the provided string name.
        /// If the instance is not found, this returns null.
        /// </summary>
        /// <param name="name">The Name of the Instance to find.</param>
        /// <param name="recursive">Indicates if we should search descendants as well.</param>
        public Instance FindFirstChild(string name, bool recursive = false)
        {
            Instance result = null;
            var query = Children.Where((child) => name == child.Name);

            if (query.Count() > 0)
            {
                result = query.First();
            }
            else if (recursive)
            {
                foreach (Instance child in Children)
                {
                    Instance found = child.FindFirstChild(name, true);

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
        /// Returns the first ancestor of this Instance whose Name is the provided string name.
        /// If the instance is not found, this returns null.
        /// </summary>
        /// <param name="name">The Name of the Instance to find.</param>
        public Instance FindFirstAncestor(string name)
        {
            Instance ancestor = Parent;

            while (ancestor != null)
            {
                if (ancestor.Name == name)
                    break;

                ancestor = ancestor.Parent;
            }

            return ancestor;
        }

        /// <summary>
        /// Returns the first ancestor of this Instance whose ClassName is the provided string className.
        /// If the instance is not found, this returns null.
        /// </summary>
        /// <param name="name">The Name of the Instance to find.</param>
        public Instance FindFirstAncestorOfClass(string className)
        {
            Instance ancestor = Parent;

            while (ancestor != null)
            {
                if (ancestor.ClassName == className)
                    break;

                ancestor = ancestor.Parent;
            }

            return ancestor;
        }

        /// <summary>
        /// Returns the first Instance whose ClassName is the provided string className.
        /// If the instance is not found, this returns null.
        /// </summary>
        /// <param name="className">The ClassName of the Instance to find.</param>
        public Instance FindFirstChildOfClass(string className, bool recursive = false)
        {
            Instance result = null;
            var query = Children.Where((child) => className == child.ClassName);

            if (query.Count() > 0)
                result = query.First();

            return result;
        }

        /// <summary>
        /// Returns a string descrbing the index traversal of this Instance, starting from its root ancestor.
        /// </summary>
        public string GetFullName()
        {
            string fullName = Name;
            Instance at = Parent;

            while (at != null)
            {
                fullName = at.Name + '.' + fullName;
                at = at.Parent;
            }

            return fullName;
        }

        /// <summary>
        /// Returns a Property object if a property with the specified name is defined in this Instance.
        /// </summary>
        public Property GetProperty(string name)
        {
            Property result = null;

            if (Properties.ContainsKey(name))
                result = Properties[name];

            return result;
        }

        /// <summary>
        /// Finds or creates a property with the specified name, and sets its value to the provided object.
        /// Returns the property object that had its value set, if the value is not null.
        /// </summary>
        public Property SetProperty(string name, object value, PropertyType? preferType = null)
        {
            Property prop = GetProperty(name) ?? new Property()
            {
                Type = preferType ?? PropertyType.Unknown,
                Name = name
            };

            if (preferType == null)
            {
                object oldValue = prop.Value;

                Type oldType = oldValue?.GetType();
                Type newType = value?.GetType();

                if (oldType != newType)
                {
                    if (value == null)
                    {
                        RemoveProperty(name);
                        return prop;
                    }

                    string typeName = newType.Name;

                    if (value is Instance)
                        typeName = "Ref";
                    else if (value is int)
                        typeName = "Int";
                    else if (value is long)
                        typeName = "Int64";
                    
                    Enum.TryParse(typeName, out prop.Type);
                }
            }

            prop.Value = value;

            if (prop.Instance == null)
                AddProperty(ref prop);

            return prop;
        }

        /// <summary>
        /// Looks for a property with the specified property name, and returns its value as an object.
        /// <para/>The resulting value may be null if the property is not serialized.
        /// <para/>You can use the templated ReadProperty overload to fetch it as a specific type with a default value provided.
        /// </summary>
        /// <param name="propertyName">The name of the property to be fetched from this Instance.</param>
        /// <returns>An object reference to the value of the specified property, if it exists.</returns>
        public object ReadProperty(string propertyName)
        {
            Property property = GetProperty(propertyName);
            return property?.Value;
        }

        /// <summary>
        /// Looks for a property with the specified property name, and returns it as the specified type.<para/>
        /// If it cannot be converted, the provided nullFallback value will be returned instead.
        /// </summary>
        /// <typeparam name="T">The value type to convert to when finding the specified property name.</typeparam>
        /// <param name="propertyName">The name of the property to be fetched from this Instance.</param>
        /// <param name="nullFallback">A fallback value to be returned if casting to T fails, or the property is not found.</param>
        /// <returns></returns>
        public T ReadProperty<T>(string propertyName, T nullFallback)
        {
            try
            {
                object result = ReadProperty(propertyName);
                return (T)result;
            }
            catch
            {
                return nullFallback;
            }
        }

        /// <summary>
        /// Looks for a property with the specified property name. If found, it will try to set the value of the referenced outValue to its value.<para/>
        /// Returns true if the property was found and its value was casted to the referenced outValue.<para/>
        /// If it returns false, the outValue will not have its value set.
        /// </summary>
        /// <typeparam name="T">The value type to convert to when finding the specified property name.</typeparam>
        /// <param name="propertyName">The name of the property to be fetched from this Instance.</param>
        /// <param name="outValue">The value to write to if the property can be casted to T correctly.</param>
        public bool TryReadProperty<T>(string propertyName, ref T outValue)
        {
            try
            {
                object result = ReadProperty(propertyName);
                outValue = (T)result;

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Adds a property by reference to this Instance's property list.
        /// </summary>
        /// <param name="prop">A reference to the property that will be added.</param>
        internal void AddProperty(ref Property prop)
        {
            prop.Instance = this;

            if (prop.Name == "Name")
            {
                Property nameProp = GetProperty("Name");

                if (nameProp != null)
                {
                    nameProp.Value = prop.Value;
                    return;
                }
            }

            props.Add(prop.Name, prop);
        }

        /// <summary>
        /// Removes a property with the provided name if a property with the provided name exists.
        /// </summary>
        /// <param name="name">The name of the property to be removed.</param>
        /// <returns>True if a property with the provided name was removed.</returns> 
        public bool RemoveProperty(string name)
        {
            Property prop = GetProperty(name);

            if (prop != null)
                prop.Instance = null;

            return props.Remove(name);
        }
    }
}