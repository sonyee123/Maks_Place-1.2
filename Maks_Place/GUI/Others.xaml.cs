using System;
using System.Collections.Generic;
using Maks_Place.ViewModel;
using Xamarin.Forms;

namespace Maks_Place.GUI
{
    public partial class Others : ContentPage
    {
        OthersViewModel others;
        public Others()
        {
            InitializeComponent();
            BindingContext = others = new OthersViewModel();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            others.LoadOthersCommand.Execute(null);

        }
    }
}
