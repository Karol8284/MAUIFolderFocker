using MAUIFolderFocker.Shared.Services.CryptoLogic.Faces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIFolderFocker.Shared.Services.CryptoLogic.Service
{
    public class EncryptResult : IEncryptionResult
    {
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; } = string.Empty;
        public string SuccessMessage { get; set; }
    }
}
