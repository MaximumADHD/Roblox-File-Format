using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Roblox.XmlFormat
{
    public class RobloxXmlFile : IRobloxFile
    {
        private List<Instance> XmlTrunk = new List<Instance>();
        public IReadOnlyList<Instance> Trunk => XmlTrunk;

        public void Initialize(byte[] buffer)
        {
            // TODO!
        }
    }
}
