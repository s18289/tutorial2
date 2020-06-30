using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    [XmlRoot("studies")]
    [Serializable]
    public class Studies
    {
        [XmlElement(ElementName = "name")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "mode")]
        [JsonPropertyName("mode")]
        public string Mode { get; set; }

        public Studies() { }
        public Studies(string name, string mode)
        {
            Name = name;
            Mode = mode;
        }
    }
}