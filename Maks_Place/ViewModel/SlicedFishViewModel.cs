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
    public class SlicedFishViewModel:BaseViewModel
    {
        AzureService azureService;
        public SlicedFishViewModel()
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

        ICommand loadSlicedFishCommand;
        public ICommand LoadSlicedFishCommand =>
            loadSlicedFishCommand ?? (loadSlicedFishCommand = new Command(async () => await ExecuteLoadSlicedFishCommandAsync()));

        async Task ExecuteLoadSlicedFishCommandAsync()
        {
            try
            {
                LoadingMessage = "Loading Menu...";
                IsBusy = true;
                var nd = await azureService.GetSlicedFish();
                Items.ReplaceRange(nd);

            }
            catch (Exception ex)
            {
                Debug.WriteLine("OH NO!" + ex);

                await Application.Current.MainPage.DisplayAlert("Sync Error", "Unable to sync SlicedFish, you may be offline", "OK");
            }
            finally
            {
                IsBusy = false;
            }


        }
    }
}
