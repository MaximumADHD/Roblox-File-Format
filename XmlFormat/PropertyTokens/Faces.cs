using System.Xml;
using Roblox.DataTypes;

namespace Roblox.XmlFormat.PropertyTokens
{
    public class FacesToken : IXmlPropertyToken
    {
        public string Token => "Faces";

        public bool ReadToken(Property prop, XmlNode token)
        {
            bool success = XmlPropertyTokens.ReadTokenGeneric<uint>(prop, PropertyType.Faces, token);

            if (success)
            {
                uint value = (uint)prop.Value;
                try
                {
                    Faces faces = (Faces)value;
                    prop.Value = faces;
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
