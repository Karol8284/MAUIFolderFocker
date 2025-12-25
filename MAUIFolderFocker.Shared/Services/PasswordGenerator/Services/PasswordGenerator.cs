using MAUIFolderFocker.Shared.Services.PasswordGenerator.Models;
using MAUIFolderFocker.Shared.Services.PasswordGenerator.Valiables;
using System;
using System.Collections.Generic;
using System.Linq;
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
                StringBuilder passwordGenereted = new();
                string passwordCharacterSet = "abcdefghijklmnopqrstuvwxyz";
                if (requirements.IsIncludeUppercase) passwordCharacterSet += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                if (requirements.IsIncludeNumbers) passwordCharacterSet += "0123456789";
                if (requirements.IsIncludeSymbols) passwordCharacterSet += "!@#$%^&*()-_=+[]{}|;:,.<>?";


                Random random = new();

                for (int i = 0; i < requirements.PasswordLength; i++)
                {
                    int randomIndex = random.Next(0, passwordCharacterSet.Length);
                    passwordGenereted.Append(passwordCharacterSet[randomIndex]);
                }
                return new PasswordGeneratorOutput(
                    generatedPassword: passwordGenereted.ToString(),
                    passwordLength: requirements.PasswordLength,
                    includesUppercase: requirements.IsIncludeUppercase,
                    includesNumbers: requirements.IsIncludeNumbers,
                    includesSymbols: requirements.IsIncludeSymbols
                    );
            }
            catch (Exception ex)
            {
                throw new Exception("Password generation failed", ex);
                return null;
            }
        }
        public WordPasswordGeneratorOutput Generate(WordPasswordGeneratorInput requirements)
        {
            // first letre Uppercase word Symbols, Numbers Seperator
            try
            {
                StringBuilder passwordGenereted = new();
                string passwordCharacterSet = "abcdefghijklmnopqrstuvwxyz";
                if (requirements.IsIncludeUppercase) passwordCharacterSet += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                if (requirements.IsIncludeNumbers) passwordCharacterSet += "0123456789";
                if (requirements.IsIncludeSymbols) passwordCharacterSet += "!@#$%^&*()-_=+[]{}|;:,.<>?";


                Random random = new();

                for (int i = 0; i < requirements.NumberOfWords; i++)
                {
                    int randomIndex = random.Next(0, passwordCharacterSet.Length);
                    passwordGenereted.Append(passwordCharacterSet[randomIndex]);
                }
                return new PasswordGeneratorOutput(
                    generatedPassword: passwordGenereted.ToString(),
                    passwordLength: requirements.PasswordLength,
                    includesUppercase: requirements.IsIncludeUppercase,
                    includesNumbers: requirements.IsIncludeNumbers,
                    includesSymbols: requirements.IsIncludeSymbols
                    );
            }
            catch (Exception ex)
            {
                throw new Exception("Password generation failed", ex);
            }
        }



        protected char GenerateRandomChar()
        {
            Random random = new Random();
            return charType switch
            {
                EnumPasswordGeneratorCharType.Lowercase => (char)random.Next(97, 123), // a-z
                EnumPasswordGeneratorCharType.Uppercase => (char)random.Next(65, 91),  // A-Z
                EnumPasswordGeneratorCharType.Digit => (char)random.Next(48, 58),      // 0-9
                EnumPasswordGeneratorCharType.Symbol => (char)random.Next(33, 48),     // Symbols
                _ => throw new ArgumentOutOfRangeException(nameof(charType), "Invalid character type"),
            };
        }






        //public byte[] genera

    }
}
