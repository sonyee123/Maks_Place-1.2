using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maks_Place.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MvvmHelpers;
using Maks_Place.ViewModel;

namespace Maks_Place.GUI
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Accounts : ContentPage
	{
        AzureService azureService;
       

        public Accounts ()
		{
            InitializeComponent ();
            azureService = DependencyService.Get<AzureService>();
		}
        async void ButtonSignUp_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new GUI.SignUp());
        }

        public ObservableRangeCollection<Profile> Items { get; } = new ObservableRangeCollection<Profile>();

        async void Button_Clicked(object sender, EventArgs e)
        {
            var na = await azureService.GetAccDetails(usernametxt.Text,passwordtxt.Text);
            Items.ReplaceRange(na);

            if(Items.Count==1)
            {
                errMsg.Text = "Hi";
            }
            else
            {
                errMsg.Text = "bye";
            }

        }
    }
}