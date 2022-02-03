using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetPrintScreenWPF.Services
{
    internal class Files
    {
        public static string ExtractName(string wwwPath)
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
    }
}
