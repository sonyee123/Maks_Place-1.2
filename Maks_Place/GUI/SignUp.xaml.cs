using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Maks_Place.GUI
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SignUp : ContentPage
	{
		public SignUp ()
		{
			InitializeComponent ();
		}
        async void ButtonLogIn_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new GUI.Accounts());
        }
    }

}