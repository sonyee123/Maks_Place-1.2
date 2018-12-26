using System;
using System.Collections.Generic;
using Maks_Place.ViewModel;
using Xamarin.Forms;

namespace Maks_Place.GUI
{
    public partial class Soup : ContentPage
    {
        SoupViewModel soup;
        public Soup()
        {
            InitializeComponent();
            BindingContext = soup = new SoupViewModel();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            soup.LoadSoupCommand.Execute(null);

        }
    }
}
