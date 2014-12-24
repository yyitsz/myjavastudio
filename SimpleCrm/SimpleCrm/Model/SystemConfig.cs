using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Xml.Serialization;

namespace SimpleCrm.Model
{
    [Serializable]
    [System.Xml.Serialization.XmlRoot("systemConfig")]
    public class SystemConfig
    {
        [XmlElement("dbversion")]
        public String DbVersion { get; set; }
    }
}
