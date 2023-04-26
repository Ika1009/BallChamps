using System.Windows.Input;

namespace BallChamps;

public partial class AppShell : Shell
{
    public ICommand GoToLoginCommand { get; private set; }

    public AppShell()
	{
		InitializeComponent();

        GoToLoginCommand = new Command(GoToLogin);
        logOutItem.Command = GoToLoginCommand;
    }

    private async void GoToLogin()
    {
        bool answer = await DisplayAlert("Logout", "Are you sure you want to logout?", "Yes", "No");
        if (answer) await Shell.Current.GoToAsync("//Intro");
    }
}
