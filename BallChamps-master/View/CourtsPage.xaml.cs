using BallChamps.Domain;
using BallChamps.ViewModels;

namespace BallChamps.View;

public partial class CourtsPage : ContentPage
{
	public CourtsPage(CourtPageViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        var court = ((sender as Frame)?.BindingContext as Court);
        if (court == null) return;
        var viewModel = this.BindingContext as CourtPageViewModel;
        viewModel?.SelectedCourtCommand.Execute(court);
    }
}