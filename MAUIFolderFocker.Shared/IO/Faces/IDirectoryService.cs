using MAUIFolderFocker.Shared.Services.CryptoLogic.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIFolderFocker.Shared.IO.Faces
{
    public interface IDirectoryService
    {
        Task<List<string>> PickFolderAsync(bool allowMultiple = true);
        Task<List<DirectoryClass>> PickFolderAsyncAsDirectoryClass(bool allowMultiple = true);
    }
}
