using MAUIFolderFocker.Services;
using MAUIFolderFocker.Shared.Pages.Elements;
using MAUIFolderFocker.Shared.Services;
using Microsoft.Extensions.Logging;
using MAUIFolderFocker.Services.FileLogic;
using MAUIFolderFocker.Shared.Services.FilesLogic.Faces;
using MAUIFolderFocker.Shared.Pages;

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
            builder.Services.AddSingleton<IFilePickerService, FilePickerService>();

            //

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
