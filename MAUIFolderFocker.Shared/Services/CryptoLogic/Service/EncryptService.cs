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
        private List<EncryptResult> encryptResults = new();
        private Task<EncryptResult> encryptResult;

        //private string Password { get; set; }
        private string FileName { get; set; }
        private byte[] FileData { get; set; }
        private byte[] EncryptResult { get; set; }
        private string FileHead { get; set; }   = string.Empty;
        private string SaveDirectory { get; set; }   = string.Empty;

        private DataToDecryptAfterEncrypt dataToDecrypt = new();

        public EncryptService() { }
        public async Task<List<EncryptResult>> Encrypt
            (List<FileClass> files,
            ModelOptions model, string savePath, string DirectoryName,
            string Password, Action<int, int, EncryptResult>? onProgress = null)
        {
            Console.WriteLine("EncryptService - Encrypt - Start");
            System.Diagnostics.Debug.WriteLine("EncryptService - Encrypt - Start");

            SaveDirectory = Path.Combine(savePath, DirectoryName);

            encryptResults.Clear(); // czyść listę na początku, jeśli to pole klasy
            if (ModelOptions.ChaCha20 == model)
            {
                
                int filesTotal = files.Count;
                int fileCurrent = 0;




                foreach (FileClass file in files)
                {
                    System.Diagnostics.Debug.WriteLine("EncryptService Encrypt CHaCha20:" + file);
                    var result = await EncryptFileByChaChaPoly1305(file, SaveDirectory, Password);
                    encryptResults.Add(result); // dodaj rezultat do listy

                    fileCurrent++;
                    onProgress?.Invoke(fileCurrent, filesTotal, result); // callback
                }
            }
            else if (ModelOptions.Aes == model)
            {

            }
            return encryptResults;
        }
        public async Task<List<EncryptResult>> EncryptAsChunks
            (List<FileClass> files,
            ModelOptions model, string savePath, string DirectoryPath,
            string Password, Action<int, EncryptResult>? onProgress = null)
        {
            Console.WriteLine("EncryptService - Encrypt - Start");
            System.Diagnostics.Debug.WriteLine("EncryptService - Encrypt - Start");

            SaveDirectory = Path.Combine(savePath, DirectoryPath);

            encryptResults.Clear(); // czyść listę na początku, jeśli to pole klasy
            if (ModelOptions.ChaCha20 == model)
            {
                int total = files.Count;
                int current = 0;
                foreach (FileClass file in files)
                {
                    System.Diagnostics.Debug.WriteLine("EncryptService Encrypt CHaCha20:" + file);
                    var result = await EncryptFileByChaChaPoly1305AsChunk(file, SaveDirectory, Password);
                    encryptResults.Add(result); // dodaj rezultat do listy

                    current++;
                    int percent = (int)((current / (double)total) * 100);
                    onProgress?.Invoke(percent, result); // callback
                }
            }
            else if (ModelOptions.Aes == model)
            {

            }
            return encryptResults;
        }

        public async Task<EncryptResult>  EncryptFileByChaChaPoly1305
            (FileClass file, 
            string directoryPath,
            string password,
            Action<double>? onProgress = null)
        {
            try
            {
                
                System.Diagnostics.Debug.WriteLine("EncryptService EncryptFileByChaChaPoly1305 ___ 1");
                if (!File.Exists(file.Path))
                {
                    System.Diagnostics.Debug.WriteLine($"ERROR EncryptService EncryptFileByChaChaPoly1305 File not found: {file.Path} , {File.Exists(file.Path)}");
                    return await Task.FromResult(new EncryptResult { Success = false, ErrorMessage = "File not found." });
                }
                if (!CheckPassword(password))
                {
                    System.Diagnostics.Debug.WriteLine($"ERROR EncryptService EncryptFileByChaChaPoly1305 Password: {password}");
                    return await Task.FromResult(new EncryptResult { Success = false, ErrorMessage = "Error: Password is too short or something else." });

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

                // Start Set data to decryptOptions
                encryptOptions.Password = password;
                encryptOptions.Salt = encryptOptions.GenerateSalt();
                encryptOptions.Nonce = encryptOptions.GenerateNonce();
                // END Set data to decryptOptions

                EncryptionResultObject encryptedObject = chaCha20.Encrypt(fileData, encryptOptions);

                // Start Set data to dataToDecrypt
                dataToDecrypt = new();
                dataToDecrypt.File_Original_Name = file.Name;
                dataToDecrypt.File_Original_Extension = file.Extension;
                dataToDecrypt.PBKDF2_Salt = encryptedObject.Nonce;
                dataToDecrypt.Algorithm_Nonce = encryptedObject.Nonce;
                dataToDecrypt.Algorithm_Add = encryptedObject.Add;
               
                fileEdit = new FileEdit();

                FileHead = JsonSerializer.Serialize(dataToDecrypt);

                fileEdit.Write(fileSavePath, Encoding.UTF8.GetBytes(FileHead + Environment.NewLine), true);
                bool writeResult = fileEdit.Write(fileSavePath, encryptedObject.Ciphertext, false);

                System.Diagnostics.Debug.WriteLine(FileHead);


                System.Diagnostics.Debug.WriteLine($"EncryptService EncryptFileByChaChaPoly1305 END OK | fileSavePath: {fileSavePath}");
                if (!writeResult)
                    return await Task.FromResult(new EncryptResult { Success = false, ErrorMessage = $"Write failed: {fileSavePath}" });

                return await Task.FromResult(new EncryptResult
                {
                    Success = true,
                    SuccessMessage = $"File encrypted successfully. [File Save Path: {fileSavePath}]"
                });
            }
            catch (Exception ex)
            {

            return await Task.FromResult(new EncryptResult { Success = false, File = file, ErrorMessage = $"Exception: {ex.Message}" });
            }
        }
        public async Task<EncryptResult> EncryptFileByChaChaPoly1305AsChunk(
            FileClass file,
            string directoryPath,
            string password,
            Action<double>? onProgress = null
            )
        {
            int chunkSize = 4 * 1024 * 1024; // 4 MB, możesz ustawić wg potrzeb
            long fileLength = new FileInfo(file.Path).Length;
            long totalRead = 0;

            string fileSavePath = fileEdit.FindAvailableFileName(directoryPath, file.Name, file.Extension);
            System.Diagnostics.Debug.WriteLine($"EncryptService EncryptFileByChaChaPoly1305 ___ 3");

            using var inputStream = new FileStream(file.Path, FileMode.Open, FileAccess.Read);
            using var outputStream = new FileStream(fileSavePath, FileMode.Create, FileAccess.Write);

            byte[] buffer = new byte[chunkSize];
            int bytesRead;
            while ((bytesRead = await inputStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                // encrypt chunk
                byte[] encryptedChunk = chaCha20.Encrypt(buffer.Take(bytesRead).ToArray(), encryptOptions).Ciphertext;
                await outputStream.WriteAsync(encryptedChunk, 0, encryptedChunk.Length);

                totalRead += bytesRead;
                double percent = (totalRead / (double)fileLength) * 100.0;
                onProgress?.Invoke(percent); // callback
            }

            // Zwróć wynik
            return new EncryptResult
            {
                Success = true,
                SuccessMessage = "File encrypted successfully.",
                Progress = 100.0,
                File = file
            };
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
