using BallChamps.ViewModels;

namespace BallChamps.View;

public partial class ProfilePage : ContentPage
{
	public ProfilePage(ProfilePageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
        
    }
	async void OnEditProfileButtonClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new EditProfilePage());
	}
}
