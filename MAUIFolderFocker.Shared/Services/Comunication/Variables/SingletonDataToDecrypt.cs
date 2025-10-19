using MAUIFolderFocker.Shared.Services.CryptoLogic.Elements;
using MAUIFolderFocker.Shared.Services.CryptoLogic.Service;
using MAUIFolderFocker.Shared.Services.Variables;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIFolderFocker.Shared.Services.Comunication.Variables
{
    public class SingletonDataToDecrypt
    {
        public List<FileCryptoLogic?>? SelectedFiles { get; set; }
        public string? NewDirectoryName { get; set; }
        public string? SavePath { get; set; }
        public string? Password { get; set; }
        public ModelOptions Model { get; set; }
        //public string? DirectoryPath { get; set; }
    }
}
