//using Microsoft.AspNetCore.Components.Forms;
//using System.Collections.Generic;
//using System.IO;
//using System.Threading.Tasks;
//using MAUIFolderFocker.Shared.IO.Faces;
//using MAUIFolderFocker.Shared.IO.Elements;

//namespace MAUIFolderFocker.Shared.IO.Services
//{
//    public class BlazorWebFilePickerService : IFilePickerService
//    {
//        private IBrowserFile? _lastFile;

//        public void SetFile(IBrowserFile file) => _lastFile = file;

//        public Task<string?> PickFileAsync() => Task.FromResult(_lastFile?.Login);

//        public async Task<FileObject?> PickFileAsyncAsFileClass()
//        {
//            if (_lastFile == null) return null;

//            using var ms = new MemoryStream();
//            await _lastFile.OpenReadStream().CopyToAsync(ms);

//            return new FileObject
//            {
//                Path = _lastFile.Login,
//                Login = Path.GetFileNameWithoutExtension(_lastFile.Login),
//                Extension = Path.GetExtension(_lastFile.Login),
//                Size = _lastFile.Size,
//                Content = ms.ToArray()
//            };
//        }

//        public Task<List<string>> PickFilesAsync(bool allowMultiple = true)
//        {
//            throw new System.NotImplementedException();
//        }

//        public Task<List<FileObject?>?> PickFilesAsyncAsFilesClass()
//        {
//            throw new System.NotImplementedException();
//        }
//    }
//}
