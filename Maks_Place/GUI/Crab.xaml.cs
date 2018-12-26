using System;
using System.Collections.Generic;
using Maks_Place.ViewModel;

using Xamarin.Forms;

namespace Maks_Place.GUI
{
    public partial class Crab : ContentPage
    {
        CrabViewModel crab;
        public Crab()
        {
            InitializeComponent();
            BindingContext = crab = new CrabViewModel();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            crab.LoadCrabCommand.Execute(null);

        }
    }
}
