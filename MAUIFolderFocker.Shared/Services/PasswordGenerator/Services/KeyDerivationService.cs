using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MAUIFolderFocker.Shared.Services.PasswordGenerator.Services
{
    internal class KeyDerivationService
    {
        //Rfc2898DeriveBytes rfc;
        public byte[] DeriveKey(string password, byte[] salt,int keySize =32, int iterations = 100_000)
        {
            if (salt == null || salt.Length < 16)
            {
                salt = RandomNumberGenerator.GetBytes(16);
            }
            var kdf = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256);
            return kdf.GetBytes(keySize);
        }

        public static byte[] GenerateDatabaseKey(string login="", string password="", string? pin = null)
        {
            var salt = SHA256.HashData(Encoding.UTF8.GetBytes(login)); 
            var passwordConbine = password + (pin ?? "");
            var kdf = new Rfc2898DeriveBytes(passwordConbine, salt, 100_000, HashAlgorithmName.SHA3_256);
            return kdf.GetBytes(32);
        }
    }
}
