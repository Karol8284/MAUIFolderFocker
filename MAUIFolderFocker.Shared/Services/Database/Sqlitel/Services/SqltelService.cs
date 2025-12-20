using MAUIFolderFocker.Shared.Services.Database.Sqlitel.Services;
using MAUIFolderFocker.Shared.Services.Database.Sqlitel.Services.PasswordMenager.Interfaces;
using MAUIFolderFocker.Shared.Services.Database.Sqlitel.Variables;
using MAUIFolderFocker.Shared.Services.PasswordManager.Singleton;
using MAUIPasswordMenager.Shared.Services.Elements;
using MAUIPasswordMenager.Shared.Services.Variables;
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
        //PasswordEntry _password = new PasswordEntry();
        private SqliteConnection _sqliteConnection;
        SqlTableCommands sqlCommands = new();
        private string _dbPath = "";
        private readonly UserLoginObject _userLogin;
        public UserObject _user = new UserObject();
        public string dbFileName="";
        public SqltelService(UserLoginObject userLogin)
        {
            _userLogin = userLogin ?? throw new ArgumentNullException(nameof(userLogin));

            var dbFileName = $"{_userLogin.Login}_Passwords.db";
            var folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            _dbPath = Path.Combine(folder, dbFileName);

            Batteries_V2.Init();
        }
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

            // Przypisanie wartości do objektu UserLoginObject
        }


        public SqliteConnection TryConnect()
        {
            if (_sqliteConnection != null && _sqliteConnection.State == System.Data.ConnectionState.Open)
            {
                return _sqliteConnection;
            }

            _sqliteConnection =  CreateEncryptedConnection();
            _sqliteConnection.Open();

            using var keyCmd = _sqliteConnection.CreateCommand();
            keyCmd.CommandText = "PRAGMA key = @key;";
            keyCmd.Parameters.AddWithValue("@key", _userLogin.Password +_userLogin.Pin);
            keyCmd.ExecuteNonQuery();

            return _sqliteConnection;
        }
        public async Task DisconnectAsync()
        {
            if (_sqliteConnection != null)
            {
                await _sqliteConnection.DisposeAsync();
                _sqliteConnection = null;
            }
        }
        public void EncryptedDatabaseCreate(UserLoginObject user)
        {
            if (user == null) return;
            try
            {
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
        //public void EncryptedDatabaseClose()
        //{
        //}
        //public void EncryptedDatabase()
        //{

        //}
        //public bool TryOpenEncryptedDatabase()
        public bool TryExecuteQuery(string sql, List<SqliteParameter>? parameters = null)
        {
            try
            {
                var connection = TryConnect();

                using var cmd = connection.CreateCommand();
                cmd.CommandText = sql;

                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.Add(param);
                    }
                }

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }
        }
        //public (string sql, List<SqliteParameter> parameters)
        //BuildSelectPasswordEntriesByTagAndCategory(string tag, int categoryId)
        //{
        //    const string baseSql = @"
        //    SELECT * FROM PasswordEntry
        //    WHERE Tag = @Tag
        //    AND CategoryId = @CategoryId;
        //    ";

        //    var parameters = new List<SqliteParameter>
        //    {
        //        new SqliteParameter("@Tag", tag),
        //        new SqliteParameter("@CategoryId", categoryId)
        //    };

        //    return (baseSql, parameters);
        //}
        //public List<PasswordEntry> GetPasswordEntriesByTagAndCategory(string tag, int categoryId)
        //{
        //    var connection = TryConnect();

        //    var (sql, parameters) = BuildSelectPasswordEntriesByTagAndCategory(tag, categoryId);
        //    var result = new List<PasswordEntry>();


        //    using var keyCmd = connection.CreateCommand();
        //    keyCmd.CommandText = "PRAGMA key = @key;";
        //    keyCmd.Parameters.AddWithValue("@key", _userLogin.Password + _userLogin.Pin);
        //    keyCmd.ExecuteNonQuery();

        //    using var cmd = connection.CreateCommand();
        //    cmd.CommandText = sql;
        //    foreach (var p in parameters)
        //        cmd.Parameters.Add(p);

        //    using var reader = cmd.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        var entry = new PasswordEntry(
        //            id: reader.GetInt32(reader.GetOrdinal("Id")),
        //            name: reader["Login"] as string ?? "",
        //            username: reader["Username"] as string ?? "",
        //            password: reader["Password"] as string ?? "",
        //            url: reader["Url"] as string ?? "",
        //            note: reader["Note"] as string ?? "",
        //            email: reader["Email"] as string ?? "",
        //            tag: reader["Tag"] as string ?? "",
        //            categoryId: reader["CategoryId"] as int? ?? -1
        //        );
        //        result.Add(entry);
        //    }

        //    return result;
        //}


        public List<PasswordEntry> GetAllPasswordsEntry()
        {
            var connection = TryConnect();
            var result = new List<PasswordEntry>();

            using var cmd = connection.CreateCommand();
            cmd.CommandText = new SqlQuery().SelectPasswordEntry;
            using var reader = cmd.ExecuteReader();
            while( reader.Read())
            {
                var entry = new PasswordEntry(
                    id: reader.GetInt32(reader.GetOrdinal("Id")),
                    name: reader["Login"] as string ?? "",
                    username: reader["Username"] as string ?? "",
                    password: reader["Password"] as string ?? "",
                    url: reader["Url"] as string ?? "",
                    note: reader["Note"] as string ?? "",
                    email: reader["Email"] as string ?? "",
                    tag: reader["Tag"] as string ?? "",
                    categoryId: reader["CategoryId"] as int? ?? -1
                );
                result.Add(entry);
            }
            return result;
        }
        public List<PasswordEntry> UpdatePassword(int passwordId)
        {
            // Dokończyć kod
            // NIe mam teraz siły na to 



            var connection = TryConnect();
            var result = new List<PasswordEntry>();

            using var cmd = connection.CreateCommand();
            
            cmd.CommandText = new SqlQuery().DeletePasswordEntry;


            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var entry = new PasswordEntry(
                    id: reader.GetInt32(reader.GetOrdinal("Id")),
                    name: reader["Login"] as string ?? "",
                    username: reader["Username"] as string ?? "",
                    password: reader["Password"] as string ?? "",
                    url: reader["Url"] as string ?? "",
                    note: reader["Note"] as string ?? "",
                    email: reader["Email"] as string ?? "",
                    tag: reader["Tag"] as string ?? "",
                    categoryId: reader["CategoryId"] as int? ?? -1
                );
                result.Add(entry);
            }
            return result;
        }
        public SqliteConnection GetOpenConnection()
        {
            return TryConnect();
        }
    }
}
