
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
            //LoginCommand = new Command(OnLoginCommand);
            //GoToRegisterCommand = new Command(OnGoToRegisterCommand);
            //ForgotPasswordCommand = new Command(OnGoToForgotPasswordCommand);
        }

        //public async void OnLoginCommand()
        //{

        //    bool LoggedIn = false;
        //    IsBusy = true;
        //    //Authenticate User
        //    var _userResult = AuthenticateUser.AuthenticateUsers(Email, UserName, Password);

        //    if (_userResult.Result.Token != null)
        //    {
        //        LoggedIn = true;
        //        //Set Current User Variables
        //        CurrentUser.Token = _userResult.Result.Token;
        //        CurrentUser.UserProfileId = _userResult.Result.UserProfileId;
        //        CurrentUser.UserId = _userResult.Result.UserId;
        //        CurrentUser.AccessLevel = _userResult.Result.AccessLevel;
        //        CurrentUser.UserName = _userResult.Result.UserName;

        //    }
        //    else
        //    {
        //        LoggedIn = false;
        //        IsBusy = false;
        //        Application.Current.MainPage.DisplayAlert("Alert", "Incorrect Email or Password", "Ok");
        //        return;
        //    }


        //    if (LoggedIn)
        //    {
        //        IsBusy = false;
               
        //        await Shell.Current.GoToAsync($"//{nameof(NewsFeedPage)}");

        //    }


            
        //}

        //public async void OnGoToRegisterCommand()
        //{

        //        await Shell.Current.GoToAsync($"//{nameof(RegisterPage)}");
        //}

        //public async void OnGoToForgotPasswordCommand()
        //{

        //    await Shell.Current.GoToAsync($"//{nameof(RegisterPage)}");
        //}
    }
}
