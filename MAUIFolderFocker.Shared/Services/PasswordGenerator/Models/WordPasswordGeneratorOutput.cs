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
            int includesUppercaseLength = -1,
            int includesUppercaseSymbols = -1,
            int icludesNumbersLength = -1,
            int includesSymbolsLength = -1,
            int passwordWords = -1,
            bool includesFirstLetersUpercase = false,
            int includesFirstLetersUpercaseLength = -1,
            long generationTimeMs = 0,
            string errorMessage = ""

            )
        {
            this.NumberOfWords = numberOfWords;
            this.GeneratedPassword = generatedPassword;
            this.PasswordSeperator = passwordSeperator;
            this.UppercaseLength = includesUppercaseLength;
            this.NumbersLength = icludesNumbersLength;
            this.SymbolsLength = includesSymbolsLength;
            this.FirstLetersUpercaseLength = includesFirstLetersUpercaseLength;
            GenerationTimeMs = generationTimeMs;
            ErrorMessage = errorMessage;
        }
        public WordPasswordGeneratorOutput
            (
            WordPasswordGeneratorInput input,
            string generatedPassword = "",
            long generationTimeMs = -1,
            string errorMessage = ""
            )
        {
            this.NumberOfWords = input.NumberOfWords;
            this.GeneratedPassword = generatedPassword;
            this.PasswordSeperator = input.PasswordSeperator;
            this.UppercaseLength = input.IncludeUppercaseLength;
            this.SymbolsLength = input.IncludeSymbolsLength;
            this.FirstLetersUpercaseLength = input.IncludeFirstLetersUpercaseLength;
            this.IncludeLowercaseLength = input.IncludeLowercaseLength;
            GenerationTimeMs = generationTimeMs;
            this.ErrorMessage = errorMessage;
        }

        public int NumberOfWords { get; set; }
        public string PasswordSeperator { get; set; }
        public string GeneratedPassword { get; set; }
        public bool IncludesUppercase { get; set; }
        public int UppercaseLength { get; set; }
        public int IncludeLowercaseLength { get; set; }
        public int NumbersLength { get; set; }
        public int SymbolsLength { get; set; }
        public int FirstLetersUpercaseLength { get; set; }
        public int IncludeUppercaseLength { get; set; }
        public int IncludeNumbersLength { get; set; }
        public int IncludeSymbolsLength { get; set; }
        public int IncludeFirstLetersUpercaseLength { get; set; }
        public long GenerationTimeMs { get; set; }
        public string ErrorMessage { get; set; }

        public WordPasswordGeneratorOutput Rerturn()
        {
            return this;
        }
    }
}
