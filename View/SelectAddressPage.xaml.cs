namespace BallChamps.View;

public partial class SelectAddressPage : ContentPage
{
	public SelectAddressPage()
	{
		InitializeComponent();
	}

    private async void Add_Address_Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new AddNewAddressPage());
    }
    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new PaymentPage());
    }
}