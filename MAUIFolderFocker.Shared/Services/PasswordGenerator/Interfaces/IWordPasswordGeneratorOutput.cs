using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIFolderFocker.Shared.Services.PasswordGenerator.Faces
{
    public interface IWordPasswordGeneratorOutput
    {
        public string GeneratedPassword { get; set; }
        public bool IncludesUppercase { get; set; }
        public int IncludesUppercaseLength { get; set; }
        public bool IncludesNumbers { get; set; }
        public int IcludesNumbersLength { get; set; }
        public bool IncludesSymbols { get; set; }
        public int IncludesSymbolsLength { get; set; }
        public int PasswordWords { get; set; }
        public bool IncludesFirstLetersUpercase { get; set; }
        public int IncludesFirstLetersUpercaseLength { get; set; }
    }
}
