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
            ChooseImageCommand = new Command(async () => await OnChooseImage());
            InitDataAsync();
        }

        public async Task InitDataAsync()
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

        public ICommand ChooseImageCommand { get; }
        public ICommand SaveProfileCommand { get; }


        private ImageSource _profileImage;
        public ImageSource ProfileImage
        {
            get { return _profileImage; }
            set
            {
                _profileImage = value;
                OnPropertyChanged();
            }
        }

        private async Task OnChooseImage()
        {
            var result = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Please select an image",
                FileTypes = FilePickerFileType.Images,
            });

            if (result != null)
            {
                var stream = await result.OpenReadAsync();
                ProfileImage = ImageSource.FromStream(() => stream);
            }
        }

        public async Task SaveProfile()
        {
            await ProfileApi.UpdateUserProfileById(new()
            {
                UserName = Username,
                FirstName = FirstName,
                LastName = LastName,
                Age = Age,
                StyleOfPlay = StyleOfPlay,
                Position = Position,
                SkillOne = SkillOne,
                SkillTwo = SkillTwo

            }, UserService.CurrentUser.Token);
        }

    }
}
/*Username = profile.UserName;
FirstName = profile.FirstName;
LastName = profile.LastName;
Age = profile.Age;
StyleOfPlay = profile.StyleOfPlay;
Position = profile.Position;
SkillOne = profile.SkillOne;
SkillTwo = profile.SkillTwo;*/