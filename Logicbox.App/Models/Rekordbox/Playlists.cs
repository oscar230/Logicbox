using System.Xml.Serialization;

namespace Logicbox.App.Models.Rekordbox
{
    public class Playlists
    {
        [XmlElement(ElementName = "NODE")]
        public PlaylistNode? PlaylistNode { get; set; }
    }
}