using CommunityToolkit.Maui;
using Flowbite.Services;
using Me.App.Infrastructure;
using Microsoft.Extensions.Logging;

namespace Me.App
{
    public static partial class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("FiraCode-Regular.ttf", "FiraCodeRegular");

                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddFlowbite();
#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddInfrastructure();
            var app = builder.Build();
            SetupBlazorWebView();
            return app;
        }
    }
}
