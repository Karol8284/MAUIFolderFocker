using MAUIFolderFocker.Shared.Service.CryptoLogic.Facade;
using MAUIFolderFocker.Shared.Service.CryptoLogic.Service;
using MAUIFolderFocker.Shared.Services.CryptoLogic.Service;
using NSec.Cryptography;
using System;
using System.Security.Cryptography;

namespace MAUIFolderFocker.Shared.Service.CryptoLogic.Models
{
    public class ChaCha20Poly1305Encrypt : IEncryptionFace
    {
        KeyDerivationService keyDerivationService = new KeyDerivationService();

        private EncryptionResultObject resultObject = new();
        public EncryptionResultObject Encrypt(byte[] data, EncryptionOptions options)
        {
            if(string.IsNullOrWhiteSpace(options.Password))
            {
                throw new ArgumentNullException("Password is null or empty");
            }
            if(options.Salt == null || options.Salt.Length < 16)
            {
                options.Salt = RandomNumberGenerator.GetBytes(16);
            }
            if(options.Nonce == null || options.Nonce.Length != 12)
            {
                options.Nonce = RandomNumberGenerator.GetBytes(12);
            }
            byte[] keyBytes = keyDerivationService.DeriveKey(options.Password, options.Salt);

            var algorithm = new NSec.Cryptography.ChaCha20Poly1305();
            using var key = Key.Import(algorithm, keyBytes, KeyBlobFormat.RawSymmetricKey);
            //using var key = Key.Import(new NSec.Cryptography.ChaCha20Poly1305(), keyBytes, KeyBlobFormat.RawSymmetricKey);

            byte[] add = ReadOnlySpan<byte>.Empty.ToArray(); // Additional authenticated data (AAD), can be empty

            byte[] ciphertext = new byte[data.Length + algorithm.TagSize];

            algorithm.Encrypt(
                key,                       
                options.Nonce,             
                add,  
                data,                      
                ciphertext);

            resultObject.Nonce = options.Nonce;
            resultObject.Salt = options.Salt;
            resultObject.Add = add;
            resultObject.Ciphertext = ciphertext;

            return resultObject;


        }

    }
}
