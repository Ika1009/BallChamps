using BallChamps.View;

namespace BallChamps;

public partial class App : Application
{
    public App()
	{
		InitializeComponent();
        MainPage = new AppShell();
        Services.UserService.CurrentUser = new Domain.User();
	}
}
