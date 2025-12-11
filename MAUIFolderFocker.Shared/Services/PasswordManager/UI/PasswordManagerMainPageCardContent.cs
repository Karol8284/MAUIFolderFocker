using MAUIFolderFocker.Shared.Pages.PasswordManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIFolderFocker.Shared.Services.PasswordManager.UI
{
    public class PasswordManagerMainPageCardContent
    {

        List<PasswordManagerMainPageCardContentObject> _contentList { get; set; } = new();
        public PasswordManagerMainPageCardContent()
        {

        }
        public List<PasswordManagerMainPageCardContentObject> ReturnConstCardData()
        {
            _contentList.Add(
                new PasswordManagerMainPageCardContentObject
                (
                    title: "Login",
                    description: "Access your saved passwords and manage your login credentials securely.",
                    iconSource: "/password-manager/login_page",
                    navigationUrl: "/password_login_page"
                ));
            _contentList.Add(
                new PasswordManagerMainPageCardContentObject(
                    title: "Generate Password",
                    description: "Create a strong password using our password generator tool.",
                    iconSource: "Generate Now",
                    navigationUrl: "/password/ passoword_generator_page"
            ));
            _contentList.Add(
                new PasswordManagerMainPageCardContentObject(
                    title: "Store Passwords",
                    description: "Securely store and manage your passwords in one place.",
                    iconSource: "Manage Passwords",
                    navigationUrl: "/password_storage_page"
            ));
            _contentList.Add(
                new PasswordManagerMainPageCardContentObject(
                    title: "Password Tips",
                    description: "Learn best practices for creating and maintaining strong passwords.",
                    iconSource: "View Tips",
                    navigationUrl: "/password_tips_page"
            ));
            return _contentList;
        }
    }
}
