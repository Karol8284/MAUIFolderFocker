using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIFolderFocker.Shared.Services.PasswordGenerator.Faces
{
    public interface IWordPasswordGeneratorInput
    {
        public int NumberOfWords { get; set; }
        public bool IncludeUppercase { get; set; }
        public int IncludeUppercaseLength { get; set; }
        public bool IncludeLowercase { get; set; }
        public int IncludeLowercaseLength { get; set; }
        public bool IncludeNumbers { get; set; }
        public int IncludeNumbersLength { get; set; }
        public bool IncludeSymbols { get; set; }
        public int IncludeSymbolsLength { get; set; }
        public bool IncludeFirstLetersUpercase{ get; set; }
        public int IncludeFirstLetersUpercaseLength { get; set; }
        string PasswordSeperator { get; set; }

    }
}
