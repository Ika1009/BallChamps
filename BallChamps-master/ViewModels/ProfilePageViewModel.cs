﻿

using ApiClient;
using BallChamps.Domain;
using BallChamps.Models;
using BallChamps.Services;
using CommunityToolkit.Mvvm.ComponentModel;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BallChamps.ViewModels
{
    public partial class ProfilePageViewModel: BaseViewModel
    {
        //readonly IRankingRepository rankingReposiory = new RankingService();


        #region Command
        public ICommand MenuCommand { get; }
        public ICommand EditProfileCommand { get; }
        public ICommand RemoveFromSignUpListCommand { get; }
        public ICommand ShowButtonCommand { get; }
        public ICommand BackCommand { get; }
        public ICommand FollowsCommand { get; }
        public ICommand FollowingCommand { get; }
        public ICommand CommentsCommand { get; }
        public ICommand SettingCommand { get; }
        public ICommand GameHistoryCommand { get; }
        public ICommand UpdateProfileImageCommand { get; }
        #endregion

        [ObservableProperty]
        ObservableCollection<Profile> _profileCollection;

        [ObservableProperty]
        private new bool _isBusy;

        [ObservableProperty]
        private bool _isRefreshing;

        [ObservableProperty]
        private Profile _profile;

        [ObservableProperty]
        private Profile _selectedProfile;

        [ObservableProperty]
        private bool _isButtonEnable;

        [ObservableProperty]
        private string _commentsCount;

        [ObservableProperty]
        private string _following;

        [ObservableProperty]
        private string _followers;

        [ObservableProperty]
        private string _followingCount;

        [ObservableProperty]
        private string _imagePath;

        [ObservableProperty]
        private string _record;
    

        public ProfilePageViewModel()
        {
            InitData();
            
            SettingCommand = new Command(OnSettingCommand);
            EditProfileCommand = new Command(OnEditProfileCommand);
            BackCommand = new Command(OnBackCommand);
            UpdateProfileImageCommand = new Command(OnUpdateProfileImageCommand);
            FollowsCommand = new Command(OnFollowsCommand);
            FollowingCommand = new Command(OnFollowingCommand);
            CommentsCommand = new Command(OnCommentsCommand);
            GameHistoryCommand = new Command(OnGameHistoryCommand);
            MenuCommand = new Command(OnMenuCommand);
        }

        public ProfilePageViewModel(Profile profile)
        {
            SelectedProfile = profile;
            Record = SelectedProfile.WinPercentage + "-" + SelectedProfile.Losses;


            SettingCommand = new Command(OnSettingCommand);
            EditProfileCommand = new Command(OnEditProfileCommand);
            BackCommand = new Command(OnBackCommand);
            UpdateProfileImageCommand = new Command(OnUpdateProfileImageCommand);
            FollowsCommand = new Command(OnFollowsCommand);
            FollowingCommand = new Command(OnFollowingCommand);
            CommentsCommand = new Command(OnCommentsCommand);
            GameHistoryCommand = new Command(OnGameHistoryCommand);
            MenuCommand = new Command(OnMenuCommand);

        }
      
        public async Task InitData()
        {
            if(IsBusy)
            { return; }
            this.IsRefreshing = true;
            this.IsBusy = true;

            // SelectedProfile = await ProfileApi.GetProfileById("52c7c730-1770-46f7-842b-2a885f6c120a"UserService.CurrentUser.ProfileId, null);

            List<NewsFeed> list;
            try
            {
                SelectedProfile = await ProfileApi.GetProfileById(UserService.CurrentUser.ProfileId, await UserService.GetTokenAsync());
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
                SelectedProfile = new();
            }

            Record = SelectedProfile?.WinPercentage + "-" + SelectedProfile?.Losses;

            this.IsBusy = false;
            this.IsRefreshing = false;
        }

        public void OnEditProfileCommand()
        {
            try
            {
               

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void OnSettingCommand()
        {
            try
            {
               

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void OnFollowsCommand()
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void OnFollowingCommand()
        {
            try
            {
               

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void OnCommentsCommand()
        {
            try
            {
               

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }



        public void OnGameHistoryCommand()
        {
            try
            {

              

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void OnBackCommand()
        {
            Application.Current.MainPage.Navigation.PopAsync();

        }

        public void OnMenuCommand()
        {

            

        }

        public void OnUpdateProfileImageCommand()
        {


        }

    }
}
