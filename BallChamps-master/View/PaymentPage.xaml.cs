namespace BallChamps.View;

public partial class PaymentPage : ContentPage
{
	public PaymentPage()
	{
		InitializeComponent();
	}

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddNewCardPage());
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SuccessfulPage());
        //await Navigation.PushAsync(new SuccessfulPage());
    }
}