using Microsoft.Extensions.Logging;
using Microsoft.FluentUI.AspNetCore.Components;
using ScheduleMixer.Shared.Services;
using ScheduleMixer.Services;
using ScheduleMixer.Services.StorageProvider;

namespace ScheduleMixer;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts => { fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular"); });

        // Add device-specific services used by the ScheduleMixer.Shared project
        builder.Services.AddSingleton<IFormFactor, FormFactor>();
        
        // Add storage path provider
        builder.Services.AddSingleton<IStoragePathProvider, MauiStoragePathProvider>();


        builder.Services.AddMauiBlazorWebView();
        builder.Services.AddFluentUIComponents();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}