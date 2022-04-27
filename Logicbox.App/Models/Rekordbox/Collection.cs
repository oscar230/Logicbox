using System.Xml.Serialization;

namespace Logicbox.App.Models.Rekordbox
{
    public class Collection
    {
        [XmlAttribute(AttributeName = "Entries")]
        public string? Entries { get; set; }

        [XmlElement(ElementName = "TRACK")]
        public List<Track>? Tracks { get; set; }
    }
}