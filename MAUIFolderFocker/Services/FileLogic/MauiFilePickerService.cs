#if ANDROID || IOS || WINDOWS || MACCATALYST
using MAUIFolderFocker.Shared.IO.Elements;
using MAUIFolderFocker.Shared.IO.Faces;
using MAUIFolderFocker.Shared.Services.CryptoLogic.Elements;
using MAUIFolderFocker.Shared.Services.CryptoLogic.Service;
using Microsoft.Maui.Storage;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MAUIFolderFocker.Shared.IO.Services
{
    public class MauiFilePickerService : IFilePickerService
    {
        public async Task<string?> PickFileAsync()
        {
            var result = await FilePicker.Default.PickAsync(new PickOptions
            {
                PickerTitle = "Please select a file",
                //FileTypes = FilePickerFileType.Videos
            });
            return result?.FullPath;
        }
        public async Task<FileCryptoLogic?> PickFileAsyncAsFileClass()
        {
            var result = await FilePicker.Default.PickAsync(new PickOptions
            {
                PickerTitle = "Please select a file",
                //FileTypes = FilePickerFileType.Videos
            });
            if (result == null) return null;

            var info = new FileInfo(result.FullPath);
            return new FileCryptoLogic
            {
                Path = info.FullName,
                Name = Path.GetFileNameWithoutExtension(info.Name),
                Extension = info.Extension,
                Size = info.Length,
            };
        }
        public async Task<List<string>> PickFilesAsync(bool allowMultiple = true)
        {
            if (allowMultiple)
            {
                var result = await FilePicker.Default.PickMultipleAsync(new PickOptions
                {
                    PickerTitle = "Please select files",
                    //FileTypes = FilePickerFileType.Videos
                });
                return result?.Select(r => r.FullPath).ToList() ?? new List<string>();
            }
            else
            {
                var result = await FilePicker.Default.PickAsync();
                return result != null ? new List<string> { result.FullPath } : new List<string>();
            }
        }
        public async Task<List<FileCryptoLogic?>?> PickFilesAsyncAsFilesClass()
        {
            try
            {
                var result = await FilePicker.Default.PickMultipleAsync(new PickOptions
                {
                    PickerTitle = "Please select single or multiple files NO DIRECTORYS",
                    //FileTypes =  FilePickerFileType.Images
                });

                if (result == null) return null;
                return result.Select(r =>
                {
                    var info = new FileInfo(r.FullPath);
                    return new FileCryptoLogic
                    {
                        Path = info.FullName,
                        Name = Path.GetFileNameWithoutExtension(info.Name),
                        Extension = info.Extension,
                        Size = info.Length,
                    };
                }).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
#endif
