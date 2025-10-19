using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIFolderFocker.Shared.Services.CryptoLogic.Faces
{
    public interface IDecryptResult
    {
        bool Success { get; set; }
        string? ErrorMessage { get; set; }
        string SuccessMessage { get; set; }
    }
}
