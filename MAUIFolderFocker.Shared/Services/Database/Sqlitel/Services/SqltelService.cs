using MAUIFolderFocker.Shared.Services.Database.Sqlitel.Services.PasswordMenager.Interfaces;
using MAUIFolderFocker.Shared.Services.Database.Sqlitel.Variables;
using MAUIFolderFocker.Shared.Services.PasswordManager.Elements;
using MAUIFolderFocker.Shared.Services.PasswordManager.Variables;
using MAUIPasswordMenager.Shared.Services.Elements;
using Microsoft.Data.Sqlite;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIFolderFocker.Shared.Services.Database.Sqlitel.Services
{
    public class SqltelService : InterfaceSqlitelPasswordMenagerOperations
    {
        private readonly string _connectionString;
        private SqliteConnection _sqliteConnection;
        SqlTableCommands sqlCommands = new();

        private string _dbPath = "";

        private UserLoginObject userLogin;
        public UserObject _user = new UserObject();

        public string dbFileName="";
        public SqltelService(UserLoginObject user)
        {
            userLogin = user ?? throw new ArgumentNullException(nameof(user));
            dbFileName = $"{userLogin.Name}_Passwords.db";

            var folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            _dbPath = Path.Combine(folder, dbFileName);
            _password = password;

            //Sqlcipher
            Batteries_V2.Init();
        }

        public SqltelService(string login = null, string password = null, string pin = null)
        {
            userLogin = new UserLoginObject(login, password, pin);
            dbFileName = $"{userLogin.Name}_Passwords.db";

            var folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            _dbPath = Path.Combine(folder, dbFileName);

            Batteries_V2.Init();
        }

        private SqliteConnection CreateEncryptedConnection()
        {
            return new SqliteConnection($"Data Source={_dbPath}");
        }

        // Tworzenie zakodowanej bazy sqlitel3 
        private void InitializeDatabase()
        {
            using var connection = CreateEncryptedConnection();
            connection.Open();
            
            // ustaw klucz SQLCipher
            using var keyCmd = connection.CreateCommand();
            keyCmd.CommandText = "PRAGMA key = @key;";
            keyCmd.Parameters.AddWithValue("@key", userLogin.Password + userLogin.Pin);
            keyCmd.ExecuteNonQuery();

            // utwórz tabele
            using var cmd = connection.CreateCommand();
            cmd.CommandText = sqlCommands.CreateTableCommandAllTables;
            cmd.ExecuteNonQuery();
        }


        public SqliteConnection TryConnect()
        {
            _sqliteConnection = CreateEncryptedConnection();
            _sqliteConnection.Open();
                using var keyCmd = _sqliteConnection.CreateCommand();
            keyCmd.CommandText = "PRAGMA key = @key;";
            keyCmd.Parameters.AddWithValue("@key", userLogin.Password + userLogin.Pin);
            keyCmd.ExecuteNonQuery();
            return _sqliteConnection;
        }
        //using var testCmd = connection.CreateCommand();
        //        testCmd.CommandText = "SELECT count(*) FROM sqlite_master;";
        //        testCmd.ExecuteScalar();
        public async void Disconect()
        {
            await _sqliteConnection.DisposeAsync();
            _sqliteConnection = null;
        }
        public void EncryptedDatabaseCreate(UserLoginObject user)
        {
            try
        {
                if (user == null) return;

                Batteries_V2.Init();
                InitializeDatabase();

        }
            catch (Exception ex)
            {

                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        public void EncryptedDatabaseCreate(string login, string password, string pin)
        {
            userLogin = new UserLoginObject(login, password, pin);
            InitializeDatabase();
        }
        //public void EncryptedDatabaseOpenOrCreate(string login, string password, string pin)
        //{

        //}
        public void EncryptedDatabaseClose()
        {
        }
        public void EncryptedDatabase()
        {

        }
        //public bool TryOpenEncryptedDatabase()
        public bool TryEncryptedDatabaseConect()
        {
            try
        {
                using var connection = CreateEncryptedConnection();
                connection.Open();

                using var keyCmd = connection.CreateCommand();
                keyCmd.CommandText = "PRAGMA key = @key;";
                keyCmd.Parameters.AddWithValue("@key", userLogin.Password + userLogin.Pin);
                keyCmd.ExecuteNonQuery();

                using var testCmd = connection.CreateCommand();
                testCmd.CommandText = "SELECT count(*) FROM sqlite_master;";
                testCmd.ExecuteScalar();

                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}
