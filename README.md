# MAUIFolderFocker

## Co projkt potrafi:
- Generować bardzo zaawansowane hasła, posiada rozbudowane możliwość wpływania na wygląd hasła: 

### Dla hasła standardowego:
- - decyzje o dłógości
- - wielkich literach
- - cyfrach
- - znakach specjalnych
- - ...
 
 ### Dla haseł wyrazowych:
 - - dłógość
 - - opcja zawierania wielkich liter
 - - opcja zawierania cyfr 
 - - opcja zawierania znaków specjalnych 
 - - ...
 

## Zakodowywanie pliku lub plików:

### Możliwość zakodowywania za pomocą algorytmów takich, jak:
 - Chacha20-Poly1305 (Preferowany, na razie głównie dostępny)
 - ... kolejne w drodze 

### 
[\MAUIFolderFocker.Shared\Services\PasswordGenerator\Services\KeyDerivationService.cs](Plik KeyDerivationService) zawierający Rfc2898DeriveBytes, jako funkcje do generowania randomowego hasła, w ramach bespieczeństwa.



# Urzyte technologie:
- C#
- ASP.NET MAUI blazor 
- ...

