using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIFolderFocker.Shared.Service.IO.Services
{
    public class FileObject
    {
        public string Path { get; set; }
        public string FileName { get; set; }
        public byte[] FileContent { get; set; }

        public long FileSize { get; set; }

        public bool Encrypt { get; set; }
        public bool Head { get; set; }
        //public DateTime LastModified { get; set; }
        public FileObject() { }
    }
}
