using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiClient;
using BallChamps.Domain;
using BallChampsBaseClass.Common;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BallChamps.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        public bool _isBusy;

    }
}
