using MAUIFolderFocker.Services;
using MAUIFolderFocker.Services.FileLogic;
using MAUIFolderFocker.Shared.Pages;
using MAUIFolderFocker.Shared.Services;
using MAUIFolderFocker.Shared.Services.Comunication.Variables;
using MAUIFolderFocker.Shared.Services.FilesLogic.Faces;
using Microsoft.Extensions.Logging;

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
            //

            builder.Services.AddSingleton<IFilePickerService, FilePickerService>();
            //builder.Services.AddSingleton<IFilePickerService, FilePickerService>();
            builder.Services.AddSingleton<SingletonDataToEncrypt>();
            //

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
