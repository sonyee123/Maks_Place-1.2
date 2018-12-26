using System;
using System.Collections.Generic;
using Maks_Place.ViewModel;
using Xamarin.Forms;

namespace Maks_Place.GUI
{
    public partial class Omelette : ContentPage
    {
        OmeletteViewModel omelette;
        public Omelette()
        {
            InitializeComponent();
            BindingContext = omelette = new OmeletteViewModel();

        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            omelette.LoadOmeletteCommand.Execute(null);

        }
    }
}
