using MAUIFolderFocker.Shared.Service.CryptoLogic.Service;
using MAUIFolderFocker.Shared.Services.CryptoLogic.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIFolderFocker.Shared.Service.CryptoLogic.Facade
{
    public interface IDecryptFace
    {
        //public byte[] Decrypt(byte[] data, DecryptionOptions options);
        public byte[] Decrypt(byte[] data, DataToDecryptAfterEncrypt options, string password);
    }
}
