using Microsoft.AspNetCore.Components.RenderTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MAUIFolderFocker.Shared.Services.PasswordGenerator.Constants
{
    public class PasswordGeneratorWords
    {
        //public List<string> WordsList { get; set; }
        public string[] WordsTable { get; set; }
        public PasswordGeneratorWords()
        {
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                using Stream stream = assembly.GetManifestResourceStream("MAUIFolderFocker.Resources.PasswordGenerator.Data.words.txt");
                using StreamReader reader = new(stream);
                string content = reader.ReadToEnd();
                WordsTable = content.Split('\n');
                
                

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd ładowania słów: {ex.Message}");

            }

        }


    }
}
