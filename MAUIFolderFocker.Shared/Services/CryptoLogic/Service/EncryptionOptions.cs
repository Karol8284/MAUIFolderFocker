using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MAUIFolderFocker.Shared.Service.CryptoLogic.Service
{
    public class EncryptionOptions
    {
        //public string Text { get; set; }
        //public string result { get; set; }

        public byte[] Key { get; set; }
        public string Password { get; set; }
        public byte[] Salt { get; set; }
        public byte[] Nonce { get; set; }
        public int ChunkSize { get; set; } = 64 * 1024;
        public byte[] Text { get; set; }
        public byte[] AssociateData { get; set; }


        public byte[] GenerateSalt()
        {
            return Salt = RandomNumberGenerator.GetBytes(16);

        }
        public byte[] GenerateNonce()
        {
            return Nonce = RandomNumberGenerator.GetBytes(16);
        }
    }
}
