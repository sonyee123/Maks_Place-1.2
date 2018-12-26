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
    public class PorridgeViewModel:BaseViewModel
    {
        AzureService azureService;
        public PorridgeViewModel()
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

        ICommand loadPorridgeCommand;
        public ICommand LoadPorridgeCommand =>
            loadPorridgeCommand ?? (loadPorridgeCommand = new Command(async () => await ExecuteLoadPorridgeCommandAsync()));

        async Task ExecuteLoadPorridgeCommandAsync()
        {
            try
            {
                LoadingMessage = "Loading Menu...";
                IsBusy = true;
                var po = await azureService.GetPorridge();
                Items.ReplaceRange(po);

            }
            catch (Exception ex)
            {
                Debug.WriteLine("OH NO!" + ex);

                await Application.Current.MainPage.DisplayAlert("Sync Error", "Unable to sync Porridge, you may be offline", "OK");
            }
            finally
            {
                IsBusy = false;
            }


        }
    }
}
