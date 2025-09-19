using MAUIFolderFocker.Shared.Service.CryptoLogic.Facade;
using MAUIFolderFocker.Shared.Service.CryptoLogic.Service;
using NSec.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MAUIFolderFocker.Shared.Service.CryptoLogic.Models
{
    public class ChaCha20Poly1305Decrypt : IDecryptFace
    {
        private readonly KeyDerivationService keyDerivationService;
        public byte[] Decrypt(byte[] data, DecryptionOptions options)
        {
            if(string.IsNullOrWhiteSpace(options.Password))
                throw new ArgumentNullException(nameof(options.Password), "Password cannot be null or empty.");
            if(options.Salt == null || options.Salt.Length != 16)
                throw new ArgumentException("Salt must be a byte array of length 16.", nameof(options.Salt));
            if(options.Nonce == null || options.Nonce.Length != 12)
                throw new ArgumentException("Nonce must be a byte array of length 12.", nameof(options.Nonce));

            byte[] keyBytes = keyDerivationService.DeriveKey(options.Password, options.Salt, 32, 100_000);

            var algorytm = new NSec.Cryptography.ChaCha20Poly1305();

            using var key = Key.Import(algorytm, keyBytes, KeyBlobFormat.RawSymmetricKey);
            byte[] plainText = new byte[data.Length - algorytm.TagSize];

            bool ok = algorytm.Decrypt(key, options.Nonce, ReadOnlySpan<byte>.Empty, data, plainText);

            if (!ok)
            {
                throw new CryptographicException("Authentication failed: wrong password, salt, or nonce.");
            }
            return plainText;
        }
    }
}
