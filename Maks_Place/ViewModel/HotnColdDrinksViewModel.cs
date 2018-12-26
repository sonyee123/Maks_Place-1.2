using System;
using MvvmHelpers;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Diagnostics;
using Xamarin.Forms;
using System.Linq;
using Maks_Place.Model;
namespace Maks_Place.ViewModel
{
    public class HotnColdDrinksViewModel:BaseViewModel
    {
        AzureService azureService;
        public HotnColdDrinksViewModel()
        {
            azureService = DependencyService.Get<AzureService>();
        }

        public ObservableRangeCollection<Fooditem> Items { get; } = new ObservableRangeCollection<Fooditem>();


        string loadingMessage;
        public string LoadingMessage
        {
            get { return loadingMessage; }
            set { SetProperty(ref loadingMessage, value); }
        }

        ICommand loadHotnColdDrinksCommand;
        public ICommand LoadHotnColdDrinksCommand =>
            loadHotnColdDrinksCommand ?? (loadHotnColdDrinksCommand = new Command(async () => await ExecuteLoadHotnColdDrinksCommandAsync()));

        async Task ExecuteLoadHotnColdDrinksCommandAsync()
        {
            try
            {
                LoadingMessage = "Loading Menu...";
                IsBusy = true;
                var hnc = await azureService.GetHnC();
                Items.ReplaceRange(hnc);

            }
            catch (Exception ex)
            {
                Debug.WriteLine("OH NO!" + ex);

                await Application.Current.MainPage.DisplayAlert("Sync Error", "Unable to sync HotnColdDrinks, you may be offline", "OK");
            }
            finally
            {
                IsBusy = false;
            }


        }
    }
}
