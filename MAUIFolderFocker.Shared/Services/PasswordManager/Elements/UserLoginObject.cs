using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIFolderFocker.Shared.Services.PasswordManager.Variables
{
    public class UserLoginObject
    {
        //public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Pin { get; set; }

        public UserLoginObject() { }
        public UserLoginObject(string name, string password,string pin) 
        {
            this.Name = name;
            this.Password = password;
            this.Pin = pin;
        }
    }
}
