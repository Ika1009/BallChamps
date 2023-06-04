using BallChamps.Domain;

namespace BallChamps.View;

public partial class ViewProfilePage : ContentPage
{
	Court court;
	public ViewProfilePage(Court court)
	{
		InitializeComponent();
		this.court = court;
	}

    private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new WaitingListPage(), true);
    }
}