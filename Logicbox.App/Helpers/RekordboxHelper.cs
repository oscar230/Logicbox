using Logicbox.App.Models.Rekordbox;

namespace Logicbox.App.Helpers
{
    internal static class RekordboxHelper
    {
        internal static Library GetLibrary(FileInfo libraryFileInfo) => XmlHelper.Deserialize<Library>(libraryFileInfo);
        internal static Library GetLibrary(string libraryFileName) => XmlHelper.Deserialize<Library>(libraryFileName);
    }
}
