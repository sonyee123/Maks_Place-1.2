using System;
using System.Collections.Generic;
using Maks_Place.ViewModel;

using Xamarin.Forms;

namespace Maks_Place.GUI
{
    public partial class Noodles : ContentPage
    {
        NoodlesViewModel nd;
        public Noodles()
        {
            InitializeComponent();
            BindingContext = nd = new NoodlesViewModel();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            nd.LoadNoodlesCommand.Execute(null);

        }
    }
}
