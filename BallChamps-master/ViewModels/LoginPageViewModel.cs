﻿using ApiClient;
using BallChamps.Domain;
using BallChamps.Services;
using BallChamps.View;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;

namespace BallChamps.ViewModels
{
    public partial class LoginPageViewModel: BaseViewModel
    {
        public ICommand LoginCommand { get; }
        public ICommand GoToRegisterCommand { get; }
        public ICommand ForgotPasswordCommand { get; }

        [ObservableProperty]
        private string _UserName;
        [ObservableProperty]
        private string _Password;
        [ObservableProperty]
        private string _Email;

        public LoginPageViewModel()
        {
            LoginCommand = new Command(OnLoginCommand);
            //GoToRegisterCommand = new Command(OnGoToRegisterCommand);
            //ForgotPasswordCommand = new Command(OnGoToForgotPasswordCommand);
        }

        public async void OnLoginCommand()
        {
            if (string.IsNullOrEmpty(UserName)) { await Shell.Current.DisplayAlert("Alert", "You need to fill in the username", "OK"); return; }
            if (string.IsNullOrEmpty(Password)) { await Shell.Current.DisplayAlert("Alert", "You need to fill in the password", "OK"); return; }

            try
            {
                IsBusy = true;

                User _userResult = await APIService.LoginAsync(UserName, Password);

                if (_userResult != null)
                {
                    //Set Current User Variables
                    if (_userResult.Token != null) UserService.CurrentUser.Token = _userResult.Token; // the Token is null in the Database
                    UserService.CurrentUser.ProfileId = _userResult.ProfileId;
                    UserService.CurrentUser.UserId = _userResult.UserId;
                    UserService.CurrentUser.AccessLevel = _userResult.AccessLevel;

                    await Shell.Current.GoToAsync("//Home/HomePage");
                }
                else
                    throw new Exception("Something went wrong");
            }
            catch (Exception ex) { await Shell.Current.DisplayAlert("Alert", ex.Message, "OK"); }

            IsBusy = false;
            return;
        }

            public async void OnGoToRegisterCommand()
            {

                    await Shell.Current.GoToAsync($"//{nameof(SignUpPage)}");
            }

            public async void OnGoToForgotPasswordCommand()
            {

                await Shell.Current.GoToAsync($"//{nameof(ForgotPasswordPage)}");
            }
        }
}