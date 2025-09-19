using MAUIFolderFocker.Shared.Service.CryptoLogic.Models;
using MAUIFolderFocker.Shared.Service.IO.Services;
using MAUIFolderFocker.Shared.Services.CryptoLogic.Service;
using MAUIFolderFocker.Shared.Services.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MAUIFolderFocker.Shared.Service.CryptoLogic.Service
{
    public class EncryptService
    {
        EncryptionOptions EncryptionOptions { get; set; } = new();
        private EncryptionOptions encryptOptions = new();
        private ChaCha20Poly1305Encrypt chaCha20 = new ChaCha20Poly1305Encrypt();
        private FileEdit fileEdit = new();
        private List<EncryptResult> encryptResult = new();

        //private string Password { get; set; }
        private string FileName { get; set; }
        private byte[] FileData { get; set; }
        private byte[] EncryptResult { get; set; }
        private string FileHead { get; set; }   = string.Empty;
        private string SaveDirectory { get; set; }   = string.Empty;

        private DataToDecryptAfterEncrypt dataToDecrypt = new();

        public EncryptService() { }
        public async Task<List<EncryptResult>> Encrypt(List<DirectoryClass> directories, List<FileClass> files, ModelOptions model, string savePath, string DirectoryPath, string Password)
        {
            Console.WriteLine("EncryptService - Encrypt - Start"); 
            System.Diagnostics.Debug.WriteLine("EncryptService - Encrypt - Start");

            SaveDirectory = Path.Combine(savePath,DirectoryPath);

            encryptResult.Clear(); // czyść listę na początku, jeśli to pole klasy
            if (ModelOptions.ChaCha20 == model)
            {
                foreach (FileClass file in files)
                {
                    System.Diagnostics.Debug.WriteLine("EncryptService Encrypt CHaCha20:" + file);
                    var result = await EncryptFileByChaChaPoly1305(file, SaveDirectory, Password);
                    encryptResult.Add(result); // dodaj rezultat do listy
                }
            }
            else if (ModelOptions.Aes == model)
            {

            }
            return encryptResult;
        }

        private Task<EncryptResult> EncryptFileByChaChaPoly1305(FileClass file, string directoryPath, string password)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("EncryptService EncryptFileByChaChaPoly1305 ___ 1");
                    if (!File.Exists(file.Path))
                    {
                    System.Diagnostics.Debug.WriteLine($"ERROR EncryptService EncryptFileByChaChaPoly1305 File not found: {file.Path} , {File.Exists(file.Path)}");
                        return Task.FromResult(new EncryptResult { Success = false, ErrorMessage = "File not found." });

                    }
                if (!CheckPassword(password))
                {
                    System.Diagnostics.Debug.WriteLine($"ERROR EncryptService EncryptFileByChaChaPoly1305 Password: {password}");
                    return Task.FromResult(new EncryptResult { Success = false, ErrorMessage = "Error: Password is too short or something else." });

                }
                System.Diagnostics.Debug.WriteLine("EncryptService EncryptFileByChaChaPoly1305 ___ 2");

                // Start Set data to dataToDecrypt
                
                // End Set data to dataToDecrypt

                if (!Directory.Exists(directoryPath))
                    Directory.CreateDirectory(directoryPath);

                string fileSavePath = fileEdit.FindAvailableFileName(directoryPath, file.Name, file.Extension);

                System.Diagnostics.Debug.WriteLine($"EncryptService EncryptFileByChaChaPoly1305 ___ 3");

                byte[] fileData = File.ReadAllBytes(file.Path);

                System.Diagnostics.Debug.WriteLine($"EncryptService EncryptFileByChaChaPoly1305 ___ 4| fileData: {fileData.Length}");

                // Start Set data to encryptOptions
                encryptOptions.Password = password;
                encryptOptions.Salt = encryptOptions.GenerateSalt();
                encryptOptions.Nonce = encryptOptions.GenerateNonce();
                // END Set data to encryptOptions

                EncryptionResultObject encryptedObject = chaCha20.Encrypt(fileData, encryptOptions);

                // Start Set data to dataToDecrypt
                dataToDecrypt = new();
                dataToDecrypt.File_Original_Name = file.Name;
                dataToDecrypt.File_Original_Extension = file.Extension;
                dataToDecrypt.PBKDF2_Salt = encryptedObject.Nonce;
                dataToDecrypt.Algorithm_Nonce = encryptedObject.Nonce;
                dataToDecrypt.Algorithm_Add = encryptedObject.Add;
                // End Set data to dataToDecrypt

                //FileHead = $"[HeaderVersion:1] [Algorithm:ChaCha20-Poly1305] [Salt:{Convert.ToBase64String(encryptOptions.Salt)}] [Nonce:{Convert.ToBase64String(encryptOptions.Nonce)}] [ChunkSize:{encryptOptions.ChunkSize}]";
                
                System.Diagnostics.Debug.WriteLine($"EncryptService EncryptFileByChaChaPoly1305 ___ 5| FileHead: {FileHead}");
               
                fileEdit = new FileEdit();


                System.Diagnostics.Debug.WriteLine($"EncryptService EncryptFileByChaChaPoly1305 ___ 6| fileSavePath: {fileSavePath}");
                
                FileHead = JsonSerializer.Serialize(dataToDecrypt);
                fileEdit.Write(fileSavePath, Encoding.UTF8.GetBytes(FileHead + Environment.NewLine), true);

                System.Diagnostics.Debug.WriteLine($"EncryptServusing MAUIFolderFocker.Shared.Service.CryptoLogic.Models;\r\nusing MAUIFolderFocker.Shared.Service.IO.Services;\r\nusing MAUIFolderFocker.Shared.Services.CryptoLogic.Service;\r\nusing MAUIFolderFocker.Shared.Services.Variables;\r\nusing System;\r\nusing System.Collections.Generic;\r\nusing System.Linq;\r\nusing System.Text;\r\nusing System.Threading.Tasks;\r\n\r\nnamespace MAUIFolderFocker.Shared.Service.CryptoLogic.Service\r\n{{\r\n    public class EncryptService\r\n    {{\r\n        EncryptionOptions EncryptionOptions {{ get; set; }} = new();\r\n        private EncryptionOptions encryptOptions = new();\r\n        private ChaCha20Poly1305Encrypt chaCha20 = new ChaCha20Poly1305Encrypt();\r\n        private FileEdit fileEdit = new();\r\n        private List<EncryptResult> encryptResult = new();\r\n\r\n        //private string Password {{ get; set; }}\r\n        private string FileName {{ get; set; }}\r\n        private byte[] FileData {{ get; set; }}\r\n        private byte[] EncryptResult {{ get; set; }}\r\n        private string FileHead {{ get; set; }}   = string.Empty;\r\n        private string SaveDirectory {{ get; set; }}   = string.Empty;\r\n\r\n\r\n        public EncryptService() {{ }}\r\n        public async Task<List<EncryptResult>> Encrypt(List<DirectoryClass> directories, List<FileClass> files, ModelOptions model, string savePath, string DirectoryPath, string Password)\r\n        {{\r\n            Console.WriteLine(\"EncryptService - Encrypt - Start\"); \r\n            System.Diagnostics.Debug.WriteLine(\"EncryptService - Encrypt - Start\");\r\n\r\n            SaveDirectory = Path.Combine(savePath,DirectoryPath);\r\n\r\n            encryptResult.Clear(); // czyść listę na początku, jeśli to pole klasy\r\n            if (ModelOptions.ChaCha20 == model)\r\n            {{\r\n                foreach (FileClass file in files)\r\n                {{\r\n                    System.Diagnostics.Debug.WriteLine(\"EncryptService Encrypt CHaCha20:\" + file);\r\n                    var result = await EncryptFileByChaChaPoly1305(file, SaveDirectory, Password);\r\n                    encryptResult.Add(result); // dodaj rezultat do listy\r\n                }}\r\n            }}\r\n            else if (ModelOptions.Aes == model)\r\n            {{\r\n\r\n            }}\r\n            return encryptResult;\r\n        }}\r\n\r\n        private Task<EncryptResult> EncryptFileByChaChaPoly1305(FileClass file, string directoryPath, string password)\r\n        {{\r\n            try\r\n            {{\r\n                System.Diagnostics.Debug.WriteLine(\"EncryptService EncryptFileByChaChaPoly1305 ___ 1\");\r\n                    if (!File.Exists(file.Path))\r\n                    {{\r\n                    System.Diagnostics.Debug.WriteLine($\"ERROR EncryptService EncryptFileByChaChaPoly1305 File not found: {{file.Path}} , {{File.Exists(file.Path)}}\");\r\n                        return Task.FromResult(new EncryptResult {{ Success = false, ErrorMessage = \"File not found.\" }});\r\n\r\n                    }}\r\n                if (!CheckPassword(password))\r\n                {{\r\n                    System.Diagnostics.Debug.WriteLine($\"ERROR EncryptService EncryptFileByChaChaPoly1305 Password: {{password}}\");\r\n                    return Task.FromResult(new EncryptResult {{ Success = false, ErrorMessage = \"Error: Password is too short or something else.\" }});\r\n\r\n                }}\r\n                System.Diagnostics.Debug.WriteLine(\"EncryptService EncryptFileByChaChaPoly1305 ___ 2\");\r\n\r\n                if (!Directory.Exists(directoryPath))\r\n                    Directory.CreateDirectory(directoryPath);\r\n\r\n                    string fileSavePath = fileEdit.FindAvailableFileName(directoryPath, file.Name, file.Extension);\r\n\r\n                System.Diagnostics.Debug.WriteLine($\"EncryptService EncryptFileByChaChaPoly1305 ___ 3\");\r\n\r\n                byte[] fileData = File.ReadAllBytes(file.Path);\r\n\r\n                System.Diagnostics.Debug.WriteLine($\"EncryptService EncryptFileByChaChaPoly1305 ___ 4| fileData: {{fileData.Length}}\");\r\n\r\n                encryptOptions.Password = password;\r\n                encryptOptions.Salt = encryptOptions.GenerateSalt();\r\n                encryptOptions.Nonce = encryptOptions.GenerateNonce();\r\n\r\n                byte[] encryptedData = chaCha20.Encrypt(fileData, encryptOptions);\r\n\r\n                FileHead = $\"[HeaderVersion:1] [Algorithm:ChaCha20-Poly1305] [Salt:{{Convert.ToBase64String(encryptOptions.Salt)}}] [Nonce:{{Convert.ToBase64String(encryptOptions.Nonce)}}] [ChunkSize:{{encryptOptions.ChunkSize}}]\";\r\n                \r\n                System.Diagnostics.Debug.WriteLine($\"EncryptService EncryptFileByChaChaPoly1305 ___ 5| FileHead: {{FileHead}}\");\r\n               \r\n                fileEdit = new FileEdit();\r\n\r\n\r\n                System.Diagnostics.Debug.WriteLine($\"EncryptService EncryptFileByChaChaPoly1305 ___ 6| fileSavePath: {{fileSavePath}}\");\r\n                \r\n                fileEdit.Write(fileSavePath, Encoding.UTF8.GetBytes(FileHead + Environment.NewLine), true);\r\n\r\n                System.Diagnostics.Debug.WriteLine($\"EncryptService EncryptFileByChaChaPoly1305 ___ 7| FileHead: {{FileHead}}\");\r\n\r\n                bool writeResult = fileEdit.Write(fileSavePath, encryptedData, false);\r\n                if (!writeResult)\r\n                    return Task.FromResult(new EncryptResult {{ Success = false, ErrorMessage = $\"Write failed: {{fileSavePath}}\" }});\r\n\r\n                return Task.FromResult(new EncryptResult\r\n                {{\r\n                    Success = true,\r\n                    SuccessMessage = $\"File encrypted successfully. [File Save Path: {{fileSavePath}}]\"\r\n                }});\r\n            }}\r\n            catch (Exception ex)\r\n            {{\r\n\r\n            return Task.FromResult(new EncryptResult {{ Success = false, ErrorMessage = $\"Exception: {{ex.Message}}\" }});\r\n            }}\r\n        }}\r\n        private bool CheckPassword( string password)\r\n        {{\r\n            if (string.IsNullOrEmpty(password) || password.Length < 3)\r\n            {{\r\n                    System.Diagnostics.Debug.WriteLine($\"ERROR Password: {{password}} |EncryptService|\");\r\n                return false;\r\n            }}\r\n            return true;\r\n        }}\r\n    }}\r\n}}\r\nice EncryptFileByChaChaPoly1305 ___ 7| FileHead: {FileHead}");


                bool writeResult = fileEdit.Write(fileSavePath, encryptedObject.Ciphertext, false);

                


                System.Diagnostics.Debug.WriteLine($"EncryptService EncryptFileByChaChaPoly1305 END OK | fileSavePath: {fileSavePath}");
                if (!writeResult)
                    return Task.FromResult(new EncryptResult { Success = false, ErrorMessage = $"Write failed: {fileSavePath}" });

                return Task.FromResult(new EncryptResult
                {
                    Success = true,
                    SuccessMessage = $"File encrypted successfully. [File Save Path: {fileSavePath}]"
                });
            }
            catch (Exception ex)
            {

            return Task.FromResult(new EncryptResult { Success = false, ErrorMessage = $"Exception: {ex.Message}" });
            }
        }
        private bool CheckPassword( string password)
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
