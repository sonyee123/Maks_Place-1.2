using System;
using System.Collections.Generic;
using Maks_Place.ViewModel;

using Xamarin.Forms;

namespace Maks_Place.GUI
{
    public partial class Chicken : ContentPage
    {
        ChickenViewModel chk;
        public Chicken()
        {
            InitializeComponent();
            BindingContext = chk = new ChickenViewModel();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            chk.LoadChickenCommand.Execute(null);

        }
    }
}
