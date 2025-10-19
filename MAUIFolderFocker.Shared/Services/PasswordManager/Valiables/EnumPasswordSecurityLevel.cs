using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIFolderFocker.Shared.Services.PasswordManager.Valiables
{
    public enum EnumPasswordSecurityLevel
    {
        None = 0,         // Brak zabezpieczeń
        VeryWeak = 1,     // Bardzo słabe
        Weak = 2,         // Słabe
        Medium = 3,       // Średnie
        Strong = 4,       // Mocne
        VeryStrong = 5,   // Bardzo mocne
        Maximum = 6       // Najwyższy poziom (np. spełnia wszystkie wymagania bezpieczeństwa)
    }
}
