using BallChamps.ViewModels;

namespace BallChamps.View;

public partial class HomePage : ContentPage
{
	public HomePage(HomePageViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}