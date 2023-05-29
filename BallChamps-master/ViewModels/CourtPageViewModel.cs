
using ApiClient;
using BallChamps.Domain;
using CommunityToolkit.Mvvm.ComponentModel;
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

        [ObservableProperty]
        private Court _selectedCourt;

        public ICommand SelectedCourtCommand { get; }
        public ICommand LoadItemsCommand;

        


        public CourtPageViewModel()
        {
            InitData();

            SelectedCourtCommand = new Command(OnSelectedCourtCommand);
            
        }


      
        public async void InitData()
        {


            this.IsRefreshing = true;

           
             var list = await CourtApi.GetCourts(null);


            CourtCollection = new ObservableCollection<Court>(list);

            _courtCollection = CourtCollection;

            this.IsRefreshing = false;
        }

        public async void OnSelectedCourtCommand()
        {
            try
            {
                _court = _selectedCourt;
               

            }
            catch (Exception ex)
            {
                throw ex;
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
