using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIFolderFocker.Shared.Services.PasswordGenerator.Faces
{
    public interface IPasswordGeneratorInput
    {
        public int PasswordLength { get; set; }
        public bool IsIncludeUppercase { get; set; }
        public bool IsIncludeNumbers { get; set; }
        public bool IsIncludeSymbols { get; set; }
    }
}
