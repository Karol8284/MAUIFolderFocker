using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIFolderFocker.Shared.Services.PasswordGenerator.Faces
{
    public interface IPasswordGeneratorOutput
    {
        string GeneratedPassword { get; set; }
        int PasswordLength { get; set; }
        bool IncludesUppercase { get; set; }
        bool IncludesNumbers { get; set; }
        bool IncludesSymbols { get; set; }
    }
}
