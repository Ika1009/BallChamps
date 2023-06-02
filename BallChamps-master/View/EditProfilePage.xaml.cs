using BallChamps.ViewModels;

namespace BallChamps.View;

public partial class EditProfilePage : ContentPage
{
	public EditProfilePage()
	{
		InitializeComponent();
		BindingContext = new EditProfilePageViewModel();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopAsync(true);
    }
}