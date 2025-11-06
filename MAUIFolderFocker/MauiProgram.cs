using MAUIFolderFocker.Services;
using MAUIFolderFocker.Services.DB;
using MAUIFolderFocker.Shared.IO.Faces;
using MAUIFolderFocker.Shared.IO.Services;
using MAUIFolderFocker.Shared.Services;
using MAUIFolderFocker.Shared.Services.Comunication.Variables;
using Microsoft.Extensions.Logging;
using Microsoft.Maui;

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

            builder.Services.AddSingleton<IFilePickerService, MauiFilePickerService>();
            //builder.Services.AddSingleton<MauiFilePickerService>();
            builder.Services.AddSingleton<DBServices>();


            builder.Services.AddSingleton<SingletonDataToEncrypt>();
            builder.Services.AddSingleton<SingletonDataToDecrypt>();


#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
