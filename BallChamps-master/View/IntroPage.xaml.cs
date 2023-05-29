namespace BallChamps.View;

public partial class IntroPage : ContentPage
{
	public IntroPage()
	{
		InitializeComponent();
	}
    async void LoginButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Login");
    }
    async void SignUpButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//SignUp");
    }
}