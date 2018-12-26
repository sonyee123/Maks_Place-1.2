using System;
using System.Collections.Generic;
using Maks_Place.ViewModel;

using Xamarin.Forms;

namespace Maks_Place.GUI
{
    public partial class Rice : ContentPage
    {
        RiceViewModel rice;
        public Rice()
        {
            InitializeComponent();
            BindingContext = rice = new RiceViewModel();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            rice.LoadRiceCommand.Execute(null);

        }
    }
}
