using Plugin.Connectivity;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Maks_Place.GUI
{
    public partial class Can_Drinks: ContentPage
    {
       CanDrinksViewModel cd;
        public Can_Drinks()
        {
            InitializeComponent();
            BindingContext = cd = new CanDrinksViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            cd.LoadCansCommand.Execute(null);

        }
    }
}
