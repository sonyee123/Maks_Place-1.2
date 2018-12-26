using System;
using System.Collections.Generic;
using Maks_Place.ViewModel;

using Xamarin.Forms;

namespace Maks_Place.GUI
{
    public partial class Desserts : ContentPage
    {
        DessertsViewModel ds;
        public Desserts()
        {
            InitializeComponent();
            BindingContext = ds = new DessertsViewModel() ;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ds.LoadDessertsCommand.Execute(null);

        }
    }
}
