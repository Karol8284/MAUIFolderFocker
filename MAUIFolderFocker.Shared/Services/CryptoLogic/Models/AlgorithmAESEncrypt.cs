using MAUIFolderFocker.Shared.Service.CryptoLogic.Facade;
using MAUIFolderFocker.Shared.Service.CryptoLogic.Service;
using MAUIFolderFocker.Shared.Services.CryptoLogic.Service;
using MAUIFolderFocker.Shared.Services.PasswordGenerator.Services;
using NSec.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MAUIFolderFocker.Shared.Services.CryptoLogic.Models
{
    public class AlgorithmAESEncrypt : IEncryptFace
    {
        public AlgorithmAESEncrypt(){}
        KeyDerivationService keyDerivationService =new();

        public EncryptionResultObject Encrypt(byte[] data, EncryptionOptions options)
        {
            if (string.IsNullOrWhiteSpace(options.Password))
                throw new ArgumentNullException(nameof(options.Password), "Password is null or empty");

            if (options.Salt == null || options.Salt.Length < 16)
                options.Salt = options.GenerateSalt();

            if (options.Nonce == null || options.Nonce.Length != 12)
                options.Nonce = RandomNumberGenerator.GetBytes(12); // GCM standard
            try
            {

                byte[] keyBytes = keyDerivationService.DeriveKey(options.Password, options.Salt);
                byte[] ciphertext = new byte[data.Length];
                byte[] tag = new byte[16];

                using (var aes = new AesGcm(keyBytes))
                {
                    aes.Encrypt(options.Nonce, data, ciphertext, tag, options.AssociateData);
                }

                return new EncryptionResultObject
                {
                    Ciphertext = ciphertext,
                    Tag = tag,
                    Nonce = options.Nonce,
                    Salt = options.Salt
                };
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"AlgorithmAESEncrypt Encrypt ERROR: {ex.Message}");
                return null;
            }

        }
    }
}
