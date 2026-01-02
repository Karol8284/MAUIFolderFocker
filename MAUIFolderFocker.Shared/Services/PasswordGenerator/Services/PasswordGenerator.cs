using MAUIAdvancePasswordGenerator.Shared.Services.PasswordGenerator.Interfaces;
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
            private readonly IWordStorageService _wordStorage;
            public PasswordGenerator(IWordStorageService wordStorage)
            {
                _wordStorage = wordStorage ?? throw new ArgumentNullException(nameof(wordStorage));
            }


            public PasswordGeneratorOutput Generate(PasswordGeneratorInput requirements)
            {
                try
                {
                    Stopwatch stopwatch = new();
                    stopwatch.Start();
                    StringBuilder passwordGenerated = new();
                    string passwordCharacterSet = "abcdefghijklmnopqrstuvwxyz";
                    if (requirements.IsIncludeUppercase) passwordCharacterSet += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    if (requirements.IsIncludeNumbers) passwordCharacterSet += "0123456789";
                    if (requirements.IsIncludeSymbols) passwordCharacterSet += "!@#$%^&*()-_=+[]{}|;:,.<>?";

                    for (int i = 0; i < requirements.PasswordLength; i++)
                    {
                        int randomIndex = RandomNumberGenerator.GetInt32(0, passwordCharacterSet.Length);
                        passwordGenerated.Append(passwordCharacterSet[randomIndex]);
                    }

                    stopwatch.Stop();

                    return new PasswordGeneratorOutput(
                        input: requirements,
                        generatedPassword: passwordGenerated.ToString(),
                        generationTimeMs: stopwatch.ElapsedMilliseconds
                        );
                }
                catch (Exception ex)
                {
                    return new PasswordGeneratorOutput(
                        input: requirements,
                        generatedPassword: string.Empty,
                        generationTimeMs: -1,
                        errorMessage: "Password generation failed: " + ex.Message
                        );
                }
            }
            public async Task<WordPasswordGeneratorOutput> Generate(WordPasswordGeneratorInput requirements)
            {
                try
                {
                    Stopwatch stopwatch = new();
                    stopwatch.Start();

                    //var passwordWordSet = await _wordStorage.GetWordsAsync();
                    var passwordWordSet = await _wordStorage.GetWordsAsync();
                    StringBuilder passwordGenerated = new();
                    string passwordUpercaseSet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    string passwordLowercaseSet = "abcdefghijklmnopqrstuvwxyz";
                    string passwordNumbersSet = "0123456789";
                    string passwordSymbolsSet = "!@#$%^&*()-_=+[]{}|;:,.<>?";

                    for (int i = 0; i < requirements.NumberOfWords; i++)
                    {
                        int randomIndex = RandomNumberGenerator.GetInt32(0, passwordWordSet.Count);
                        string selectedWord = passwordWordSet[randomIndex];

                        if (requirements.IncludeLowercaseLength > 0)
                        {
                            int count = Math.Min(requirements.IncludeFirstLetersUpercaseLength, selectedWord.Length);
                            var chars = selectedWord.ToCharArray();
                            for (int k = 0; k < count; k++)
                            {
                                chars[k] = char.ToUpper(chars[k]);
                            }
                            selectedWord = new string(chars);
                        }
                        passwordGenerated.Append(selectedWord);

                        if (requirements.IncludeUppercaseLength > 0)
                        {
                            for (int j = 0; j < requirements.IncludeFirstLetersUpercaseLength; j++)
                            {
                                passwordGenerated.Append(passwordUpercaseSet[RandomNumberGenerator.GetInt32(0, passwordUpercaseSet.Length)]);
                            }
                        }
                        if (requirements.IncludeLowercaseLength > 0)
                        {
                            for (int j = 0; j < requirements.IncludeLowercaseLength; j++)
                            {
                                passwordGenerated.Append(passwordLowercaseSet[RandomNumberGenerator.GetInt32(0, passwordLowercaseSet.Length)]);
                            }
                        }
                        if (requirements.IncludeNumbersLength > 0)
                        {
                            for (int j = 0; j < requirements.IncludeNumbersLength; j++)
                            {
                                passwordGenerated.Append(passwordNumbersSet[RandomNumberGenerator.GetInt32(0, passwordNumbersSet.Length)]);
                            }
                        }
                        if (requirements.IncludeSymbolsLength > 0)
                        {
                            for (int j = 0; j < requirements.IncludeSymbolsLength; j++)
                            {
                                passwordGenerated.Append(passwordSymbolsSet[RandomNumberGenerator.GetInt32(0, passwordNumbersSet.Length)]);
                            }
                        }
                        passwordGenerated.Append(requirements.PasswordSeperator);

                    }
                    stopwatch.Stop();

                    return new WordPasswordGeneratorOutput(
                        input: requirements,
                        generatedPassword: passwordGenerated.ToString().TrimEnd(requirements.PasswordSeperator.ToCharArray()),
                        generationTimeMs: stopwatch.ElapsedMilliseconds
                        );
                }
                catch (Exception ex)
                {
                    throw new Exception("Password generation failed", ex);
                }
            }
    }
}
