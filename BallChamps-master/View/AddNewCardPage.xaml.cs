namespace BallChamps.View;

public partial class AddNewCardPage : ContentPage
{
	public AddNewCardPage()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		// Save clicked
		await Navigation.PopAsync();
    }
}