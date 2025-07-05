using System.IO;

namespace ScheduleMixer.Shared.Core;

public class Tools
{
    public static DirectoryInfo CheckDirectory(string path) => 
        !Directory.Exists(GetPathFromBaseDirectory(path)) ?
            Directory.CreateDirectory(GetPathFromBaseDirectory(path)) : 
            new DirectoryInfo(GetPathFromBaseDirectory(path));
    public static string GetPathFromBaseDirectory(string path) =>
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"LonDevTools/ScheduleMixer/{path}");
}