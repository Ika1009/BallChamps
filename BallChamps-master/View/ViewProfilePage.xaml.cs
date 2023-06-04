using BallChamps.Domain;
using BallChamps.ViewModels;

namespace BallChamps.View;

public partial class ViewProfilePage : ContentPage
{
	public ViewProfilePage(Court court)
	{
		InitializeComponent();
		BindingContext = new ViewProfilePageViewModel(court);
	}

    private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new WaitingListPage(), true);
    }
}