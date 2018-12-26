using System;
using System.Collections.Generic;
using Maks_Place.ViewModel;

using Xamarin.Forms;

namespace Maks_Place.GUI
{
    public partial class Beef : ContentPage
    {
        BeefViewModel beef;
        public Beef()
        {
            InitializeComponent();
            BindingContext = beef = new BeefViewModel();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            beef.LoadBeefCommand.Execute(null);

        }
    }
}
