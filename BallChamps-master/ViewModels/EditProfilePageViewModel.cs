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
using BallChamps.Services;

using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.Windows.Input;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
        [ObservableProperty]
        string uploadedImageUrl;

        public EditProfilePageViewModel()
        {
            ChooseImageCommand = new Command(async () => await OnChooseImage());
            SaveProfileCommand = new Command(async () => await SaveProfile());
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
            UploadedImageUrl = profile.ImagePath;

            this.IsRefreshing = false;
        }

        public ICommand ChooseImageCommand { get; }
        public ICommand SaveProfileCommand { get; }


        Microsoft.Maui.Storage.FileResult pickedImageResult;
        private async Task OnChooseImage()
        {
            var result = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Please select an image",
                FileTypes = FilePickerFileType.Images,
            });

            if (result != null)
            {
                pickedImageResult = result;
            }
        }

        // This would typically be loaded from your JSON configuration
        private string storageConnectionString =
            "DefaultEndpointsProtocol=https;AccountName=ballchampsblobstorage;AccountKey=w3lU//fIpdeGKPHuWRCFb+NVVKfwxt9dR63xxF2Agjj8AWdRD95QEXqcMmEV4TqHFwlaVdgoByRS+AStx3HcOQ==;EndpointSuffix=core.windows.net";

        // The container where you want to upload the image
        private string blobContainerName = "userprofileimage";  // change to your desired container

        public async Task UploadImageAsync(Microsoft.Maui.Storage.FileResult fileResult, string userId)
        {
            // Create a BlobServiceClient object which will be used to create a container client
            BlobServiceClient blobServiceClient = new BlobServiceClient(storageConnectionString);

            // Create the container and return a container client object
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(blobContainerName);

            // Check if the container exists, and if not, create it
            if (!await containerClient.ExistsAsync())
            {
                await containerClient.CreateAsync();
            }

            // Get a reference to a blob
            BlobClient blobClient = containerClient.GetBlobClient($"{userId}.png");

            // Open the file stream
            using Stream fileStream = await fileResult.OpenReadAsync();

            // Upload file
            await blobClient.UploadAsync(fileStream, true);

            UploadedImageUrl = blobClient.Uri.AbsoluteUri;
        }

        public async Task SaveProfile()
        {
            if (pickedImageResult is not null)
            {
                try
                {
                    // Here, you'll want to upload the file to your cloud storage.
                    await UploadImageAsync(pickedImageResult, UserService.CurrentUser.UserId);
                }
                catch (Exception ex)
                {
                    await Shell.Current.DisplayAlert("Something went wrong when uploading an image", ex.Message, "OK");
                }
            }

            try
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
                    SkillTwo = SkillTwo,
                    ImagePath = UploadedImageUrl

                }, UserService.CurrentUser.Token);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Something went wrong when updating a profile data.", ex.Message, "OK");
            }


            await Shell.Current.GoToAsync("//Home/ProfilePage");
        }

    }
}