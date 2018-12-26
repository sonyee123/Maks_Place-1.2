using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Maks_Place.GUI
{
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
        }
        async void ButtonDnD_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new GUI.DrinksNDesserts());
        }

        async void ButtonIndiv_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new GUI.Individual());
        }

        async void ButtonFam_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new GUI.Family());
        }

    }
}
