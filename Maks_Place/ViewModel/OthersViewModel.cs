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
    public class OthersViewModel:BaseViewModel
    {
        AzureService azureService;
        public OthersViewModel()
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

        ICommand loadOthersCommand;
        public ICommand LoadOthersCommand =>
            loadOthersCommand ?? (loadOthersCommand = new Command(async () => await ExecuteLoadOthersCommandAsync()));

        async Task ExecuteLoadOthersCommandAsync()
        {
            try
            {
                LoadingMessage = "Loading Menu...";
                IsBusy = true;
                var nd = await azureService.GetOthers();
                Items.ReplaceRange(nd);

            }
            catch (Exception ex)
            {
                Debug.WriteLine("OH NO!" + ex);

                await Application.Current.MainPage.DisplayAlert("Sync Error", "Unable to sync Others, you may be offline", "OK");
            }
            finally
            {
                IsBusy = false;
            }


        }
    }
}
