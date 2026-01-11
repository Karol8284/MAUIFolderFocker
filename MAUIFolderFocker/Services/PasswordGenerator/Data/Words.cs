using MAUIAdvancePasswordGenerator.Shared.Services.PasswordGenerator.Interfaces;
using MAUIFolderFocker;
using System.Text.Json;

namespace MAUIFolderFocker.Services.PasswordGenerator.Data
{
    public class Words : IWordStorageService
    {
        private static readonly string _pathToWordJsonFile = "MAUIFolderFocker.Resources.PasswordGenerator.Data.words.json";
        //private static readonly string _pathToWordFile = "MAUIFolderFocker.Resources.PasswordGenerator.Data.words2.txt";
        private readonly Lazy<Task<IReadOnlyList<string>>> _lazyLoadWords = new();
        private readonly Lazy<Task<string>> fileString = new();
        private readonly Lazy<int> numberOfWords = new();
        public Words()
        {
            _lazyLoadWords = new Lazy<Task<IReadOnlyList<string>>>(LoadDataFromJsonAsync);
        }
        public Task<IReadOnlyList<string>> GetWordsAsync()
        {
            return _lazyLoadWords.Value;
        }
        public async Task<IReadOnlyList<string>> LoadDataFromJsonAsync()
        {
            System.Diagnostics.Debug.WriteLine("!!! LoadDataFromJsonAsync Start");

            //var names = typeof(App).Assembly.GetManifestResourceNames();
            //System.Diagnostics.Debug.WriteLine("Zasoby: " + string.Join(", ", names));
            try
            {
                await Task.Yield();
                
                var assembly = typeof(App).Assembly;
                using var stream = assembly.GetManifestResourceStream(_pathToWordJsonFile);
                using var reader = new StreamReader(stream);

                if(stream == null)
                {
                    System.Diagnostics.Debug.WriteLine("!!! LoadDataFromJsonAsync stream == null");
                    List<string> list = new();
                    list.Add("Error: stream is null");
                    list.Add("Error: stream is null");
                    list.Add("Error: stream is null");
                    list.Add("Error: stream is null");
                    list.Add("Error: stream is null");
                    return list;
                }

                string content = await reader.ReadToEndAsync();

                var words = JsonSerializer.Deserialize<List<string>>(content); ;
                System.Diagnostics.Debug.WriteLine("!!! LoadDataFromJsonAsync End");
                return words;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                List<string> list = new();
                list.Add("Error: stream is null");
                list.Add("Error: stream is null");
                list.Add("Error: stream is null");
                list.Add("Error: stream is null");
                list.Add("Error: stream is null");
                return list;
            }
        }
        //public async Task<IReadOnlyList<string>> LoadDataFromTxtAsync()
        //{
        //    await Task.Yield();
        //    var assembly = typeof(App).Assembly;

        //    using var stream = assembly.GetManifestResourceStream(_pathToWordFile
        //        //"MAUIAdvancePasswordGenerator.Resources.PasswordGenerator.Data.words.txt"
        //    );
        //    using var reader = new StreamReader(stream);
        //    var content = await reader.ReadToEndAsync();

        //    var words = content
        //        .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
        //        .ToList();

        //    return words;

        //    //throw new NotImplementedException();
        //}
    }
}
//var names = assembly.GetManifestResourceNames();
//System.Diagnostics.Debug.WriteLine("Resources: " + string.Join(", ", names));
