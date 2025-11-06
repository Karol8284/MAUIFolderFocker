using MAUIFolderFocker.Shared.Services.Database.Sqlitel.Variables;
using MAUIFolderFocker.Shared.Services.PasswordManager.Sqlitel;
using Microsoft.Data.Sqlite;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIFolderFocker.Shared.Services.Database.Sqlitel.Services
{
    public class SqltelService
    {
        SqlCommands sqlCommands = new();

        private readonly string _dbPath;
        private readonly string _password;
        SqltelService(string userLogin = null, string password = null)
        {
            var dbFileName = $"{userLogin}_Passwords.db";
            var folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            _dbPath = Path.Combine(folder, dbFileName);
            _password = password;

            //Sqlcipher
            Batteries_V2.Init();
            InitializeDatabase();

        }
        private void InitializeDatabase()
        {
            
            using var connection = new SqliteConnection($"Data Source={_dbPath}");
            var command = connection.CreateCommand();
            command.CommandText = $"{sqlCommands.}";

            using var command = new SqliteCommand(tableCommand, connection);
            command.ExecuteNonQuery();
        }

        public SqliteConnection GetConnection()
        {
            return new SqliteConnection($"Data Source={_dbPath}");
        }

        public void EncryptedDatabaseCreate(string login, string pass, string )
        {

        }
        public void EncryptedDatabaseOpen(string dbPath, string, string )
        {

        }
        public void EncryptedDatabaseOpenOrCreate(string dbPath, string, string )
        {

        }

    }
}
