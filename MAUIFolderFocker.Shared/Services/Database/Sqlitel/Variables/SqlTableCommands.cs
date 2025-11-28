using NSec.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MAUIFolderFocker.Shared.Services.Database.Sqlitel.Variables
{
    public class SqlTableCommands
    {
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


    }
}
