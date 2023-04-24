namespace BallChamps.View;

public partial class LoginPage : ContentPage
{
	SignUpPage signUpPage; // use only one instance of signUpPage for optimization
	public LoginPage()
	{
		InitializeComponent();
	}
    async void LoginButton_Clicked(object sender, EventArgs e)
	{
		await Navigation.PushModalAsync(new HomePage(), true);
	}
	async void OnSignUpClicked(object sender, EventArgs args)
	{
		signUpPage ??= new SignUpPage(this);
        await Navigation.PushModalAsync(signUpPage, true);
	}
	async void OnForgotPasswordClicked(object sender, EventArgs args)
	{
	    await Navigation.PushModalAsync(new ForgotPasswordPage(this), true); 
	}
}
