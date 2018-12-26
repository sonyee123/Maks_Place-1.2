using System;
using System.Collections.Generic;
using Maks_Place.ViewModel;

using Xamarin.Forms;

namespace Maks_Place.GUI
{
    public partial class Vegetable : ContentPage
    {
        VegetableViewModel veg;
        public Vegetable()
        {
            InitializeComponent();
            BindingContext = veg = new VegetableViewModel();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            veg.LoadVegetableCommand.Execute(null);

        }
    }
}
