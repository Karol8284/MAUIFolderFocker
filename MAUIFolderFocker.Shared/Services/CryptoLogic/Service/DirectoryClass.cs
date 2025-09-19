using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIFolderFocker.Shared.Services.CryptoLogic.Service
{
    public class DirectoryClass
    {
        public long Id { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public long ContainElements { get; set; }
        public long Size { get; set; }
        public string Link { get; set; }
        public bool IsEncrypted { get; set; }
        public bool IsSelected { get; set; }

        public DirectoryClass()
        {
        }
        public DirectoryClass(string path)
        {
            DirectoryInfo directoryInfo = new(path);

            if (!directoryInfo.Exists)
            {
                throw new FileNotFoundException("Directory not found", path);
            }
            Id = -1;
            Path = path;
            Name = directoryInfo.Name;
            Link = directoryInfo.LinkTarget;
        }
        public DirectoryClass(long id, string path)
        {
            DirectoryInfo directoryInfo = new(path);
            if (!directoryInfo.Exists)
            {
                throw new FileNotFoundException("Directory not found", path);
            }
            Id = id;
            Path = path;
            Name = directoryInfo.Name;
            Link = directoryInfo.LinkTarget;
        }
        public DirectoryClass(long id, string path, string directoryName)
        {
            DirectoryInfo directoryInfo = new(path);
            if (!directoryInfo.Exists)
            {
                throw new FileNotFoundException("Directory not found", path);
            }
            Id = id;
            Path = path;
            Name = directoryName;
            Link = directoryInfo.LinkTarget;
        }
        public void ToggleSelection()
        {
            IsSelected = !IsSelected;
        }
        //public void ToggleIsEncryption()
        //{
        //    IsEncrypted = !IsEncrypted;
        //}
    }
}
