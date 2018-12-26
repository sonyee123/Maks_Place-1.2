using System;
using System.Collections.Generic;
using Maks_Place.ViewModel;

using Xamarin.Forms;

namespace Maks_Place.GUI
{
    public partial class Western : ContentPage
    {
        WesternViewModel western;
        public Western()
        {
            InitializeComponent();
            BindingContext = western = new WesternViewModel();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            western.LoadWesternCommand.Execute(null);

        }

    }
}
