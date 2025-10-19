using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIFolderFocker.Shared.Services.CryptoLogic.Elements
{
    public class FileCryptoLogic
    {
        public long Id { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public string DirectoryPath { get; set; }
        public long Size { get; set; }
        public bool IsSelected { get; set; }
        public bool IsEncrypted { get; set; }

        public FileCryptoLogic()
        {
        }
        public FileCryptoLogic(string path)
        {
            FileInfo fileInfo = new FileInfo(path);

            if (!fileInfo.Exists)
            {
                throw new FileNotFoundException("File not found", path);
            }
            Id = -1;
            Path = path;
            Name = fileInfo.Name;
            Extension = fileInfo.Extension;
            if (Directory.Exists(fileInfo.DirectoryName)) DirectoryPath = fileInfo.DirectoryName;

            Size = fileInfo.Length; // zamieniać na mb lub na gb
        }
        public FileCryptoLogic(long id, string path)
        {
            FileInfo fileInfo = new FileInfo(path);

            if (!fileInfo.Exists)
            {
                throw new FileNotFoundException("File not found", path);
            }
            Id = id;
            Path = path;
            Name = fileInfo.Name;
            Extension = fileInfo.Extension;

            if (Directory.Exists(fileInfo.DirectoryName)) DirectoryPath = fileInfo.DirectoryName;

            Size = fileInfo.Length; // zamieniać na mb lub na gb
        }
        public FileCryptoLogic(long id, string filePath, string fileName, string extenction, string directoryPath, long size)
        {
            Id = id;
            Path = filePath;
            Name = fileName;
            Extension = extenction;
            DirectoryPath = directoryPath;
            Size = size; // zamieniać na mb lub na gb
        }

        public bool ISEncrypted()
        {
            using var fs = new FileStream(Path, FileMode.Open, FileAccess.Read);
            byte[] header = new byte[4];
            fs.Read(header, 0, 4);

            string magic = Encoding.ASCII.GetString(header);
            return magic == "CHP1"; // Twój magic header
        }
        public void ToggleSelection()
        {
            IsSelected = !IsSelected;
        }
    }
}
