using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIFolderFocker.Shared.Services.Database.Sqlitel.Services.PasswordMenager.Interfaces
{
    public interface InterfaceSqlitelPasswordMenagerOperations
    {

        public void EncryptedDatabaseCreate(string login = "", string pass = "", string? pin = null)
        {




        }
        public void EncryptedDatabaseOpen(string login = "", string pass = "", string? pin = null)
        {

        }
        public void EncryptedDatabaseOpenOrCreate(string login = "", string pass = "", string? pin = null)
        {
            
        }

    }
}
