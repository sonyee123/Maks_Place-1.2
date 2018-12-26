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
    public class PrawnViewModel:BaseViewModel
    {
        AzureService azureService;
        public PrawnViewModel()
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

        ICommand loadPrawnCommand;
        public ICommand LoadPrawnCommand =>
            loadPrawnCommand ?? (loadPrawnCommand = new Command(async () => await ExecuteLoadPrawnCommandAsync()));

        async Task ExecuteLoadPrawnCommandAsync()
        {
            try
            {
                LoadingMessage = "Loading Menu...";
                IsBusy = true;
                var nd = await azureService.GetPrawn();
                Items.ReplaceRange(nd);

            }
            catch (Exception ex)
            {
                Debug.WriteLine("OH NO!" + ex);

                await Application.Current.MainPage.DisplayAlert("Sync Error", "Unable to sync Prawn, you may be offline", "OK");
            }
            finally
            {
                IsBusy = false;
            }


        }
    }
}
