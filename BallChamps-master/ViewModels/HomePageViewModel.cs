using ApiClient;
using BallChamps.Domain;
using BallChamps.Services;
using BallChampsBaseClass.Common;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace BallChamps.ViewModels
{
    public partial class HomePageViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<NewsFeed> _newsFeedCollection;
        private bool _isRefreshing;
        private NewsFeed _newsFeed;
        private NewsFeed _selectedNewsFeed;

        public ICommand SelectedNewsFeedCommand { get; }
        public ICommand LoadItemsCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        public HomePageViewModel()
        {
            SelectedNewsFeedCommand = new Command(OnSelectedNewsFeedCommand);
            LoadItemsCommand = new Command(async () => await GetNewsFeedData());
            LoadItemsCommand.Execute(null); // trigger the command on ViewModel construction
        }

        public async Task GetNewsFeedData()
        {
            IsRefreshing = true;
            List<NewsFeed> list;
            try
            {
                list = await NewsFeedApi.GetNewsFeeds(await UserService.GetTokenAsync());
            }
            catch(Exception ex)
            {
                if(ex is UnauthorizedAccessException) // token has expired
                {
                    UserService.RemoveToken();
                    await Shell.Current.DisplayAlert("Your session has expired.", "Please login again!", "OK");
                    await Shell.Current.GoToAsync("Login");
                    return;
                }
                await Shell.Current.DisplayAlert("Something went wrong.", ex.Message, "OK");
                list = new();
            }

            NewsFeedCollection = new ObservableCollection<NewsFeed>(list);
            IsRefreshing = false;
        }

        public async void OnSelectedNewsFeedCommand()
        {
            try
            {
                _newsFeed = SelectedNewsFeed;
                // App.NavigationService.NavigateTo("SettingPage", _userProfile);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ICommand RefreshViewCommand
        {
            get
            {
                return LoadItemsCommand ?? (LoadItemsCommand = new Command(() =>
                {
                    NewsFeedCollection.Clear();
                    this.GetNewsFeedData();
                }));
            }
        }

        // Implement properties with RaisePropertyChanged

        public ObservableCollection<NewsFeed> NewsFeedCollection
        {
            get => _newsFeedCollection;
            set
            {
                if (_newsFeedCollection != value)
                {
                    _newsFeedCollection = value;
                    RaisePropertyChanged();
                }
            }
        }

        public bool IsRefreshing
        {
            get => _isRefreshing;
            set
            {
                if (_isRefreshing != value)
                {
                    _isRefreshing = value;
                    RaisePropertyChanged();
                }
            }
        }

        public NewsFeed SelectedNewsFeed
        {
            get => _selectedNewsFeed;
            set
            {
                if (_selectedNewsFeed != value)
                {
                    _selectedNewsFeed = value;
                    RaisePropertyChanged();
                }
            }
        }

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}