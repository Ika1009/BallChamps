
using ApiClient;
using BallChamps.Domain;
using BallChamps.Services;
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
    public partial class RankingPageViewModel: BaseViewModel
    {
        

        [ObservableProperty]
        ObservableCollection<Profile> _profileCollection;

        [ObservableProperty]
        private bool _isRefreshing;

        [ObservableProperty]
        private Profile _profile;

        [ObservableProperty]
        private Profile _selectedProfile;

        public ICommand SelectedProfileCommand { get; }
        public ICommand LoadItemsCommand;


        public RankingPageViewModel()
        {
            InitData();

           // SelectedProfileCommand = new Command(OnSelectedProfileCommand);
            
        }


      
        public async void InitData()
        {
            this.IsRefreshing = true;

            var list = await ProfileApi.GetProfiles(UserService.CurrentUser.Token);

            ProfileCollection = new ObservableCollection<Profile>(list);

            this.IsRefreshing = false;
        }

        public async void OnSelectedUserProfileCommand()
        {
            try
            {
                _profile = _selectedProfile;
               // App.NavigationService.NavigateTo("SettingPage", _userProfile);

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
                    ProfileCollection.Clear();
                    this.InitData();
                }));
            }
        }

    }
}
