using MAUIFolderFocker.Shared.Services.CryptoLogic.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIFolderFocker.Shared.Services.FilesLogic.Faces
{
    public interface IFilePickerService
    {
        /// <summary>
        /// Select a Path to File All type
        /// </summary>
        /// <returns>Path to file</returns>
        Task<string?> PickFileAsync();
        
        Task<FileClass?> PickFileAsyncAsFileClass();
        Task<List<string>> PickFilesAsync(bool allowMultiple = true);

        Task<List<FileClass?>?> PickFilesAsyncAsFilesClass();

    }
}
