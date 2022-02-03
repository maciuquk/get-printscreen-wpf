using System.IO;

namespace GetPrintScreenWPF.Services
{
    internal class Files
    {
        internal static string ExtractName(string wwwPath)
        {
            var parts = wwwPath.Split('/');
            var name = parts[2].Split('.');

            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] == "www")
                {
                    return name[i + 1];
                }
            }
            return name[0];
        }

        internal static void CreateFolder(string directoryPath)
        {
            Directory.CreateDirectory(directoryPath);
        }

        internal static void OpenFolder(string folderPath)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.FileName = folderPath;
            process.StartInfo.Arguments = @" ";
            process.Start();
        }
    }
}
