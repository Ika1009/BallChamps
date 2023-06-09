using BallChamps.ViewModels;

namespace BallChamps.View;

public partial class EditProfilePage : ContentPage
{
	public EditProfilePage()
	{
		InitializeComponent();
		BindingContext = new EditProfilePageViewModel();
	}
}