using BallChamps.Services;
using BallChamps.View;
using System.Windows.Input;

namespace BallChamps;

public partial class AppShell : Shell
{
    public ICommand GoToLoginCommand { get; private set; }

    public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));

        GoToLoginCommand = new Command(GoToLogin);
        logOutItem.Command = GoToLoginCommand;
    }

    private async void GoToLogin()
    {
        bool answer = await DisplayAlert("Logout", "Are you sure you want to logout?", "Yes", "No");
        if (answer)
        {
            UserService.RemoveToken(); // removing the user token on logout
            await Current.GoToAsync("//Intro");
        }

    }
}
