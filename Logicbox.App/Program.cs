using Logicbox.App.Helpers;
using Logicbox.App.Models.Rekordbox;
using System.Reflection;


ConsoleHelper.WriteLine("Logicbox");
string? runningDirectoryAsString = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
if (runningDirectoryAsString is null)
{
    throw new Exception("Could not the running process's running directory.");
}
DirectoryInfo? runningDirectory = new FileInfo(runningDirectoryAsString).Directory;
if (runningDirectory is null || !runningDirectory.Exists)
{
    throw new DirectoryNotFoundException();
}
ConsoleHelper.WriteLine(runningDirectory.FullName);
string[] xmlFileNames = Directory.GetFiles(runningDirectory.FullName, "*.xml", SearchOption.AllDirectories);
string xmlFileName = xmlFileNames[ConsoleHelper.Selection(xmlFileNames, "Choose you library xml file: ")];
Library library = RekordboxHelper.GetLibrary(xmlFileName);
ConsoleHelper.WriteLine($"The library is from {library.Product?.Name} version {library.Product?.Version} and contains {library.Collection?.Entries} tracks.");