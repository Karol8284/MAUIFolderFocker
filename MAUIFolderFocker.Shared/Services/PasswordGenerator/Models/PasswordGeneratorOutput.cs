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
        public string GeneratedPassword { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IncludesUppercase { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IncludesNumbers { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IncludesSymbols { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int PasswordLength { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public long GenerationTimeMs { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public PasswordGeneratorOutput
            (
            string generatedPassword = "",
            long generationTimeMs = -1,
            int passwordLength = -1,
            bool includesUppercase = false,
            bool includesNumbers = false,
            bool includesSymbols = false
            ) 
        {
            this.GeneratedPassword = generatedPassword;
            this.PasswordLength = passwordLength;
            this.IncludesUppercase = includesUppercase;
            this.IncludesNumbers = includesNumbers;
            this.IncludesSymbols = includesSymbols;
        }
        public PasswordGeneratorOutput
            (
            PasswordGeneratorInput input,
            string generatedPassword = "",
            long generationTimeMs = -1
            )
        {
            this.GeneratedPassword = generatedPassword;
            this.PasswordLength = input.PasswordLength;
            this.IncludesUppercase = input.IsIncludeUppercase;
            this.IncludesNumbers = input.IsIncludeNumbers;
            this.IncludesSymbols = input.IsIncludeSymbols;
        }
        public PasswordGeneratorOutput Rerturn()
        {
            return this;
        }
    }
}
