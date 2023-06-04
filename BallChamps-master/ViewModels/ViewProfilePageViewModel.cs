using BallChamps.Domain;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallChamps.ViewModels
{
    public partial class ViewProfilePageViewModel : BaseViewModel
    {
        private Court court;

        [ObservableProperty]
        string rating;

        [ObservableProperty]
        string courtName;

        [ObservableProperty]
        string imagePath;

        public ViewProfilePageViewModel(Court crt)
        {
            court = crt;
            rating = court.Rating;
            courtName = court.CourtName;
            ImagePath = court.ImagePath;

        }

    }
}
