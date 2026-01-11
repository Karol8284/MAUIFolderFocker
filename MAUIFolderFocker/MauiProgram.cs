using MAUIAdvancePasswordGenerator.Shared.Services.PasswordGenerator.Interfaces;
using MAUIFolderFocker.Services;
using MAUIFolderFocker.Services.DB;
using MAUIFolderFocker.Services.PasswordGenerator.Data;
using MAUIFolderFocker.Shared.IO.Faces;
using MAUIFolderFocker.Shared.IO.Services;
using MAUIFolderFocker.Shared.Layout.Elements.PasswordGenerator;
using MAUIFolderFocker.Shared.Services;
using MAUIFolderFocker.Shared.Services.Comunication.Variables;
using MAUIFolderFocker.Shared.Services.PasswordGenerator.Services;
using MAUIFolderFocker.Shared.Services.PasswordManager.Singleton;
using Microsoft.Extensions.Logging;
using Microsoft.Maui;
using SharpScss;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MAUIFolderFocker
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            // Add device-specific services used by the MAUIFolderFocker.Shared project
            builder.Services.AddSingleton<IFormFactor, FormFactor>();

            builder.Services.AddMauiBlazorWebView();

            //builder.Services.AddSingleton<MauiFilePickerService>();
            //builder.Services.AddSingleton<IFilePickerService, MauiFilePickerService>();
            //builder.Services.AddSingleton<DBServices>();





            // Singleton Encrypt and Decrypt
            //builder.Services.AddSingleton<SingletonDataToEncrypt>();
            //builder.Services.AddSingleton<SingletonDataToDecrypt>();


            ////Password MANAGER SINGLETONS
            //builder.Services.AddSingleton<UserLoginObject>();
            //builder.Services.AddSingleton<UserObject>();

            ////Singleton Password Generator Services
            //builder.Services.AddSingleton<Words>();
            //builder.Services.AddSingleton<IWordStorageService, Words>();
            //builder.Services.AddSingleton<PasswordGenerator>();


#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif
            //Password Generator Elements
            //var app = builder.Build();
            //var words = app.Services.GetRequiredService<Words>();
            //_ = words.GetWordsAsync();
            //return app;

            return builder.Build();
        }
    }
}


/// ProjectName
// ├── / Interfaces
// │     └── IPasswordGenerator.cs
// │     └── IWordService.cs
// │
// ├── / Services
// │     └── SimplePasswordGenerator.cs
// │     └── WordPasswordGenerator.cs
// │
// ├── / Models
// │     └── PasswordOptions.cs
// │     └── UserSettings.cs
// │
// ├── / Pages
// │     └── PasswordGeneratorPage.razor
// │
// ├── / Components
// │     └── RangeInput.razor
// │
// ├── / Data
// │     └── ApplicationDbContext.cs
// │
// ├── / wwwroot
// │     └── css, js, images...
// │
// └── Program.cs / Startup.cs