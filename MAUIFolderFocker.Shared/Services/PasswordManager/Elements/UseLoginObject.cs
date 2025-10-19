using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIFolderFocker.Shared.Services.PasswordManager.Variables
{
    public class UseLoginObject
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string MasterPassword { get; set; }
        public UseLoginObject(string login, string password)
        {
            Login = login;
            Password = password;
        }
        public UseLoginObject(string login, string password, string masterPassword)
        {
            Login = login;
            Password = password;
            MasterPassword = MasterPassword;
        }
    }
}
