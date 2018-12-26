using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Maks_Place.GUI
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            masterPage.lstham.ItemSelected += OnItemSelected;

        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                masterPage.lstham.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}
