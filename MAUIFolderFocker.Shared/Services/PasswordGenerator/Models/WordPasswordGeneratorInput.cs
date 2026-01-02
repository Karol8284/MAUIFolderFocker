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
        public int IncludeUppercaseLength { get; set; }
        public int IncludeNumbersLength { get; set; }
        public int IncludeSymbolsLength { get; set; }
        public int IncludeFirstLetersUpercaseLength { get; set; }
        public string PasswordSeperator { get; set; }
        public int IncludeLowercaseLength { get; set; }
        public int NumberOfWords { get; set; }
        public WordPasswordGeneratorInput()
        {
            this.PasswordSeperator = "_";
            this.IncludeUppercaseLength = 0;
            this.IncludeLowercaseLength = 0;
            this.IncludeNumbersLength = 0;
            this.IncludeSymbolsLength = 0;
            this.NumberOfWords = 5;
            this.IncludeFirstLetersUpercaseLength = 0;
        }

        public WordPasswordGeneratorInput
            (
            string passwordSeperator = "_",
            int includeUppercaseLength = -1,
            int includeLowercaseLength = -1,
            int includeNumbersLength = -1,
            int includeSymbolsLength = -1,
            int passwordWords = -1,
            int includeFirstLetersUpercaseLength = -1
            )
        {
            this.PasswordSeperator = passwordSeperator;
            this.IncludeUppercaseLength = includeUppercaseLength;
            this.IncludeNumbersLength = includeNumbersLength;
            this.IncludeSymbolsLength = includeSymbolsLength;
            this.NumberOfWords = passwordWords;
            this.IncludeFirstLetersUpercaseLength = includeFirstLetersUpercaseLength;
        }
        public WordPasswordGeneratorInput Rerturn()
        {
            return this;
        }
    }
}
