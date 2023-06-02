using ApiClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BallChamps.Domain;
using BallChamps.Models;
using BallChamps.Services;
using CommunityToolkit.Mvvm.ComponentModel;

using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.Windows.Input;

namespace BallChamps.ViewModels
{
    public partial class EditProfilePageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private bool _isRefreshing;

        [ObservableProperty]
        string username;
        [ObservableProperty]
        string firstName;
        [ObservableProperty]
        string lastName;
        [ObservableProperty]
        string age;
        [ObservableProperty]
        string styleOfPlay;
        [ObservableProperty]
        string position;
        [ObservableProperty]
        string skillOne;
        [ObservableProperty]
        string skillTwo;


        public EditProfilePageViewModel()
        {
            InitData();
        }

        public async Task InitData()
        {
            this.IsRefreshing = true;

            Profile profile = await ProfileApi.GetProfileById(UserService.CurrentUser.ProfileId, UserService.CurrentUser.Token);
            Username = profile.UserName;
            FirstName = profile.FirstName;
            LastName = profile.LastName;
            Age = profile.Age;
            StyleOfPlay = profile.StyleOfPlay;
            Position = profile.Position;
            SkillOne = profile.SkillOne;
            SkillTwo = profile.SkillTwo;

            this.IsRefreshing = false;
        }
    }
}
