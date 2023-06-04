using BallChamps.ViewModels;

namespace BallChamps.View;

public partial class RankPage : ContentPage
{
	public RankPage()
	{
		InitializeComponent();
		BindingContext = new RankingPageViewModel();
	}
}