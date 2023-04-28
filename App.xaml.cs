using BallChamps.View;

namespace BallChamps;

public partial class App : Application
{
    public App()
	{ 
		InitializeComponent();
        MainPage = new PaymentPage();
	}
}
