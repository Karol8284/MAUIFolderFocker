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
        public bool IsIncludeUppercase { get; set; }
        public bool IsIncludeLowercase { get; set; }
        public bool IsIncludeNumbers { get; set; }
        public bool IsIncludeSymbols { get; set; }
        public int PasswordLength { get; set; }

        //public PasswordGeneratorInput()
        //{
        //    this.IsIncludeUppercase = true;
        //    this.IsIncludeLowercase = true;
        //    this.IsIncludeNumbers = true;
        //    this.IsIncludeSymbols = true;
        //}

        public PasswordGeneratorInput
            (
            bool isIncludeUppercase = true,
            bool isIncludeLowercase = true,
            bool isIncludeNumbers = true,
            bool isIncludeSymbols = true,
            int passwordLength = -1
            )
        {
            this.IsIncludeUppercase = isIncludeUppercase;
            this.IsIncludeLowercase = isIncludeLowercase;
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
