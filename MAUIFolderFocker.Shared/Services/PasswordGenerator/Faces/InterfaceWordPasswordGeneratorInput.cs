using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIFolderFocker.Shared.Services.PasswordGenerator.Faces
{
    public interface InterfaceWordPasswordGeneratorInput
    {
        public bool IsIncludeUppercase { get; set; }
        public int IncludeUppercaseLength { get; set; }
        public bool IsIncludeNumbers { get; set; }
        public int IncludeNumbersLength { get; set; }
        public bool IsIncludeSymbols { get; set; }
        public int IncludeSymbolsLength { get; set; }
        public int PasswordWords { get; set; }
        public bool IsIncludeFirstLetersUpercase{ get; set; }
        public int IncludeFirstLetersUpercaseLength { get; set; }

    }
}
