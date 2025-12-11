using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIFolderFocker.Shared.Services.PasswordManager.UI
{
    public class PasswordManagerMainPageCardContentObject
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconSource { get; set; }
        public string NavigationUrl { get; set; }

        public PasswordManagerMainPageCardContentObject(string title = "title", string description = "description", string iconSource = "description", string navigationUrl = "/passwordmanager_mainpage")
        {
            Title = title;
            Description = description;
            IconSource = iconSource;
            NavigationUrl = navigationUrl;
        }

    }
}
