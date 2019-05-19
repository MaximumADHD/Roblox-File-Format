using System;
using System.Xml;
using RobloxFiles.DataTypes;

namespace RobloxFiles.XmlFormat.PropertyTokens
{
    public class AxesToken : IXmlPropertyToken
    {
        public string Token => "Axes";
        public bool ReadProperty(Property prop, XmlNode token)
        {
            bool success = XmlPropertyTokens.ReadPropertyGeneric<uint>(prop, PropertyType.Axes, token);

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

        public void WriteProperty(Property prop, XmlDocument doc, XmlNode node)
        {
            XmlElement axes = doc.CreateElement("axes");
            node.AppendChild(axes);

            int value = (int)prop.Value;
            axes.InnerText = value.ToInvariantString();
        }
    }
}
