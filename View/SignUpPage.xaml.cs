namespace BallChamps.View;

public partial class SignUpPage : ContentPage
{
    LoginPage loginPageSender; // this is used to only have one instance of the loginPage for optimizations
    public SignUpPage()
	{
		InitializeComponent();
	}
    public SignUpPage(LoginPage lpSender)
    {
        InitializeComponent();
		loginPageSender = lpSender;
    }
    async void SignInButton_Clicked(object sender, EventArgs e)
	{
		await Navigation.PushModalAsync(new HomePage(), true);
	}
	async void OnLoginClicked(object sender, EventArgs args)
	{
	    await Navigation.PushModalAsync(loginPageSender, true);
	}
}
