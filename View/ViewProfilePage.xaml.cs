namespace BallChamps.View;

public partial class ViewProfilePage : ContentPage
{
	public ViewProfilePage()
	{
		InitializeComponent();
	}

    private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new WaitingListPage(), true);
    }
}