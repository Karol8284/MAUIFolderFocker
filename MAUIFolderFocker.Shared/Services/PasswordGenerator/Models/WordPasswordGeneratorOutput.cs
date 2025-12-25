using MAUIFolderFocker.Shared.Services.PasswordGenerator.Faces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIFolderFocker.Shared.Services.PasswordGenerator.Models
{
    internal class WordPasswordGeneratorOutput : IWordPasswordGeneratorOutput
    {
        public string GeneratedPassword { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IncludesUppercase { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int IncludesUppercaseLength { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IncludesNumbers { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int IcludesNumbersLength { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IncludesSymbols { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int IncludesSymbolsLength { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int PasswordWords { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IncludesFirstLetersUpercase { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int IncludesFirstLetersUpercaseLength { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    
        public WordPasswordGeneratorOutput
            (
            string generatedPassword = "",
            bool includesUppercase = false,
            int includesUppercaseLength = -1,
            bool includesNumbers = false,
            int icludesNumbersLength = -1,
            bool includesSymbols = false,
            int includesSymbolsLength = -1,
            int passwordWords = -1,
            bool includesFirstLetersUpercase = false,
            int includesFirstLetersUpercaseLength = -1
            )
        {
            this.GeneratedPassword = generatedPassword;
            this.IncludesUppercase = includesUppercase;
            this.IncludesUppercaseLength = includesUppercaseLength;
            this.IncludesNumbers = includesNumbers;
            this.IcludesNumbersLength = icludesNumbersLength;
            this.IncludesSymbols = includesSymbols;
            this.IncludesSymbolsLength = includesSymbolsLength;
            this.PasswordWords = passwordWords;
            this.IncludesFirstLetersUpercase = includesFirstLetersUpercase;
            this.IncludesFirstLetersUpercaseLength = includesFirstLetersUpercaseLength;
        }
        public WordPasswordGeneratorOutput Rerturn()
        {
            return this;
        }
    }
}
