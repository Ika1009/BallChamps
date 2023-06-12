using ApiClient;
using BallChamps.Domain;
using BallChamps.Services;
using BallChamps.View;
using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;
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
            CheckForAutoLoginAsync();

            LoginCommand = new Command(OnLoginCommand);
            //GoToRegisterCommand = new Command(OnGoToRegisterCommand);
            //ForgotPasswordCommand = new Command(OnGoToForgotPasswordCommand);
        }

        public async Task CheckForAutoLoginAsync()
        {
            string token = await UserService.GetTokenAsync();
            if (!string.IsNullOrEmpty(token))
            {
                // Token exists - auto-login

                // You might need to validate the token with the server and fetch the user's details from the given token

                // The API should be made on the server and when called
                // should look something along the lines of the commented method ValidateTokenAndGetUserDetailsAsync

                // await Shell.Current.GoToAsync("//Home/HomePage");
            }
        }
        //public async Task<User> ValidateTokenAndGetUserDetailsAsync(string token)
        //{
        //    Include the token in the request
        //    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        //    Send a request to a server endpoint that validates the token and returns user details
        //   HttpResponseMessage response = await httpClient.GetAsync(endpoint + "/validateTokenAndGetUserDetails");

        //    if (response.IsSuccessStatusCode)
        //    {
        //        string jsonResponse = await response.Content.ReadAsStringAsync();
        //        User user = JsonConvert.DeserializeObject<User>(jsonResponse);
        //        return user;
        //    }
        //}
        public async void OnLoginCommand()
        {
            if (string.IsNullOrEmpty(UserName)) { await Shell.Current.DisplayAlert("Alert", "You need to fill in the username", "OK"); return; }
            if (string.IsNullOrEmpty(Password)) { await Shell.Current.DisplayAlert("Alert", "You need to fill in the password", "OK"); return; }
            if (IsBusy) return;
            try
            {
                IsBusy = true;

                User _userResult = await APIService.LoginAsync(UserName, Password);

                if (_userResult != null)
                {
                    //Set Current User Variables

                    // the Token is null in the Database, that should not happen
                    if (_userResult.Token != null) await UserService.SetTokenAsync(_userResult.Token); // putting the token in the secure place
                    UserService.CurrentUser.Password = Password;
                    UserService.CurrentUser.Email = UserName;
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
