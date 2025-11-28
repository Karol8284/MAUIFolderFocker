using MAUIFolderFocker.Shared.Services.Database.Sqlitel.Services;
using MAUIFolderFocker.Shared.Services.Database.Sqlitel.Services.PasswordMenager.Interfaces;
using MAUIFolderFocker.Shared.Services.Database.Sqlitel.Variables;
using MAUIFolderFocker.Shared.Services.PasswordManager.Singleton;
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
        PasswordEntry _password = new PasswordEntry();
        private SqliteConnection _sqliteConnection;
        SqlTableCommands sqlCommands = new();

        private string _dbPath = "";

        private UserLoginObject _userLogin;
        public UserObject _user = new UserObject();

        public string dbFileName="";
        

        

        private SqliteConnection CreateEncryptedConnection()
        {
            return new SqliteConnection($"Data Source={_dbPath}");
        }

        // Tworzenie zakodowanej bazy sqlitel3 
        private void InitializeDatabase(UserLoginObject userLogin)
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
            
            _userLogin = userLogin; // Przypisanie wartości do objektu UserLoginObject
        }


        public SqliteConnection TryConnect()
        {
            _sqliteConnection = CreateEncryptedConnection();
            _sqliteConnection.Open();
                using var keyCmd = _sqliteConnection.CreateCommand();
            keyCmd.CommandText = "PRAGMA key = @key;";
            keyCmd.Parameters.AddWithValue("@key", _userLogin.Password + _userLogin.Pin);
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
                InitializeDatabase(user);

        }
            catch (Exception ex)
            {

                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
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
        public bool TryExecuteQueary(string sql, Dictionary<string, object> parameters = null)
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


                if(parameters != null)
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
        }


    }
}
//public SqltelService(UserLoginObject user)
//{
//    _userLogin = user ?? throw new ArgumentNullException(nameof(user));
//    dbFileName = $"{_userLogin.Login}_Passwords.db";

//    var folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
//    _dbPath = Path.Combine(folder, dbFileName);
//    _password = user.Password;

//    //Sqlcipher
//    Batteries_V2.Init();
//}
//public SqltelService(string login = null, string password = null, string pin = null)
//{
//    _userLogin = new UserLoginObject(login, password, pin);
//    dbFileName = $"{_userLogin.Login}_Passwords.db";

//    var folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
//    _dbPath = Path.Combine(folder, dbFileName);

//    Batteries_V2.Init();
//}

