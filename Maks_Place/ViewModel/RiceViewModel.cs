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
    public class RiceViewModel:BaseViewModel
    {
        AzureService azureService;
        public RiceViewModel()
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

        ICommand loadRiceCommand;
        public ICommand LoadRiceCommand =>
            loadRiceCommand ?? (loadRiceCommand = new Command(async () => await ExecuteLoadRiceCommandAsync()));

        async Task ExecuteLoadRiceCommandAsync()
        {
            try
            {
                LoadingMessage = "Loading Menu...";
                IsBusy = true;
                var rice = await azureService.GetRice();
                Items.ReplaceRange(rice);

            }
            catch (Exception ex)
            {
                Debug.WriteLine("OH NO!" + ex);

                await Application.Current.MainPage.DisplayAlert("Sync Error", "Unable to sync Rice, you may be offline", "OK");
            }
            finally
            {
                IsBusy = false;
            }


        }
    }
}
