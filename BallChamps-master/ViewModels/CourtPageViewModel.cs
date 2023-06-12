
using ApiClient;
using BallChamps.Domain;
using BallChamps.Services;
using BallChamps.View;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BallChamps.ViewModels
{
    public partial class CourtPageViewModel: BaseViewModel
    {
        

        [ObservableProperty]
        ObservableCollection<Court> _courtCollection;

        [ObservableProperty]
        private bool _isRefreshing;

        [ObservableProperty]
        private Court _court;

        public ICommand SelectedCourtCommand { get; }
        public ICommand LoadItemsCommand;

        public CourtPageViewModel()
        {
            InitData();
            SelectedCourtCommand = new Command<Court>(OnSelectedCourt);

        }



        public async void InitData()
        {


            this.IsRefreshing = true;

           
             var list = await CourtApi.GetCourts(await UserService.GetTokenAsync());

            CourtCollection = new ObservableCollection<Court>(list);

            this.IsRefreshing = false;
        }

        public async void OnSelectedCourt(Court selectedCourt)
        {
            try
            {
                await Shell.Current.Navigation.PushAsync(new ViewProfilePage(selectedCourt));

            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Something went wrong!", ex.Message, "OK");
            }
        }

        public ICommand RefreshViewCommand
        {
            get
            {
                return LoadItemsCommand ?? (LoadItemsCommand = new Command(() =>
                {
                    CourtCollection.Clear();
                    this.InitData();
                }));
            }
        }

    }
}
