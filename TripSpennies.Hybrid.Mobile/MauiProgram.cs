using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace TripSpennies.Hybrid.Mobile
{
    public static class MauiProgram
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
            services.AddSingleton<AppViewModel>()
                    .AddSingleton<MauiInterop>()
                    .AddSingleton<AppState>();

            services.AddSingleton<DbContext>()
                    .AddScoped<SeedDataService>();

            services.AddScoped<AuthorizationService>();
        }
    }
}
