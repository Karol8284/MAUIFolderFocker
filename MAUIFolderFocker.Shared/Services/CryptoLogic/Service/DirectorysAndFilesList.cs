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
        public List<FileClass> Files { get; set; }

        FileClass fileClass;
        DirectoryClass directoryClass = new();

        public long IdCount = 0;
        public DirectorysAndFilesList()
        {

        }
        public void AddFile(string path)
        {
            fileClass = new FileClass(IdCount++,path);
            Files.Add(fileClass);
        }
        public void AddFile(string path, string fileName,string extenction, string directoryPath, long size)
        {
            fileClass = new FileClass(IdCount++,path,fileName,extenction,directoryPath,size);
            Files.Add(fileClass);
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
