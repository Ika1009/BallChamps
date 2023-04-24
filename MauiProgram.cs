using BallChamps.View;

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

		builder.Services.AddSingleton<HomePage>();
        builder.Services.AddSingleton<ProfilePage>();
        builder.Services.AddSingleton<CourtsPage>();
        builder.Services.AddSingleton<RankPage>();
        //builder.Services.AddSingleton<ShoppingPage>();


        return builder.Build();
	}
}
