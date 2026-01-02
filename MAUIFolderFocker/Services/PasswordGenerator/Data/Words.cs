using MAUIAdvancePasswordGenerator.Shared.Services.PasswordGenerator.Interfaces;
using MAUIFolderFocker;
using System.Text.Json;

namespace MAUIAdvancePasswordGenerator.Services.PasswordGenerator.Data
{
    public class Words : IWordStorageService
    {
        //private static readonly string _pathToWordJsonFile = "MAUIAdvancePasswordGenerator.Resources.PasswordGenerator.Data.words.txt";
        private static readonly string _pathToWordJsonFile = "MAUIAdvancePasswordGenerator.Resources.PasswordGenerator.Data.words.json";
        //private static readonly string _pathToWordFile = "MAUIAdvancePasswordGenerator.Resources.PasswordGenerator.Data.words2.txt";
        private static readonly string _pathToWordFile = "MAUIAdvancePasswordGenerator.Resources.PasswordGenerator.Data.words2.txt";
        private readonly Lazy<Task<IReadOnlyList<string>>> _lazyLoadWords = new();
        private readonly Lazy<Task<string>> fileString = new();
        private readonly Lazy<int> numberOfWords = new();
        public Words()
        {
            //fileString = new Lazy<Task<string>>(WordsString());
            //_lazyLoadWords = new Lazy<Task<IReadOnlyList<string>>>(LoadDataFromTxtAsync);
            _lazyLoadWords = new Lazy<Task<IReadOnlyList<string>>>(LoadDataFromJsonAsync);
        }
        public Task<IReadOnlyList<string>> GetWordsAsync()
        {
            return _lazyLoadWords.Value;
        }
        public async Task<IReadOnlyList<string>> LoadDataFromTxtAsync()
        {
            await Task.Yield();
            var assembly = typeof(App).Assembly;

            using var stream = assembly.GetManifestResourceStream(_pathToWordFile
                //"MAUIAdvancePasswordGenerator.Resources.PasswordGenerator.Data.words.txt"
            );
            using var reader = new StreamReader(stream);
            var content = await reader.ReadToEndAsync();

            var words = content
                .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            return words;

            //throw new NotImplementedException();
        }
        public async Task<IReadOnlyList<string>> LoadDataFromJsonAsync()
        {
            try
            {
                await Task.Yield();
                var assembly = typeof(App).Assembly;

                using var stream = assembly.GetManifestResourceStream(_pathToWordJsonFile
                //"MAUIAdvancePasswordGenerator.Resources.PasswordGenerator.Data.words.txt"
                );
                using var reader = new StreamReader(stream);
                string content = await reader.ReadToEndAsync();

                var words = JsonSerializer.Deserialize<List<string>>(content); ;
                
                return words;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return null;
            }
        }
    }
}
