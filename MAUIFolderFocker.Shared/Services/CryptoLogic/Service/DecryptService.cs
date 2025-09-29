using MAUIFolderFocker.Shared.Service.CryptoLogic.Models;
using MAUIFolderFocker.Shared.Service.IO.Services;
using MAUIFolderFocker.Shared.Services.CryptoLogic.Service;
using MAUIFolderFocker.Shared.Services.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.AspNetCore.Components.Web;

namespace MAUIFolderFocker.Shared.Service.CryptoLogic.Service
{
    public class DecryptService
    {
        EncryptionOptions EncryptionOptions { get; set; } = new();
        private EncryptionOptions decryptOptions = new();
        private ChaCha20Poly1305Decrypt chaCha20 = new();
        private FileEdit fileEdit = new();
        private List<DecryptResult> decryptResult = new();

        private byte[] EncryptedData{ get; set; }
        private byte[] ResultOfDecryptedData{ get; set; }

        //private string Password { get; set; }
        private string FileName { get; set; }
        private byte[] FileDataw { get; set; }
        private byte[] EncryptResult { get; set; }
        private string FileHead { get; set; } = string.Empty;
        private string SaveDirectory { get; set; } = string.Empty;

        private DataToDecryptAfterEncrypt dataToDecrypt = new();


        public DecryptService() { }

        public async Task<List<DecryptResult>> Decrypt
            (List<DirectoryClass> directories, List<FileClass> files, ModelOptions model,
            string savePath, string DirectoryPath, string Password)
        {
            Console.WriteLine("DecryptService - Encrypt - Start");
            System.Diagnostics.Debug.WriteLine("DecryptService - Encrypt - Start");

            SaveDirectory = Path.Combine(savePath, DirectoryPath);

            decryptResult.Clear(); // czyść listę na początku, jeśli to pole klasy
            if (ModelOptions.ChaCha20 == model)
            {
                foreach (FileClass file in files)
                {
                    System.Diagnostics.Debug.WriteLine("DecryptService Encrypt CHaCha20:" + file);
                    var result = await DecryptFileByChaChaPoly1305(file, SaveDirectory, Password);
                    decryptResult.Add(result); // dodaj rezultat do listy
                }
            }
            else if (ModelOptions.Aes == model)
            {

            }
            return decryptResult;
        }
        private Task<DecryptResult> DecryptFileByChaChaPoly1305(FileClass file, string directoryPath, string password)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("DecryptService DecryptFileByChaChaPoly1305 ___ 1");
                if (!File.Exists(file.Path))
                {
                    System.Diagnostics.Debug.WriteLine($"ERROR EncryptService DecryptFileByChaChaPoly1305 File not found: {file.Path} , {File.Exists(file.Path)}");
                    return Task.FromResult(new DecryptResult { Success = false, ErrorMessage = "File not found." });

                }
                if (!CheckPassword(password))
                {
                    System.Diagnostics.Debug.WriteLine($"ERROR EncryptService EncryptFileByChaChaPoly1305 Password: {password}");
                    return Task.FromResult(new DecryptResult { Success = false, ErrorMessage = "Error: Password is too short or something else." });

                }
                System.Diagnostics.Debug.WriteLine("DecryptService DecryptFileByChaChaPoly1305 ___ 2");

                if (!Directory.Exists(directoryPath))
                    Directory.CreateDirectory(directoryPath);


                System.Diagnostics.Debug.WriteLine($"DecryptService DecryptFileByChaChaPoly1305 ___ 3");

                using FileStream fs = new(file.Path, FileMode.Open, FileAccess.Read);
                using StreamReader sr = new(fs, Encoding.UTF8, leaveOpen: true);
                FileHead = sr.ReadLine();
                dataToDecrypt = JsonSerializer.Deserialize<DataToDecryptAfterEncrypt>(FileHead);

                long remaining = fs.Length - fs.Position;
                EncryptedData = new byte[remaining];
                fs.Read(EncryptedData, 0, (int)remaining);

                ResultOfDecryptedData = chaCha20.Decrypt(EncryptedData, dataToDecrypt,password);

                string fileSavePath = fileEdit.FindAvailableFileName(directoryPath, dataToDecrypt.File_Original_Name, dataToDecrypt.File_Original_Extension);
                fileEdit.Write(fileSavePath, ResultOfDecryptedData, true);

                return Task.FromResult(new DecryptResult
                {
                    Success = true,
                    SuccessMessage = $"File encrypted successfully. [File Save Path: {fileSavePath}]"
                });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new DecryptResult { Success = false, ErrorMessage = $"Exception: {ex.Message}" });
            }
        }
        private bool CheckPassword(string password)
        {
            if (string.IsNullOrEmpty(password) || password.Length < 3)
            {
                System.Diagnostics.Debug.WriteLine($"ERROR Password: {password} |EncryptService|");
                return false;
            }
            return true;
        }
    }
}
