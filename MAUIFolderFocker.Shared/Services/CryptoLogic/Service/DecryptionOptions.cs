using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIFolderFocker.Shared.Service.CryptoLogic.Service
{
    public class DecryptionOptions
    {
        //public string Text { get; set; }
        //public string result { get; set; }

        public byte[] Key { get; set; }
        public string Password { get; set; }
        public byte[] Salt{ get; set; }
        public byte[] Nonce { get; set; }
        public int ChunkSize { get; set; } = 64 * 1024;
        

    }
}
