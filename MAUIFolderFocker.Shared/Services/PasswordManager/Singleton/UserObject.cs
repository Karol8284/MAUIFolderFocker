using MAUIPasswordMenager.Shared.Services.Elements;

namespace MAUIFolderFocker.Shared.Services.PasswordManager.Singleton
{
    public class UserObject
    {
        public string database { get; set; } = string.Empty;
        public string databasePassword { get; set; } = string.Empty;
        public string username { get; set; }
        public List<PasswordEntry> passwordsList { get; set; } = new List<PasswordEntry>();



        public UserObject() { }

        public UserObject(string db = "main", string dbPassword = "12345", string userName = "K")
        {
            database = db;
            databasePassword = dbPassword;
            username = userName;

        }
        public UserObject(string db = "main", string dbPassword = "12345", string userName = "K", List<PasswordEntry> passwords = null)
        {
            database = db;
            databasePassword = dbPassword;
            username = userName;
            passwordsList = passwords;
        }

    }
}
