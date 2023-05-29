using ApiClient;
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

        public User CurrentUser;

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
                bool loggedin = await APIService.LoginAsync(UserName, Password);
                if (loggedin)
                    await Shell.Current.GoToAsync("//Home/HomePage");
                else
                    throw new Exception("Something went wrong");
            }
            catch (Exception ex) { await Shell.Current.DisplayAlert("Alert", ex.Message, "OK"); }

            IsBusy = false;


            /*bool LoggedIn = false;

            //Authenticate User
            var _userResult = AuthenticateUser.AuthenticateUsers(_Email, UserName, Password);

            if (_userResult.Result.Token != null)
            {
                LoggedIn = true;
                //Set Current User Variables
                CurrentUser.Token = _userResult.Result.Token;
                CurrentUser.ProfileId = _userResult.Result.ProfileId;
                CurrentUser.UserId = _userResult.Result.UserId;
                CurrentUser.AccessLevel = _userResult.Result.AccessLevel;

            }
            else
            {
                LoggedIn = false;
                IsBusy = false;
                await Application.Current.MainPage.DisplayAlert("Alert", "Incorrect Email or Password", "Ok");
                return;
            }


            if (LoggedIn)
            {
                IsBusy = false;
                await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
            }*/
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
