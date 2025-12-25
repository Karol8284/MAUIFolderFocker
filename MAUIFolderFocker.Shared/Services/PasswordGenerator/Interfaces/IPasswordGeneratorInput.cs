using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIFolderFocker.Shared.Services.PasswordGenerator.Faces
{
    public interface IPasswordGeneratorInput
    {
        public bool IsIncludeUppercase { get; set; }
        public bool IsIncludeNumbers { get; set; }
        public bool IsIncludeSymbols { get; set; }
        public  int PasswordLength { get; set; }

        // dada AHDIA 231333 / -> length 12 






    }
}
