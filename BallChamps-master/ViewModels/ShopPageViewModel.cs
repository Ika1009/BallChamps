using ApiClient;
using BallChamps.Domain;
using BallChamps.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallChamps.ViewModels
{
    public partial class ShopPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        ObservableCollection<Product> products;

        public ShopPageViewModel()
        {
            InitData();
        }

        public async Task InitData()
        {
            var productsFromApi = await ProductApi.GetProducts(UserService.CurrentUser.Token);
            Products = new ObservableCollection<Product>(productsFromApi);
        }
    }
}