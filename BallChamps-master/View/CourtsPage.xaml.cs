using BallChamps.ViewModels;

namespace BallChamps.View;

public partial class CourtsPage : ContentPage
{
	public CourtsPage(CourtPageViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }

    private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new ViewProfilePage(), true);
    }
}