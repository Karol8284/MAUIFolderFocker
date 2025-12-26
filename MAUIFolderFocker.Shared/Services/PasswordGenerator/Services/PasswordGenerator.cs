using MAUIFolderFocker.Shared.Services.PasswordGenerator.Constants;
using MAUIFolderFocker.Shared.Services.PasswordGenerator.Models;
using MAUIFolderFocker.Shared.Services.PasswordGenerator.Valiables;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MAUIFolderFocker.Shared.Services.PasswordGenerator.Services
{
    public class PasswordGenerator
    {
        public PasswordGenerator() { }
        public PasswordGenerator(EnumPasswordGeneratorModeType mode, int lenght) 
        {

            //mode == EnumPasswordGeneratorModeType.Byte ? : ;
        }


        public PasswordGeneratorOutput Generate(PasswordGeneratorInput requirements)
        {
            try
            {
                Stopwatch stopwatch = new();
                stopwatch.Start();
                StringBuilder passwordGenereted = new();
                string passwordCharacterSet = "abcdefghijklmnopqrstuvwxyz";
                if (requirements.IsIncludeUppercase) passwordCharacterSet += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                if (requirements.IsIncludeNumbers) passwordCharacterSet += "0123456789";
                if (requirements.IsIncludeSymbols) passwordCharacterSet += "!@#$%^&*()-_=+[]{}|;:,.<>?";

                for (int i = 0; i < requirements.PasswordLength; i++)
                {
                    int randomIndex = RandomNumberGenerator.GetInt32(0, passwordCharacterSet.Length);
                    passwordGenereted.Append(passwordCharacterSet[randomIndex]);
                }

                stopwatch.Stop();

                return new PasswordGeneratorOutput(
                    input: requirements,
                    generatedPassword: passwordGenereted.ToString(),
                    generationTimeMs: stopwatch.ElapsedMilliseconds
                    );
            }
            catch (Exception ex)
            {
                throw new Exception("Password generation failed", ex);
            }
        }
        public WordPasswordGeneratorOutput Generate(WordPasswordGeneratorInput requirements)
        {
            try
            {
                Stopwatch stopwatch = new();
                stopwatch.Start();

                StringBuilder passwordGenereted = new();
                PasswordGeneratorWords passwordGeneratorWords = new();
                string[] passwordWordSet = passwordGeneratorWords.WordsTable;
                string passwordUpercaseSet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                string passwordLowercaseSet = "abcdefghijklmnopqrstuvwxyz";
                string passwordNumbersSet = "0123456789";
                string passwordSymbolsSet = "!@#$%^&*()-_=+[]{}|;:,.<>?";

                for (int i = 0; i < requirements.NumberOfWords; i++)
                {
                    int randomIndex = RandomNumberGenerator.GetInt32(0, passwordWordSet.Length);
                    string selectedWord = passwordWordSet[randomIndex];

                    if (requirements.IncludeFirstLetersUpercase && selectedWord.Length > 0)
                    {
                        int count = Math.Min(requirements.IncludeFirstLetersUpercaseLength, selectedWord.Length);
                        var chars = selectedWord.ToCharArray();
                        for (int k = 0; k < count; k++)
                        {
                            chars[k] = char.ToUpper(chars[k]);
                        }
                        selectedWord = new string(chars);
                    }
                    passwordGenereted.Append(selectedWord);

                    if (requirements.IncludeFirstLetersUpercase)
                    {
                        for (int j = 0; j < requirements.IncludeFirstLetersUpercaseLength; j++)
                        {
                            passwordGenereted.Append(passwordUpercaseSet[RandomNumberGenerator.GetInt32(0, passwordUpercaseSet.Length)]);
                        }
                    }
                    if (requirements.IncludeLowercase)
                    {
                        for (int j = 0; j < requirements.IncludeLowercaseLength; j++)
                        {
                            passwordGenereted.Append(passwordLowercaseSet[RandomNumberGenerator.GetInt32(0, passwordLowercaseSet.Length)]);
                        }
                    }
                    if (requirements.IncludeNumbers)
                    {
                        for (int j = 0; j < requirements.IncludeNumbersLength; j++)
                        {
                            passwordGenereted.Append(passwordNumbersSet[RandomNumberGenerator.GetInt32(0, passwordNumbersSet.Length)]);
                        }
                    }
                    if (requirements.IncludeSymbols)
                    {
                        for (int j = 0; j < requirements.IncludeSymbolsLength; j++)
                        {
                            passwordGenereted.Append(passwordSymbolsSet[RandomNumberGenerator.GetInt32(0, passwordNumbersSet.Length)]);
                        }
                    }
                    passwordGenereted.Append(requirements.PasswordSeperator);

                }
                stopwatch.Stop();

                return new WordPasswordGeneratorOutput(
                    input: requirements,
                    generatedPassword: passwordGenereted.ToString().TrimEnd(requirements.PasswordSeperator.ToCharArray()),
                    generationTimeMs: stopwatch.ElapsedMilliseconds
                    );
            }
            catch (Exception ex)
            {
                throw new Exception("Password generation failed", ex);
            }
        }
        //protected char GenerateRandomChar()
        //{
        //    Random random = new Random();
        //    return charType switch
        //    {
        //        EnumPasswordGeneratorCharType.Lowercase => (char)random.Next(97, 123), // a-z
        //        EnumPasswordGeneratorCharType.Uppercase => (char)random.Next(65, 91),  // A-Z
        //        EnumPasswordGeneratorCharType.Digit => (char)random.Next(48, 58),      // 0-9
        //        EnumPasswordGeneratorCharType.Symbol => (char)random.Next(33, 48),     // Symbols
        //        _ => throw new ArgumentOutOfRangeException(nameof(charType), "Invalid character type"),
        //    };
        //}
    }
}
