using Microsoft.Extensions.Logging;
using LordOfTheGeeks.Services; // Asegúrate de que este using apunte a tu carpeta Services
using CommunityToolkit;
using CommunityToolkit.Maui;
using Microsoft.Extensions.DependencyInjection;


namespace LordOfTheGeeks
{
    public static class MauiProgram
    {
        public static IServiceProvider Services { get; private set; } // 👈 Nueva propiedad

        public static MauiApp CreateMauiApp()
        {
            
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.UseMauiApp<App>().UseMauiCommunityToolkit();
            // 🔥 Registra el DatabaseService como Singleton
            builder.Services.AddSingleton<DatabaseService>();
            

            // Registra páginas
            builder.Services.AddTransient<MainPage>();


            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<RegisterPage>();

            builder.Services.AddTransient<AdminDashboardPage>();
            
            builder.Services.AddTransient<NewsPage>();

            builder.Services.AddTransient<CreateNewsPage>();
            builder.Services.AddTransient<DeleteNewsPage>();
            builder.Services.AddTransient<EditNewsPage>();
            builder.Services.AddTransient<EditSingleNewsPage>();


            builder.Services.AddTransient<CreateTriviaPage>();
            builder.Services.AddTransient<DeleteTriviaPage>();
            builder.Services.AddTransient<EditTriviaPage>();
            builder.Services.AddTransient<EditSingleTriviaPage>();


            builder.Services.AddTransient<TriviaPage>();
            builder.Services.AddTransient<RankingPage>();

            
#if DEBUG
            builder.Logging.AddDebug();
#endif
            var mauiApp = builder.Build();
            Services = mauiApp.Services;

            return builder.Build();
        }
    }
}