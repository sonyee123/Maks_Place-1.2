using System;
using System.Collections.Generic;
using Maks_Place.ViewModel;

using Xamarin.Forms;

namespace Maks_Place.GUI
{
    public partial class SlicedFish : ContentPage
    {
        SlicedFishViewModel slicedFish;
        public SlicedFish()
        {
            InitializeComponent();
            BindingContext = slicedFish = new SlicedFishViewModel();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            slicedFish.LoadSlicedFishCommand.Execute(null);

        }
    }
}
