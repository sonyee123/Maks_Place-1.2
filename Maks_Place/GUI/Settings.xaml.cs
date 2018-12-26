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
    public partial class Setting : ContentPage
    {
        int i = 1;
        Switch switcher = new Switch();
        public Setting()
        {
            InitializeComponent();
        }
        void ButtonNightMode_Clicked(object sender, System.EventArgs e)
        {
            i += 1;
            if (i % 2 == 1)
            {

                App.Current.Resources["textColor"] = Color.Black;
                App.Current.Resources["backgroundColor1"] = Color.LightYellow;
                App.Current.Resources["textColor2"] = Color.Orange;
                App.Current.Resources["backgroundColor2"] = Color.Orange;
                App.Current.Resources["textColor3"] = Color.Black;
                App.Current.Resources["backgroundColor3"] = Color.LightYellow;
                App.Current.Resources["textColor4"] = Color.Blue;
                App.Current.Resources["backgroundColor4"] = Color.White;
                App.Current.Resources["textColor5"] = Color.DimGray;
                App.Current.Resources["backgroundColor5"] = Color.White;

            }
            else
            {

                App.Current.Resources["textColor"] = Color.White;
                App.Current.Resources["backgroundColor1"] = Color.Black;
                App.Current.Resources["textColor2"] = Color.Tomato;
                App.Current.Resources["backgroundColor2"] = Color.Tomato;
                App.Current.Resources["textColor3"] = Color.LightYellow;
                App.Current.Resources["backgroundColor3"] = Color.Black;
                App.Current.Resources["textColor4"] = Color.Beige;
                App.Current.Resources["backgroundColor4"] = Color.LightYellow;
                App.Current.Resources["textColor5"] = Color.Gray;
                App.Current.Resources["backgroundColor5"] = Color.DarkRed;


            }
        }
    }
}