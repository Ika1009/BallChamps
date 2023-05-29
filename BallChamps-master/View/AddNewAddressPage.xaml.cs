namespace BallChamps.View;

public partial class AddNewAddressPage : ContentPage
{
	public AddNewAddressPage()
	{
		InitializeComponent();
	}
    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}