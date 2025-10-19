using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIFolderFocker.Shared.Services.CryptoLogic.Service
{
    public class EncryptionResultObject
    {
        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }
        public byte[] Nonce { get; set; }
        public byte[] Add { get; set; }
        public byte[] Ciphertext { get; set; }
        public byte[] Tag { get; set; }
    }
}
