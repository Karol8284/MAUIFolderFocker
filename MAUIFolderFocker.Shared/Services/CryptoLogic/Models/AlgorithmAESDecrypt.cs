using MAUIFolderFocker.Shared.Service.CryptoLogic.Facade;
using MAUIFolderFocker.Shared.Services.CryptoLogic.Service;
using MAUIFolderFocker.Shared.Services.PasswordGenerator.Services;
using System;
using System.Diagnostics;
using System.Security.Cryptography;

namespace MAUIFolderFocker.Shared.Services.CryptoLogic.Models
{
    public class AlgorithmAESDecrypt : IDecryptFace
    {
        private readonly KeyDerivationService _keyDerivationService = new();

        /// <summary>
        /// data = ciphertext
        /// options = metadane wygenerowane przy szyfrowaniu (salt, nonce, tag)
        /// password = hasło użyte do DeriveKey
        /// </summary>
        public byte[] Decrypt(byte[] data, DataToDecryptAfterEncrypt options, string password)
        {
            if (data == null || data.Length == 0)
                throw new ArgumentNullException(nameof(data), "Ciphertext jest null lub pusty.");

            if (options == null)
                throw new ArgumentNullException(nameof(options));

            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException(nameof(password));

            if (options.PBKDF2_Salt == null || options.PBKDF2_Salt.Length < 16)
                throw new ArgumentException("Salt jest niepoprawny lub za krótki.", nameof(options.PBKDF2_Salt));

            if (options.Algorithm_Nonce == null || options.Algorithm_Nonce.Length != 12)
                throw new ArgumentException("Nonce musi mieć 12 bajtów (AES-GCM standard).", nameof(options.Algorithm_Nonce));

            if (options.Tag == null || options.Tag.Length != 16)
                throw new ArgumentException("Tag musi mieć 16 bajtów (128 bitów).", nameof(options.Tag));

            // Odzyskaj klucz
            byte[] keyBytes = _keyDerivationService.DeriveKey(password, options.PBKDF2_Salt);

            // Przygotuj output
            byte[] plaintext = new byte[data.Length];

            try
            {
                using (var aes = new AesGcm(keyBytes))
                {
                    // Ta linia może rzucić CryptographicException jeżeli tag nie pasuje
                    aes.Decrypt(options.Algorithm_Nonce, data, options.Tag, plaintext, associatedData: null);
                }

                return plaintext;
            }
            catch (CryptographicException cex)
            {
                // tag/jej integralność nie przeszła — informuj wyraźnie
                Debug.WriteLine($"AlgorithmAESDecrypt: CryptographicException: {cex.Message}");
                // bezpieczne wyczyszczenie plaintextu zanim wyrzucimy
                Array.Clear(plaintext, 0, plaintext.Length);
                throw; // przekaż dalej aby caller zdecydował co zrobić
            }
            finally
            {
                // wyczyść klucz z pamięci
                if (keyBytes != null)
                    Array.Clear(keyBytes, 0, keyBytes.Length);
            }
        }
    }
}
