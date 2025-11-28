using System;
using System.Collections.Generic;

namespace MAUIPasswordMenager.Shared.Services.Elements
{
    public class PasswordEntry
    {
        public int Id { get; private set; }
        public string Name { get; private set; }        // np. "Facebook"
        public string Username { get; private set; }    // login/email użytkownika
        public string Email { get; private set; }
        public string Password { get; private set; }    // hasło (zaszyfrowane)
        public string Url { get; private set; }
        public string Note { get; private set; }
        public string Tag { get; private set; }
        public bool Favorite { get; private set; }
        public bool Archived { get; private set; }
        public int CategoryId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        //public DateTime LastUpdateAt { get; private set; }
        public List<DateTime> UpdateHistory { get; private set; }

        // Konstruktor
        //public PasswordEntry(
        //    int id,
        //    string name, string username,
        //    string password, string url,
        //    string note, string email,
        //    string tag, int categoryId
        //    )
        //{
        //    Id = new Random().Next(1, int.MaxValue);
        //    Login = name;
        //    Username = username;
        //    Password = password;
        //    Url = url;
        //    Note = note;
        //    Email = email;
        //    Tag = tag;
        //    Favorite = false;
        //    Archived = false;
        //    CategoryId = categoryId;
        //    CreatedAt = DateTime.Now;
        //    UpdatedAt = new List<DateTime> { DateTime.Now };
        //}
        public PasswordEntry(
            int id = -1,
            string name = "", string username = "",
            string password = "", string url = "",
            string note = "", string email = "",
            string tag = "", int categoryId =-1
            )
        {
            Id = new Random().Next(1, int.MaxValue);
            Name = name;
            Username = username;
            Password = password;
            Url = url;
            Note = note;
            Email = email;
            Tag = tag;
            Favorite = false;
            Archived = false;
            CategoryId = categoryId;
            CreatedAt = DateTime.Now;
            UpdateHistory = new List<DateTime> { DateTime.Now };
        }
        // --- METODY AKTUALIZACJI ---
        public void UpdateName(string newName)
        {
            Name = newName;
            AddUpdateTimestamp();
        }

        public void UpdateUsername(string newUsername)
        {
            Username = newUsername;
            AddUpdateTimestamp();
        }

        public void UpdateEmail(string newEmail)
        {
            Email = newEmail;
            AddUpdateTimestamp();
        }

        public void UpdatePassword(string newPassword)
        {
            Password = newPassword;
            AddUpdateTimestamp();
        }

        public void UpdateUrl(string newUrl)
        {
            Url = newUrl;
            AddUpdateTimestamp();
        }

        public void UpdateNote(string newNote)
        {
            Note = newNote;
            AddUpdateTimestamp();
        }

        public void UpdateTag(string newTag)
        {
            Tag = newTag;
            AddUpdateTimestamp();
        }

        public void UpdateCategory(int newCategoryId)
        {
            CategoryId = newCategoryId;
            AddUpdateTimestamp();
        }

        // --- AKCJE LOGICZNE ---
        public void ToggleFavorite()
        {
            Favorite = !Favorite;
            AddUpdateTimestamp();
        }

        public void Archive()
        {
            Archived = true;
            AddUpdateTimestamp();
        }

        public void Unarchive()
        {
            Archived = false;
            AddUpdateTimestamp();
        }

        // --- METODA POMOCNICZA ---
        private void AddUpdateTimestamp()
        {
            UpdateHistory.Add(DateTime.Now);
        }

        // --- METODA DO PODGLĄDU DANYCH (np. debug lub testy) ---
        public override string ToString()
        {
            return $"{Name} ({Username}) - {Url} | Favorite: {Favorite} | Archived: {Archived}";
        }
    }
}
