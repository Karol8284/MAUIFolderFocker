using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIFolderFocker.Shared.Services.CryptoLogic.Service
{
    public class DataToDecryptAfterEncrypt
    {
        public string File_Original_Name { get; set; }
        public string File_Original_Extension { get; set; }
        public byte[] PBKDF2_Salt { get; set; }
        //public byte[] PBKDF2_Iterations { get; set; }
        //public byte[] PBKDF2_Hash { get; set; }
        public byte[] Algorithm_Nonce { get; set; }
        public byte[] Algorithm_Add { get; set; }
        /// <summary>
        /// Algorithm_Ciphertext includes the authentication tag at the end of the ciphertext for algorithms like ChaCha20-Poly1305
        /// </summary>
        //public byte[] Algorithm_Ciphertext { get; set; }   
        public DataToDecryptAfterEncrypt() { }
    
    }
}
