using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RobloxFiles.XmlFormat
{
    public interface IXmlPropertyToken
    {
        string Token { get; }
        bool ReadToken(Property prop, XmlNode token);
    }
}
