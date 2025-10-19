using MAUIFolderFocker.Shared.IO.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIFolderFocker.Shared.IO.Services
{
    public class FolderObject
    {
        public FolderObject() { }
        public string Path { get; set; }
        public string FolderName { get; set; }
        public int FileCount { get; set; }
        public List<FileObject> Files { get; set; } = new List<FileObject>();
        public List<FolderObject> Folders { get; set; } = new List<FolderObject>();
    }
}
