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
    public class OmeletteViewModel:BaseViewModel
    {
        AzureService azureService;
        public OmeletteViewModel()
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

        ICommand loadOmeletteCommand;
        public ICommand LoadOmeletteCommand =>
            loadOmeletteCommand ?? (loadOmeletteCommand = new Command(async () => await ExecuteLoadOmeletteCommandAsync()));

        async Task ExecuteLoadOmeletteCommandAsync()
        {
            try
            {
                LoadingMessage = "Loading Menu...";
                IsBusy = true;
                var wes = await azureService.GetOmelette();
                Items.ReplaceRange(wes);

            }
            catch (Exception ex)
            {
                Debug.WriteLine("OH NO!" + ex);

                await Application.Current.MainPage.DisplayAlert("Sync Error", "Unable to sync Omelette, you may be offline", "OK");
            }
            finally
            {
                IsBusy = false;
            }


        }
    }
}
