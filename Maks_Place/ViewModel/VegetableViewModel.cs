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
    public class VegetableViewModel: BaseViewModel
    {
        AzureService azureService;
        public VegetableViewModel()
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

        ICommand loadVegetableCommand;
        public ICommand LoadVegetableCommand =>
            loadVegetableCommand ?? (loadVegetableCommand = new Command(async () => await ExecuteLoadVegetableCommandAsync()));

        async Task ExecuteLoadVegetableCommandAsync()
        {
            try
            {
                LoadingMessage = "Loading Menu...";
                IsBusy = true;
                var wes = await azureService.GetVegetable();
                Items.ReplaceRange(wes);

            }
            catch (Exception ex)
            {
                Debug.WriteLine("OH NO!" + ex);

                await Application.Current.MainPage.DisplayAlert("Sync Error", "Unable to sync Vegetable, you may be offline", "OK");
            }
            finally
            {
                IsBusy = false;
            }


        }
    }
}
