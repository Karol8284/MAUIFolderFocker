using MAUIFolderFocker.Shared.Service.CryptoLogic.Facade;
using MAUIFolderFocker.Shared.Service.CryptoLogic.Service;
using MAUIFolderFocker.Shared.Services.CryptoLogic.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIFolderFocker.Shared.Services.CryptoLogic.Faces
{
    public interface IAlgorithmUse : IEncryptFace, IDecryptFace 
    {
        public EncryptionResultObject Encrypt(byte[] data, EncryptionOptions options);
        public byte[] Decrypt(byte[] data, DataToDecryptAfterEncrypt options, string password);
    }
}
