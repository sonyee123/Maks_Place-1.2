using System;
using System.Collections.Generic;
using Maks_Place.ViewModel;

using Xamarin.Forms;

namespace Maks_Place.GUI
{
    public partial class HotPlate : ContentPage
    {
        HotPlateViewModel hp;
        public HotPlate()
        {
            InitializeComponent();
            BindingContext = hp = new HotPlateViewModel();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            hp.LoadHotPlateCommand.Execute(null);

        }
    }
}
