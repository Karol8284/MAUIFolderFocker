using MAUIFolderFocker.Shared.Services.PasswordGenerator.Faces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIFolderFocker.Shared.Services.PasswordGenerator.Models
{
    public class PasswordGeneratorOutput : IPasswordGeneratorOutput
    {
        public string GeneratedPassword { get; set; }
        public bool IncludesUppercase { get; set; }
        public bool IncludesNumbers { get; set; }
        public bool IncludesSymbols { get; set; }
        public int PasswordLength { get; set; }
        public long GenerationTimeMs { get; set; }
        public string ErrorMessage { get; set; }
        public PasswordGeneratorOutput
            (
            string generatedPassword = "",
            long generationTimeMs = -1,
            int passwordLength = -1,
            bool includesUppercase = false,
            bool includesNumbers = false,
            bool includesSymbols = false,
            string errorMessage = ""
            ) 
        {
            this.GeneratedPassword = generatedPassword;
            this.PasswordLength = passwordLength;
            this.IncludesUppercase = includesUppercase;
            this.IncludesNumbers = includesNumbers;
            this.IncludesSymbols = includesSymbols;
            this.GenerationTimeMs = generationTimeMs;
            this.ErrorMessage = errorMessage;
        }
        public PasswordGeneratorOutput
            (
            PasswordGeneratorInput input,
            string generatedPassword = "",
            long generationTimeMs = -1,
            string errorMessage = ""
            )
        {
            this.GeneratedPassword = generatedPassword;
            this.PasswordLength = input.PasswordLength;
            this.IncludesUppercase = input.IsIncludeUppercase;
            this.IncludesNumbers = input.IsIncludeNumbers;
            this.IncludesSymbols = input.IsIncludeSymbols;
            this.GenerationTimeMs = generationTimeMs;
            this.ErrorMessage = string.Empty;
        }
        public PasswordGeneratorOutput Rerturn()
        {
            return this;
        }
    }
}
