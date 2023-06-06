using BallChamps.ViewModels;
using System.Collections.ObjectModel;

namespace BallChamps.View;

public partial class ProductsPage : ContentPage
{
	public ProductsPage()
	{
		InitializeComponent();
        BindingContext = new ShopPageViewModel();
    }
    private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProductDetailsPage());
    }
}