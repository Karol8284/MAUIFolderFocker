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
        public bool IsIncludeUppercase { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int IncludeUppercaseLength { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsIncludeNumbers { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int IncludeNumbersLength { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsIncludeSymbols { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int IncludeSymbolsLength { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int NumberOfWords { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsIncludeFirstLetersUpercase { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int IncludeFirstLetersUpercaseLength { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string PasswordSeperator { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public WordPasswordGeneratorInput
            (
            string passwordSeperator = " ",
            bool isIncludeUppercase = false,
            int includeUppercaseLength = -1,
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
            this.IsIncludeUppercase = isIncludeUppercase;
            this.IncludeUppercaseLength = includeUppercaseLength;
            this.IsIncludeNumbers = isIncludeNumbers;
            this.IncludeNumbersLength = includeNumbersLength;
            this.IsIncludeSymbols = isIncludeSymbols;
            this.IncludeSymbolsLength = includeSymbolsLength;
            this.NumberOfWords = passwordWords;
            this.IsIncludeFirstLetersUpercase = isIncludeFirstLetersUpercase;
            this.IncludeFirstLetersUpercaseLength = includeFirstLetersUpercaseLength;
        }
        public WordPasswordGeneratorInput Rerturn()
        {
            return this;
        }
    }
}
