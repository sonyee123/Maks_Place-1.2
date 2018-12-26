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
    public class HotPlateViewModel:BaseViewModel
    {
        AzureService azureService;
        public HotPlateViewModel()
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

        ICommand loadHotPlateCommand;
        public ICommand LoadHotPlateCommand =>
            loadHotPlateCommand ?? (loadHotPlateCommand = new Command(async () => await ExecuteLoadHotPlateCommandAsync()));

        async Task ExecuteLoadHotPlateCommandAsync()
        {
            try
            {
                LoadingMessage = "Loading Menu...";
                IsBusy = true;
                var nd = await azureService.GetHotPlate();
                Items.ReplaceRange(nd);

            }
            catch (Exception ex)
            {
                Debug.WriteLine("OH NO!" + ex);

                await Application.Current.MainPage.DisplayAlert("Sync Error", "Unable to sync HotPlate, you may be offline", "OK");
            }
            finally
            {
                IsBusy = false;
            }


        }
    }
}
