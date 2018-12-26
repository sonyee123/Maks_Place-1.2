using System;
using System.Collections.Generic;
using Maks_Place.ViewModel;
using Xamarin.Forms;

namespace Maks_Place.GUI
{
    
    public partial class Porridge : ContentPage
    {
        PorridgeViewModel po;
        public Porridge()
        {
            InitializeComponent();
            BindingContext = po = new PorridgeViewModel();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            po.LoadPorridgeCommand.Execute(null);

        }
    }
}
