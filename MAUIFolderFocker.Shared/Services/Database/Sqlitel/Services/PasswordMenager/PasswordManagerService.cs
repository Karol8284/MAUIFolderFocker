using MAUIFolderFocker.Shared.Services.Database.Sqlitel.Variables;
using MAUIFolderFocker.Shared.Services.PasswordManager.Singleton;
using MAUIPasswordMenager.Shared.Services.Elements;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIFolderFocker.Shared.Services.Database.Sqlitel.Services.PasswordMenager
{
    public class PasswordManagerService
    {
        private readonly string _connectionString;
        PasswordEntry _password = new PasswordEntry();
        private SqliteConnection _sqliteConnection;
        SqlTableCommands sqlCommands = new();
        private string _dbPath = "";
        private UserLoginObject _userLogin;
        public UserObject _user = new UserObject();
        public string dbFileName = "";
        public PasswordManagerService() { }
        private SqliteConnection CreateEncryptedConnection()
        {
            return new SqliteConnection($"Data Source={_dbPath}");
        }
        public void AddPasswordEntry()
        {
            try
            {
                using var connection = CreateEncryptedConnection();
                connection.Open();

                using var keyCmd = connection.CreateCommand();
                keyCmd.CommandText = "PRAGMA key = @key;";
                keyCmd.Parameters.AddWithValue("@key", _userLogin.Password + _userLogin.Pin);
                keyCmd.ExecuteNonQuery();

                using var cmd = connection.CreateCommand();
                cmd.CommandText = sql;


                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value);
                    }
                }
                cmd.ExecuteScalar();

                return true;
            }
            catch
            {
                return false;
            }



            // Implementation for adding a password entry
        }
        public void RemovePasswordEntry() 
        {
        
        }
        public void UpdatePasswordEntry() 
        {
        
        }
        public void DeletePasswordEntry() 
    {
        
        }

    }
}
