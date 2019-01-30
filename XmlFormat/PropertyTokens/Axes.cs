using System.Xml;
using Roblox.DataTypes;

namespace Roblox.XmlFormat.PropertyTokens
{
    public class AxesToken : IXmlPropertyToken
    {
        public string Token => "Axes";

        public bool ReadToken(Property prop, XmlNode token)
        {
            bool success = XmlPropertyTokens.ReadTokenGeneric<uint>(prop, PropertyType.Axes, token);

            if (success)
            {
                uint value = (uint)prop.Value;
                try
                {
                    Axes axes = (Axes)value;
                    prop.Value = axes;
                }
                catch
                {
                    success = false;
                }
            }

            return success;
        }
    }
}
