using MAUIFolderFocker.Shared.IO.Elements;
using MAUIFolderFocker.Shared.Services.CryptoLogic.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIFolderFocker.Shared.Services.CryptoLogic.Service
{
    internal class DirectorysAndFilesList
    {
        public List<DirectoryClass> Directorys { get; set; }
        public List<FileCryptoLogic> Files { get; set; }

        FileCryptoLogic fileCryptoLogic;
        DirectoryClass directoryClass = new();

        public long IdCount = 0;
        public DirectorysAndFilesList()
        {

        }
        public void AddFile(string path)
        {
            fileCryptoLogic = new FileCryptoLogic(IdCount++,path);
            Files.Add(fileCryptoLogic);
        }
        public void AddFile(string path, string fileName,string extenction, string directoryPath, long size)
        {
            fileCryptoLogic = new FileCryptoLogic(IdCount++,path,fileName,extenction,directoryPath,size);
            Files.Add(fileCryptoLogic);
        }
        public void AddDirectory(string path)
        {
            directoryClass = new(IdCount++, path);
            Directorys.Add(directoryClass);
        }
        public void AddDirectory(string path,string directoryName)
        {
            directoryClass = new(IdCount++, path, directoryName);
            Directorys.Add(directoryClass);
        }
    }
}
