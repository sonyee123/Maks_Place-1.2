using System;
using System.Collections.Generic;
using Maks_Place.ViewModel;
using Xamarin.Forms;

namespace Maks_Place.GUI
{
    public partial class Squid : ContentPage
    {
        SquidViewModel squid;
        public Squid()
        {
            InitializeComponent();
            BindingContext = squid = new SquidViewModel();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            squid.LoadSquidCommand.Execute(null);

        }
    }
}
