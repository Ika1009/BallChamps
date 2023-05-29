
using ApiClient;
using BallChamps.Domain;
using BallChampsBaseClass.Common;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace BallChamps.ViewModels
{
    public partial class HomePageViewModel: BaseViewModel
    {


        [ObservableProperty]
        ObservableCollection<NewsFeed> _newsFeedCollection;

        [ObservableProperty]
        private bool _isRefreshing;

        [ObservableProperty]
        private NewsFeed _newsFeed;

        [ObservableProperty]
        private NewsFeed _selectedNewsFeed;

        public ICommand SelectedNewsFeedCommand { get; }
        public ICommand LoadItemsCommand;

        public HomePageViewModel()
        {
            InitData();

            SelectedNewsFeedCommand = new Command(OnSelectedNewsFeedCommand);
            
        }


        public async void InitData()
        {

            this.IsRefreshing = true;

            var list = await NewsFeedApi.GetNewsFeeds(null);

            NewsFeedCollection = new ObservableCollection<NewsFeed>(list);

            this.IsRefreshing = false;
        }

        public async void OnSelectedNewsFeedCommand()
        {
            try
            {
                _newsFeed = _selectedNewsFeed;
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
                    this.InitData();
                }));
            }
        }

    }
}
