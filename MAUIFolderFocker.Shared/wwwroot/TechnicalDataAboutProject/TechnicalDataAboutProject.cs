using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIFolderFocker.Shared.wwwroot.TechnicalDataAboutProject
{
    public class TechnicalDataAboutProject
    {
        public static string GetTechnicalData()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Project Name: MAUIFolderFocker");
            sb.AppendLine("Version: 1.0.0");
            sb.AppendLine("Target Framework: .NET 9.0");
            sb.AppendLine("C# Language Version: 13.0");
            sb.AppendLine("Description: A cross-platform file encryption and decryption application using MAUI.");
            sb.AppendLine("Author: Your Name");
            sb.AppendLine("License: MIT License");
            sb.AppendLine("\n\n I have used:");
            sb.AppendLine("");
            return sb.ToString();
        }




    }
}
