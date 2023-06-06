using BallChamps.ViewModels;

namespace BallChamps.View;

public partial class ShopPage : ContentPage
{
	public ShopPage()
	{
		InitializeComponent();
	}

    private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new ProductsPage());
    }
}