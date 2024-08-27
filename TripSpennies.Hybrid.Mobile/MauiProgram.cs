using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;
using TripSpennies.Hybrid.Mobile.Data;
using TripSpennies.Hybrid.Mobile.Services;

namespace TripSpennies.Hybrid.Mobile
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

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            AddServices(builder.Services);

            return builder.Build();
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddSingleton<DbContext>()
                    .AddScoped<SeedDataService>();
        }
    }
}
