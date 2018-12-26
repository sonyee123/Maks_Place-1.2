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
    public class CrabViewModel:BaseViewModel
    {
        AzureService azureService;
        public CrabViewModel()
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

        ICommand loadCrabCommand;
        public ICommand LoadCrabCommand =>
            loadCrabCommand ?? (loadCrabCommand = new Command(async () => await ExecuteLoadCrabCommandAsync()));

        async Task ExecuteLoadCrabCommandAsync()
        {
            try
            {
                LoadingMessage = "Loading Menu...";
                IsBusy = true;
                var nd = await azureService.GetCrab();
                Items.ReplaceRange(nd);

            }
            catch (Exception ex)
            {
                Debug.WriteLine("OH NO!" + ex);

                await Application.Current.MainPage.DisplayAlert("Sync Error", "Unable to sync Crab, you may be offline", "OK");
            }
            finally
            {
                IsBusy = false;
            }


        }
    }
}
