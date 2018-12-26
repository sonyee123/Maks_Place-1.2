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
    public class NoodlesViewModel:BaseViewModel
    {
        AzureService azureService;
        public NoodlesViewModel()
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

        ICommand loadNoodlesCommand;
        public ICommand LoadNoodlesCommand =>
            loadNoodlesCommand ?? (loadNoodlesCommand = new Command(async () => await ExecuteLoadNoodlesCommandAsync()));

        async Task ExecuteLoadNoodlesCommandAsync()
        {
            try
            {
                LoadingMessage = "Loading Menu...";
                IsBusy = true;
                var nd = await azureService.GetNoodles();
                Items.ReplaceRange(nd);

            }
            catch (Exception ex)
            {
                Debug.WriteLine("OH NO!" + ex);

                await Application.Current.MainPage.DisplayAlert("Sync Error", "Unable to sync Noodles, you may be offline", "OK");
            }
            finally
            {
                IsBusy = false;
            }


        }
    }
}
