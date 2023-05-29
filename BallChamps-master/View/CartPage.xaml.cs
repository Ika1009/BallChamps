namespace BallChamps.View;

public partial class CartPage : ContentPage
{
	public CartPage()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PaymentPage());
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SelectAddressPage());
    }
}