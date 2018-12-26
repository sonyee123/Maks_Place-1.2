using System;
using System.Collections.Generic;
using Maks_Place.ViewModel;

using Xamarin.Forms;

namespace Maks_Place.GUI
{
    public partial class Hot_and_Cold_Drinks : ContentPage
    {
        HotnColdDrinksViewModel hnc;
        public Hot_and_Cold_Drinks()
        {
            InitializeComponent();
            BindingContext = hnc = new HotnColdDrinksViewModel();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            hnc.LoadHotnColdDrinksCommand.Execute(null);

        }
    }
}
