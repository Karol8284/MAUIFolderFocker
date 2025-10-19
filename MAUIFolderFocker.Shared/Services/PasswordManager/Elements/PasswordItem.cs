using MAUIFolderFocker.Shared.Services.PasswordManager.Valiables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIFolderFocker.Shared.Services.PasswordManager.Variables
{
    public class PasswordItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Url { get; set; }
        public string Note { get; set; }
        public EnumBackUp BackUp { get; set; }

        public PasswordItem() { }


    }
}
