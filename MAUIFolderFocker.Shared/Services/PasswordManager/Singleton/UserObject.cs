namespace MAUIFolderFocker.Shared.Services.PasswordManager.Singleton
{
    public class UserObject
    {
        public string database { get; set; } = string.Empty;
        public string databasePassword { get; set; } = string.Empty;
        public string username { get; set; }




        public UserObject() { }

        public UserObject(string db, string dbPassword, string userName)
        {
            database = db;
            databasePassword = dbPassword;
            username = userName;
        }

    }
}
