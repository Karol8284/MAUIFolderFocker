using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIFolderFocker.Shared.Services.Database.Sqlitel.Variables
{
    public class SqlCommands
    {
        public static readonly string CreateTablePasswordEntries = @"
                CREATE TABLE IF NOT EXISTS PasswordEntries (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Title TEXT NOT NULL,
                    Username TEXT NOT NULL,
                    Password TEXT NOT NULL,
                    Notes TEXT,
                    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP
                );";

        public static readonly string CreateTableUserLogin = @"
            CREATE TABLE IF NOT EXISTS UserLogin (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Login TEXT NOT NULL,
                Password TEXT NOT NULL,
                NonceNumber TEXT NOT NULL,
                CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP
            );
        ";
        public static readonly string CreateTableSettings = @"
            CREATE TABLE IF NOT EXISTS Settings (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                SettingKey TEXT NOT NULL,
                SettingValue TEXT NOT NULL,
                CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP
            );
        ";

    }
}
