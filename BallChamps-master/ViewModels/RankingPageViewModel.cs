
using ApiClient;
using BallChamps.Domain;
using BallChamps.Services;
using BallChamps.View;
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

        public ICommand SelectedProfileCommand { get; }
        public ICommand LoadItemsCommand;


        public RankingPageViewModel()
        {
            InitData();
            SelectedProfileCommand = new Command<Profile>(OnSelectedUserProfileCommand);

            // SelectedProfileCommand = new Command(OnSelectedProfileCommand);

        }



        public async void InitData()
        {
            this.IsRefreshing = true;

            List<Profile> list;

            try
            {
                list = await ProfileApi.GetProfiles(await UserService.GetTokenAsync());
            }
            catch (Exception ex)
            {
                if (ex is UnauthorizedAccessException) // token has expired
                {
                    UserService.RemoveToken();
                    await Shell.Current.DisplayAlert("Your session has expired.", "Please login again!", "OK");
                    await Shell.Current.GoToAsync("Login");
                    return;
                }
                await Shell.Current.DisplayAlert("Something went wrong.", ex.Message, "OK");
                list = new();
            }

            ProfileCollection = new ObservableCollection<Profile>(list);

            this.IsRefreshing = false;
        }

        public async void OnSelectedUserProfileCommand(Profile profile)
        {
            try
            {
                await Shell.Current.Navigation.PushAsync(new ProfilePage(profile));
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
                    ProfileCollection.Clear();
                    this.InitData();
                }));
            }
        }

    }
}
