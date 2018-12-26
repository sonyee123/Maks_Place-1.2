using System;
using System.Collections.Generic;
using Maks_Place.ViewModel;
using Xamarin.Forms;

namespace Maks_Place.GUI
{
    public partial class WholeFish : ContentPage
    {
        WholeFishViewModel wholeFish;
        public WholeFish()
        {
            InitializeComponent();
            BindingContext = wholeFish = new WholeFishViewModel();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            wholeFish.LoadWholeFishCommand.Execute(null);

        }
    }
}
