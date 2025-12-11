using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIFolderFocker.Shared.Services.Database.Sqlitel.Variables
{
    public class SqlQuery
    {
        public SqlQuery() { }

        // ========================
        // CREATE TABLES
        // ========================
        public static readonly string CreateTableUser = @"
        CREATE TABLE IF NOT EXISTS User (
            ID INTEGER PRIMARY KEY AUTOINCREMENT,
            Login TEXT,
            Email TEXT
        );
        ";

        public static readonly string CreateTablePasswordEntry = @"
        CREATE TABLE IF NOT EXISTS PasswordEntry (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Login TEXT NOT NULL,
            Username TEXT,
            Email TEXT,
            Password TEXT NOT NULL,
            Url TEXT,
            Note TEXT,
            Tag TEXT,
            Favorite INTEGER DEFAULT 0,
            Archived INTEGER DEFAULT 0,
            CategoryId INTEGER,
            CreatedAt DATETIME NOT NULL,
            UpdateHistory TEXT
        );
    ";

        public static readonly string CreateTablePasswordEntryUpdates = @"
        CREATE TABLE IF NOT EXISTS PasswordEntryUpdates (
            Id INTEGER,
            Date DATE,
            ChangeElement TEXT,
            OldValue TEXT,
            NewValue TEXT
        );
    ";

        public static readonly string CreateTableUserLoginHistory = @"
        CREATE TABLE IF NOT EXISTS UserLoginHistory (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Data DATE NOT NULL,
            Login INTEGER NOT NULL,
            UserId INTEGER,
            HasLogin INTEGER NOT NULL,
            FOREIGN KEY(UserId) REFERENCES User(ID)
        );
    ";

        public string CreateTableCommandAllTables = $@"
        {CreateTableUser}
        {CreateTablePasswordEntry}
        {CreateTablePasswordEntryUpdates}
        {CreateTableUserLoginHistory}
    ";

        // ========================
        // INSERT
        // ========================
        public readonly string InsertUser = @"
        INSERT INTO User (Login, Email)
        VALUES (@Login, @Email);
    ";

        public readonly string InsertPasswordEntry = @"
        INSERT INTO PasswordEntry
            (Login, Username, Email, Password, Url, Note, Tag, Favorite, Archived, CategoryId, CreatedAt, UpdateHistory)
        VALUES
            (@Login, @Username, @Email, @Password, @Url, @Note, @Tag, @Favorite, @Archived, @CategoryId, @CreatedAt, @UpdateHistory);
    ";

        public readonly string InsertPasswordEntryUpdates = @"
        INSERT INTO PasswordEntryUpdates
            (Id, Date, ChangeElement, OldValue, NewValue)
        VALUES
            (@Id, @Date, @ChangeElement, @OldValue, @NewValue);
    ";

        public readonly string InsertUserLogicHistory = @"
        INSERT INTO UserLoginHistory
            (Data, Login, UserId, HasLogin)
        VALUES
            (@Data, @Login, @UserId, @HasLogin);
    ";

        // ========================
        // UPDATE
        // ========================
        public readonly string UpdateUser = @"
        UPDATE User
        SET Login = @Login,
            Email = @Email
        WHERE ID = @ID;
    ";

        public readonly string UpdatePasswordEntry = @"
        UPDATE PasswordEntry
        SET Login = @Login,
            Username = @Username,
            Email = @Email,
            Password = @Password,
            Url = @Url,
            Note = @Note,
            Tag = @Tag,
            Favorite = @Favorite,
            Archived = @Archived,
            CategoryId = @CategoryId,
            UpdateHistory = @UpdateHistory
        WHERE Id = @Id;
    ";

        public readonly string UpdatePasswordEntryUpdates = @"
        UPDATE PasswordEntryUpdates
        SET Date = @Date,
            ChangeElement = @ChangeElement,
            OldValue = @OldValue,
            NewValue = @NewValue
        WHERE Id = @Id;
    ";

        public readonly string UpdateUserLogicHistory = @"
        UPDATE UserLoginHistory
        SET Data = @Data,
            Login = @Login,
            UserId = @UserId,
            HasLogin = @HasLogin
        WHERE Id = @Id;
    ";

        // ========================
        // DELETE
        // ========================
        public readonly string DeleteUser = @"
        DELETE FROM User WHERE ID = @ID;
    ";

        public readonly string DeletePasswordEntry = @"
        DELETE FROM PasswordEntry WHERE Id = @Id;
    ";

        public readonly string DeletePasswordEntryUpdates = @"
        DELETE FROM PasswordEntryUpdates WHERE Id = @Id;
    ";

        public readonly string DeleteUserLogicHistory = @"
        DELETE FROM UserLoginHistory WHERE Id = @Id;
    ";

        // ========================
        // SELECT
        // ========================
        public readonly string SelectUser = @"
        SELECT * FROM User;
    ";

        public readonly string SelectPasswordEntry = @"
        SELECT * FROM PasswordEntry;
    ";

        public readonly string SelectPasswordEntryUpdates = @"
        SELECT * FROM PasswordEntryUpdates;
    ";

        public readonly string SelectUserLogicHistory = @"
        SELECT * FROM UserLoginHistory;
    ";
        public readonly string SelectUserById = @"
        SELECT * FROM User WHERE ID = @ID;
        ";


        public readonly string SelectPasswordEntryById = @"
        SELECT * FROM PasswordEntry WHERE Id = @Id;
        ";

        public readonly string SelectPasswordEntryByCategory = @"
        SELECT * FROM PasswordEntry WHERE CategoryId = @CategoryId;
        ";

        public readonly string SelectFavorites = @"
        SELECT * FROM PasswordEntry WHERE Favorite = 1;
        ";
        public readonly string SelectArchived = @"
        SELECT * FROM PasswordEntry WHERE Archived = 1;
        ";
        public readonly string SearchPasswordEntries = @"
        SELECT * FROM PasswordEntry
        WHERE Login LIKE @Query
        OR Username LIKE @Query
        OR Tag LIKE @Query
        OR Email LIKE @Query;
        ";
        public readonly string SelectPasswordEntryUpdatesById = @"
        SELECT * FROM PasswordEntryUpdates WHERE Id = @Id ORDER BY Date DESC;
        ";
        public readonly string SelectUserLoginHistoryByUserId = @"
        SELECT * FROM UserLoginHistory WHERE UserId = @UserId ORDER BY Data DESC;
        ";

        public readonly string SelectPasswordEntriesOrdered = @"
SELECT * FROM PasswordEntry ORDER BY CreatedAt DESC;
";
        public readonly string SelectByTag = @"
SELECT * FROM PasswordEntry WHERE Tag = @Tag;
";

        public readonly string SelectByTagAndCategory = @"
SELECT * FROM PasswordEntry
WHERE Tag = @Tag
  AND CategoryId = @CategoryId;
";
        public readonly string SelectPasswordEntryPreview = @"
SELECT Id, Login, Username, Email, Url, Tag, Favorite, Archived, CategoryId, CreatedAt 
FROM PasswordEntry;
";
        public readonly string UpdateFavorite = @"
UPDATE PasswordEntry SET Favorite = @Favorite WHERE Id = @Id;
";
        public readonly string UpdateArchived = @"
UPDATE PasswordEntry SET Archived = @Archived WHERE Id = @Id;
";
        public readonly string DeleteByCategory = @"
DELETE FROM PasswordEntry WHERE CategoryId = @CategoryId;
";
        public readonly string DeleteArchived = @"
DELETE FROM PasswordEntry WHERE Archived = 1;
";
        public readonly string SelectUserByEmail = @"
SELECT * FROM User WHERE Email = @Email;
";
        public readonly string UserExists = @"
SELECT COUNT(1) FROM User WHERE Email = @Email;
";
        public readonly string PasswordEntryExists = @"
SELECT COUNT(1) FROM PasswordEntry WHERE Login = @Login;
";

    }
}

/* using var connection = new SqliteConnection("Data Source=mydb.db");
connection.Open();

using var cmd = connection.CreateCommand();
cmd.CommandText = new SqlQuery().InsertPasswordEntry;
cmd.Parameters.AddWithValue("@Login", "Facebook");
cmd.Parameters.AddWithValue("@Username", "karol");
cmd.Parameters.AddWithValue("@Email", "karol@example.com");
cmd.Parameters.AddWithValue("@Password", "1234");
cmd.Parameters.AddWithValue("@Url", "https://facebook.com");
cmd.Parameters.AddWithValue("@Note", "konto testowe");
cmd.Parameters.AddWithValue("@Tag", "social");
cmd.Parameters.AddWithValue("@Favorite", 1);
cmd.Parameters.AddWithValue("@Archived", 0);
cmd.Parameters.AddWithValue("@CategoryId", 1);
cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
cmd.Parameters.AddWithValue("@UpdateHistory", "");
cmd.ExecuteNonQuery();
 */