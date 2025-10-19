using System.Collections.Generic;
using System.Threading.Tasks;
using MAUIFolderFocker.Shared.IO.Elements;
using MAUIFolderFocker.Shared.Services.CryptoLogic.Elements;

namespace MAUIFolderFocker.Shared.IO.Faces
{
    public interface IFilePickerService
    {
        Task<string?> PickFileAsync();
        Task<FileCryptoLogic?> PickFileAsyncAsFileClass();
        Task<List<string>> PickFilesAsync(bool allowMultiple = true);
        Task<List<FileCryptoLogic?>?> PickFilesAsyncAsFilesClass();
    }
}
