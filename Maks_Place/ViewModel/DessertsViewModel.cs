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
    public class DessertsViewModel: BaseViewModel
    {
        AzureService azureService;
        public DessertsViewModel()
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

        ICommand loadDessertsCommand;
        public ICommand LoadDessertsCommand =>
            loadDessertsCommand ?? (loadDessertsCommand = new Command(async () => await ExecuteLoadDessertsCommandAsync()));

        async Task ExecuteLoadDessertsCommandAsync()
        {
            try
            {
                LoadingMessage = "Loading Menu...";
                IsBusy = true;
                var desserts = await azureService.GetDesserts();
                Items.ReplaceRange(desserts);

            }
            catch (Exception ex)
            {
                Debug.WriteLine("OH NO!" + ex);

                await Application.Current.MainPage.DisplayAlert("Sync Error", "Unable to sync Desserts, you may be offline", "OK");
            }
            finally
            {
                IsBusy = false;
            }


        }

    }
}
