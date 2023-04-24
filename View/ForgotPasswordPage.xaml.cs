namespace BallChamps.View;

public partial class ForgotPasswordPage : ContentPage
{
	LoginPage loginPageSender;
	public ForgotPasswordPage(LoginPage loginSender)
	{
		InitializeComponent();
		loginPageSender = loginSender;

    }
	async void OnLoginClicked(object sender, EventArgs args)
	{
	    await Navigation.PushModalAsync(loginPageSender, true);
	}
}
