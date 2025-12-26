using MAUIFolderFocker.Shared.Services.PasswordGenerator.Faces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIFolderFocker.Shared.Services.PasswordGenerator.Models
{
    public class WordPasswordGeneratorInput : IWordPasswordGeneratorInput
    {
        public bool IncludeUppercase { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int IncludeUppercaseLength { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IncludeNumbers { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int IncludeNumbersLength { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IncludeSymbols { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int IncludeSymbolsLength { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int NumberOfWords { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IncludeFirstLetersUpercase { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int IncludeFirstLetersUpercaseLength { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string PasswordSeperator { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IncludeLowercase { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int IncludeLowercaseLength { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public WordPasswordGeneratorInput
            (
            string passwordSeperator = " ",
            bool isIncludeUppercase = false,
            int includeUppercaseLength = -1,
            bool includeLowercase = false,
            int includeLowercaseLength = -1,
            bool isIncludeNumbers = false,
            int includeNumbersLength = -1,
            bool isIncludeSymbols = false,
            int includeSymbolsLength = -1,
            int passwordWords = -1,
            bool isIncludeFirstLetersUpercase = false,
            int includeFirstLetersUpercaseLength = -1
            )
        {
            this.PasswordSeperator = passwordSeperator;
            this.IncludeUppercase = isIncludeUppercase;
            this.IncludeUppercaseLength = includeUppercaseLength;
            this.IncludeNumbers = isIncludeNumbers;
            this.IncludeNumbersLength = includeNumbersLength;
            this.IncludeSymbols = isIncludeSymbols;
            this.IncludeSymbolsLength = includeSymbolsLength;
            this.NumberOfWords = passwordWords;
            this.IncludeFirstLetersUpercase = isIncludeFirstLetersUpercase;
            this.IncludeFirstLetersUpercaseLength = includeFirstLetersUpercaseLength;
        }
        public WordPasswordGeneratorInput Rerturn()
        {
            return this;
        }
    }
}
