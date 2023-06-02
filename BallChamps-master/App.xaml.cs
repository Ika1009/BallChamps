using BallChamps.View;

namespace BallChamps;

public partial class App : Application
{
    public App()
	{
		InitializeComponent();

        Services.UserService.CurrentUser = new Domain.User();

        MainPage = new AppShell();
    }
}
