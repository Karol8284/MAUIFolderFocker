using MAUIFolderFocker.Shared.Services.CryptoLogic.Service;

namespace MAUIFolderFocker.Shared.Service.CryptoLogic.Service
{
    public class EncryptResult
    {
        public bool Success { get; set; }
        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }
        public double Progress { get; set; }
        public FileClass File { get; set; }
    }
}