using MAUIFolderFocker.Shared.Services.PasswordGenerator.Faces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIFolderFocker.Shared.Services.PasswordGenerator.Models
{
    public class WordPasswordGeneratorOutput : IWordPasswordGeneratorOutput
    {
        public WordPasswordGeneratorOutput
            (
            string generatedPassword = "",
            int numberOfWords = -1,
            string passwordSeperator = "",
            bool includesUppercase = false,
            int includesUppercaseLength = -1,
            bool includeLowercase = false,
            int includesUppercaseSymbols = -1,
            bool includesNumbers = false,
            int icludesNumbersLength = -1,
            bool includesSymbols = false,
            int includesSymbolsLength = -1,
            int passwordWords = -1,
            bool includesFirstLetersUpercase = false,
            int includesFirstLetersUpercaseLength = -1,
            long generationTimeMs = 0

            )
        {
            this.NumberOfWords = numberOfWords;
            this.GeneratedPassword = generatedPassword;
            this.PasswordSeperator = passwordSeperator;
            this.IncludesUppercase = includesUppercase;
            this.IncludesUppercaseLength = includesUppercaseLength;
            this.IncludesNumbers = includesNumbers;
            this.IcludesNumbersLength = icludesNumbersLength;
            this.IncludesSymbols = includesSymbols;
            this.IncludesSymbolsLength = includesSymbolsLength;
            this.IncludesFirstLetersUpercase = includesFirstLetersUpercase;
            this.IncludesFirstLetersUpercaseLength = includesFirstLetersUpercaseLength;
            GenerationTimeMs = generationTimeMs;
        }
        public WordPasswordGeneratorOutput
            (
            WordPasswordGeneratorInput input,
            string generatedPassword = "",
            long generationTimeMs = -1
            )
        {
            this.NumberOfWords = input.NumberOfWords;
            this.GeneratedPassword = generatedPassword;
            this.PasswordSeperator = input.PasswordSeperator;
            this.IncludesUppercase = input.IncludeUppercase;
            this.IncludesUppercaseLength = input.IncludeUppercaseLength;
            this.IncludesNumbers = input.IncludeNumbers;
            this.IcludesNumbersLength = input.IncludeNumbersLength;
            this.IncludesSymbols = input.IncludeSymbols;
            this.IncludesSymbolsLength = input.IncludeSymbolsLength;
            this.IncludesFirstLetersUpercase = input.IncludeFirstLetersUpercase;
            this.IncludesFirstLetersUpercaseLength = input.IncludeFirstLetersUpercaseLength;

        }

        public int NumberOfWords { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string PasswordSeperator { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string GeneratedPassword { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IncludesUppercase { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int IncludesUppercaseLength { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IncludeLowercase { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int IncludeLowercaseLength { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IncludesNumbers { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int IcludesNumbersLength { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IncludesSymbols { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int IncludesSymbolsLength { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IncludesFirstLetersUpercase { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int IncludesFirstLetersUpercaseLength { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IncludeUppercase { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int IncludeUppercaseLength { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IncludeNumbers { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int IncludeNumbersLength { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IncludeSymbols { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int IncludeSymbolsLength { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IncludeFirstLetersUpercase { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int IncludeFirstLetersUpercaseLength { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public long GenerationTimeMs { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public WordPasswordGeneratorOutput Rerturn()
        {
            return this;
        }
    }
}
