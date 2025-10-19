using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIFolderFocker.Shared.Services.PasswordManager.Variables
{
    public class UserObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        
        public List<PasswordItem> PasswordItems { get; set; } = new List<PasswordItem>();
        public UserObject() { }
        public UserObject(int id, string name, string password,List<PasswordItem> passwordItems) 
        {
            this.Id = id;
            this.Name = name;
            this.Password = password;
        }
    }
}
