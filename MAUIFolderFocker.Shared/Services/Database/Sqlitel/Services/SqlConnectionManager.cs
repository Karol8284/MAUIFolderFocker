using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIFolderFocker.Shared.Services.Database.Sqlitel.Services
{
    public class SqlConnectionManager
    {
        private readonly string _connectionString;
        private SqliteConnection _connection;
        private Timer _autoCloseTimer;

        public bool IsOpen => _connection?.State == System.Data.ConnectionState.Open;

        public SqlConnectionManager(string dbPath)
        {
            _connectionString = $"Data Source={dbPath}";
        }

        public SqliteConnection GetConnection()
        {
            if (_connection == null)
            {
                _connection = new SqliteConnection(_connectionString);
                _connection.Open();
            }
            return _connection;
        }
        //public SqliteConnection GetConnection()
        //{
        //    if (_connection == null)
        //    {
        //        _connection = new SqliteConnection(_connectionString);
        //        _connection.Open();
        //        StartAutoCloseTimer();
        //    }
        //    else if (_connection.State != System.Data.ConnectionState.Open)
        //    {
        //        _connection.Open();
        //        StartAutoCloseTimer();
        //    }

        //    ResetAutoCloseTimer();
        //    return _connection;
        //}

        //private void StartAutoCloseTimer()
        //{
        //    _autoCloseTimer = new Timer(5 * 60 * 1000); // 5 minut
        //    _autoCloseTimer.Elapsed += (sender, e) => CloseConnection();
        //    _autoCloseTimer.AutoReset = false;
        //    _autoCloseTimer.Start();
        //}

        //private void ResetAutoCloseTimer()
        //{
        //    if (_autoCloseTimer != null)
        //    {
        //        _autoCloseTimer.Stop();
        //        _autoCloseTimer.Start();
        //    }
        //}

        public void CloseConnection()
        {
            try
            {
                _connection?.Close();
                _connection?.Dispose();
                _connection = null;
                //_autoCloseTimer?.Stop();
                _autoCloseTimer?.Dispose();
                _autoCloseTimer = null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"CloseConnection error: {ex.Message}");
            }
        }

        public void Dispose()
        {
            CloseConnection();
        }
    }
}
