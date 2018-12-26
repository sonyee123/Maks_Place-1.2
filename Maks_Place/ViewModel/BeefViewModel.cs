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
    public class BeefViewModel:BaseViewModel
    {
        AzureService azureService;
        public BeefViewModel()
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

        ICommand loadBeefCommand;
        public ICommand LoadBeefCommand =>
            loadBeefCommand ?? (loadBeefCommand = new Command(async () => await ExecuteLoadBeefCommandAsync()));

        async Task ExecuteLoadBeefCommandAsync()
        {
            try
            {
                LoadingMessage = "Loading Menu...";
                IsBusy = true;
                var nd = await azureService.GetBeef();
                Items.ReplaceRange(nd);

            }
            catch (Exception ex)
            {
                Debug.WriteLine("OH NO!" + ex);

                await Application.Current.MainPage.DisplayAlert("Sync Error", "Unable to sync Beef, you may be offline", "OK");
            }
            finally
            {
                IsBusy = false;
            }


        }
    }
}
