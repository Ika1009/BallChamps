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
            List<Product> list;

            try
            {
                list = await ProductApi.GetProducts(await UserService.GetTokenAsync());
            }
            catch (Exception ex)
            {
                if (ex is UnauthorizedAccessException) // token has expired
                {
                    UserService.RemoveToken();
                    await Shell.Current.DisplayAlert("Your session has expired.", "Please login again!", "OK");
                    await Shell.Current.GoToAsync("Login");
                    return;
                }
                await Shell.Current.DisplayAlert("Something went wrong.", ex.Message, "OK");
                list = new();
            }

            Products = new ObservableCollection<Product>(list);
        }
    }
}