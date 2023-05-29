namespace BallChamps.View;

public partial class ProductDetailsPage : ContentPage
{
	public ProductDetailsPage()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new CartPage());
    }
}