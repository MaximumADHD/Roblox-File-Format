using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Roblox
{
    public class RobloxInstance
    {
        private List<RobloxInstance> _children = new List<RobloxInstance>();
        private RobloxInstance _parent;

        public string ClassName;
        public List<RobloxProperty> Properties = new List<RobloxProperty>();

        public bool IsAncestorOf(RobloxInstance other)
        {
            while (other != null)
            {
                if (other == this)
                    return true;

                other = other.Parent;
            }

            return false;
        }

        public bool IsDescendantOf(RobloxInstance other)
        {
            return other.IsAncestorOf(this);
        }

        public RobloxInstance Parent
        {
            get { return _parent; }
            set
            {
                if (IsAncestorOf(value))
                    throw new Exception("Parent would result in circular reference.");

                if (Parent == this)
                    throw new Exception("Attempt to set parent to self");

                if (_parent != null)
                    _parent._children.Remove(this);

                value._children.Add(this);
                _parent = value;
            }
        }

        public ReadOnlyCollection<RobloxInstance> Children
        {
            get { return _children.AsReadOnly(); }
        }

        public object ReadProperty(string propertyName)
        {
            RobloxProperty property = Properties
                .Where((prop) => prop.Name == propertyName)
                .First();

            return property.Value;
        }

        public bool TryReadProperty<T>(string propertyName, out T value)
        {
            try
            {
                object result = ReadProperty(propertyName);
                value = (T)result;

                return true;
            }
            catch
            {
                value = default(T);
                return false;
            }
        }

        public override string ToString()
        {
            var name = "";
            TryReadProperty("Name", out name);

            return '[' + ClassName + ']' + name;
        }
    }
}
