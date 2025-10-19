using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIFolderFocker.Shared.Services.CryptoLogic.Variables
{
    public enum EncryptOptions
    {
        None = 0,
        Compress = 1 << 0,         // Kompresuj przed szyfrowaniem
        Overwrite = 1 << 1,        // Nadpisz istniejące pliki
        AddHeader = 1 << 2,        // Dodaj nagłówek do pliku
        Recursive = 1 << 3,        // Szyfruj rekurencyjnie foldery
        FilesOnly = 1 << 4,        // Szyfruj tylko pliki
        FoldersOnly = 1 << 5,      // Szyfruj tylko foldery
        FilesAndFolders = 1 << 6,  // Szyfruj pliki i foldery
        FastMode = 1 << 7,         // Tryb szybki
        SecureMode = 1 << 8        // Tryb bezpieczny
    }
}
/*
 * To wywołanie wykorzystuje tzw. enum z flagami (bitowe łączenie opcji). Dzięki temu możesz przekazać wiele opcji naraz w jednym parametrze, a każda opcja jest reprezentowana przez inny bit liczby całkowitej.
---
Jak to działa?
Każda opcja w EncryptOptions ma inną wartość bitową:
•	Compress = 1 << 0 → 0000 0001
•	Overwrite = 1 << 1 → 0000 0010
•	AddHeader = 1 << 2 → 0000 0100
•	itd.
Gdy piszesz:
EncryptOptions options = EncryptOptions.Compress | EncryptOptions.AddHeader | EncryptOptions.Overwrite;

if ((options & EncryptOptions.Compress) != 0)
{
    // Opcja Compress jest ustawiona
}
options |= EncryptOptions.Recursive; // Dodaje opcję Recursive
options &= ~EncryptOptions.AddHeader; // Usuwa opcję AddHeader
options = EncryptOptions.Overwrite; // Tylko Overwrite, reszta wyczyszczona
// Ustaw kilka opcji
EncryptOptions options = EncryptOptions.Compress | EncryptOptions.AddHeader;

// Dodaj kolejną opcję
options |= EncryptOptions.Overwrite;

// Sprawdź, czy AddHeader jest ustawione
if ((options & EncryptOptions.AddHeader) != 0)
{
    // Tak, AddHeader jest aktywne
}

// Usuń opcję Compress
options &= ~EncryptOptions.Compress;

*/