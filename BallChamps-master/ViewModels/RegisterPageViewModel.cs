
using ApiClient;
using BallChamps.Domain;
using BallChampsBaseClass.Common;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;

namespace BallChamps.ViewModels
{
    public partial class RegisterPageViewModel: BaseViewModel
    {
        public ICommand RegisterCommand { get; }

        [ObservableProperty]
        private string _UserName;
        [ObservableProperty]
        private string _Password;
        [ObservableProperty]
        private string _ConfirmPassword;
        [ObservableProperty]
        private string _Email;
        [ObservableProperty]
        private Profile _Profile;
        [ObservableProperty]
        private User _User;


        public RegisterPageViewModel()
        {
            RegisterCommand = new Command(OnRegisterCommand);
        }

        public async void OnRegisterCommand()
        {

            //bool LoggedIn = false;
            IsBusy = true;

            if (ConfirmPassword == User.Password)
            {

              


               // await UserApi.CreateUser(newUser.Item1, null);
               // await UserProfileApi.CreateUserProfile(newUser.Item2, null);

            }

        }
    }
}
