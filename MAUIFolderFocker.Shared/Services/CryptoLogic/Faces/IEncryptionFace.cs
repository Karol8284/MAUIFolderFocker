using MAUIFolderFocker.Shared.Service.CryptoLogic.Service;
using MAUIFolderFocker.Shared.Services.CryptoLogic.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIFolderFocker.Shared.Service.CryptoLogic.Facade
{
    public interface IEncryptionFace
    {
        public EncryptionResultObject Encrypt(byte[] data, EncryptionOptions options);
    }
}
