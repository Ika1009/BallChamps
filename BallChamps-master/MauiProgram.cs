using BallChamps.Services;
using BallChamps.View;
using BallChamps.ViewModels;

namespace BallChamps;

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
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        // Pages
        builder.Services.AddSingleton<HomePage>();
        builder.Services.AddSingleton<HomePageViewModel>();
        builder.Services.AddSingleton<ProfilePage>();
        builder.Services.AddSingleton<ProfilePageViewModel>();
        builder.Services.AddSingleton<CourtsPage>();
        builder.Services.AddSingleton<CourtPageViewModel>();
        builder.Services.AddSingleton<CourtsPage>();
        builder.Services.AddSingleton<RankPage>();


        //builder.Services.AddSingleton<ShoppingPage>();


        return builder.Build();
	}
}
