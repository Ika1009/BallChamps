using BallChamps.Domain;
using BallChamps.ViewModels;

namespace BallChamps.View;

public partial class RankPage : ContentPage
{
	public RankPage()
	{
		InitializeComponent();
		BindingContext = new RankingPageViewModel();
	}

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        var profile = ((sender as Frame)?.BindingContext as Profile);
        if (profile == null) return;
        var viewModel = this.BindingContext as RankingPageViewModel;
        viewModel?.SelectedProfileCommand.Execute(profile);
    }
}