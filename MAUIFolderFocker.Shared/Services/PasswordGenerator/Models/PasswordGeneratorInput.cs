using MAUIFolderFocker.Shared.Services.PasswordGenerator.Faces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIFolderFocker.Shared.Services.PasswordGenerator.Models
{
    public class PasswordGeneratorInput : IPasswordGeneratorInput
    {
        public bool IsIncludeUppercase { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsIncludeNumbers { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsIncludeSymbols { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int PasswordLength { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public PasswordGeneratorInput
            (
            bool isIncludeUppercase = false,
            bool isIncludeNumbers = false,
            bool isIncludeSymbols = false,
            int passwordLength = -1
            )
        {
            this.IsIncludeUppercase = isIncludeUppercase;
            this.IsIncludeNumbers = isIncludeNumbers;
            this.IsIncludeSymbols = isIncludeSymbols;
            this.PasswordLength = passwordLength;
        }
        public PasswordGeneratorInput Rerturn()
        {
            return this;
        }
    }
}
