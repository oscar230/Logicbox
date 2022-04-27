using System.Xml.Serialization;

namespace Logicbox.App.Models.Rekordbox
{
    [XmlRoot(ElementName = "PRODUCT")]
    public class Product
    {
        [XmlAttribute(AttributeName = "Name")]
        public string? Name { get; set; }

        [XmlAttribute(AttributeName = "Version")]
        public string? Version { get; set; }

        [XmlAttribute(AttributeName = "Company")]
        public string? Company { get; set; }
    }
}