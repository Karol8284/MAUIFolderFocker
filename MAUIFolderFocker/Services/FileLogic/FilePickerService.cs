using MAUIFolderFocker.Shared.Services.CryptoLogic.Service;
using MAUIFolderFocker.Shared.Services.FilesLogic.Faces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIFolderFocker.Services.FileLogic
{
    public class FilePickerService : IFilePickerService
    {
        /// <summary>
        /// Opens a file picker dialog to allow the user to select a file.
        /// </summary>
        /// <remarks>The method displays a file picker dialog with a customizable title.  If the user
        /// selects a file, the full path of the selected file is returned.  If the user cancels the operation, the
        /// method returns <see langword="null"/>.</remarks>
        /// <returns>The full path of the selected file, or <see langword="null"/> if the user cancels the operation.</returns>
        public async Task<string?> PickFileAsync()
        {
            var result = await FilePicker.Default.PickAsync(new PickOptions
            {
                PickerTitle = "Please select a file",
                //FileTypes = FilePickerFileType.Videos
            });
            return result?.FullPath;

        }

        public async Task<FileClass?> PickFileAsyncAsFileClass()
        {
            var result = await FilePicker.Default.PickAsync(new PickOptions
            {
                PickerTitle = "Please select a file",
                //FileTypes = FilePickerFileType.Videos
            });
            if(result == null) return null;

            var info = new FileInfo(result.FullPath);
            return new FileClass
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
                return result != null ? new List<string> {  result.FullPath} : new List<string> ();
            }
        }

        public async Task<List<FileClass?>?> PickFilesAsyncAsFilesClass()
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
                    return new FileClass
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
