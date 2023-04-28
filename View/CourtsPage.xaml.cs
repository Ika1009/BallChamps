namespace BallChamps.View;

public partial class CourtsPage : ContentPage
{
	public CourtsPage()
	{
		InitializeComponent();
	}

    private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new ViewProfilePage(), true);
    }
}