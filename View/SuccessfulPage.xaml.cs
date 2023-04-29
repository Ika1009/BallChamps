namespace BallChamps.View;

public partial class SuccessfulPage : ContentPage
{
	public SuccessfulPage()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopToRootAsync();
		await Shell.Current.GoToAsync("//HomePage");
    }
}