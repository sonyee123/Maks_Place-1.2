using System;
using System.Collections.Generic;
using Maks_Place.ViewModel;

using Xamarin.Forms;

namespace Maks_Place.GUI
{
    public partial class Prawn : ContentPage
    {
        PrawnViewModel prawn;
        public Prawn()
        {
            InitializeComponent();
            BindingContext = prawn = new PrawnViewModel();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            prawn.LoadPrawnCommand.Execute(null);

        }
    }
}
