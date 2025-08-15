using Microsoft.Extensions.Logging;

namespace SimonSays;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans .ttf", "OpenSans");
                fonts.AddFont("PressStart.ttf", "PressStart");
                fonts.AddFont("Astroz.ttf", "Astroz");
                fonts.AddFont("ArcadePizza.ttf", "Arcade");
                fonts.AddFont("Jersey.ttf", "Jersey");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}