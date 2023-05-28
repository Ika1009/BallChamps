using BallChamps.Services;
using System.Net.Http;

namespace BallChamps.View;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }
    async void LoginButton_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(usernameEntry.Text)) { await Shell.Current.DisplayAlert("Error", "You need to fill in the username", "OK"); return; }
        if (string.IsNullOrEmpty(passwordEntry.Text)) { await Shell.Current.DisplayAlert("Error", "You need to fill in the password", "OK"); return; }

        try
        {
            bool loggedin = await APIService.LoginAsync(usernameEntry.Text, passwordEntry.Text);
            if (loggedin)
                await Shell.Current.GoToAsync("//Home/HomePage");
            else
                throw new Exception("Something went wrong");
        }
        catch (Exception ex) { await Shell.Current.DisplayAlert("Error", ex.Message, "OK"); }

    }
    async void OnSignUpClicked(object sender, EventArgs args)
	{
		//signUpPage ??= new SignUpPage(this);
        await Shell.Current.GoToAsync("//SignUp");
	}
	async void OnForgotPasswordClicked(object sender, EventArgs args)
	{
	    await Shell.Current.GoToAsync("//ForgotPassword"); 
	}
}
