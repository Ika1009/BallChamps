using BallChamps.Services;
using BallChamps.ViewModels;

namespace BallChamps.View;

public partial class LoginPage : ContentPage
{
	public LoginPage()
    {
        InitializeComponent();
		BindingContext = new LoginPageViewModel();
    }
    async void LoginButton_Clicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("//Home/HomePage");
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
