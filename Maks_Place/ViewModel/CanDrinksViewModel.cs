using System;
using MvvmHelpers;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Diagnostics;
using Xamarin.Forms;
using System.Linq;
using Maks_Place.Model;

namespace Maks_Place
{
    public class CanDrinksViewModel : BaseViewModel
    {
        AzureService azureService;
        public CanDrinksViewModel()
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

        ICommand loadCansCommand;
        public ICommand LoadCansCommand =>
            loadCansCommand ?? (loadCansCommand = new Command(async () => await ExecuteLoadCanDrinksCommandAsync())); 

        async Task ExecuteLoadCanDrinksCommandAsync()
        {
            try 
            {
                LoadingMessage = "Loading Menu...";
                IsBusy = true;
                var cans = await azureService.GetCans();
                Items.ReplaceRange(cans);

            }
            catch (Exception ex) 
            {
                Debug.WriteLine("OH NO!" + ex);

                await Application.Current.MainPage.DisplayAlert("Sync Error", "Unable to sync Can Drinks, you may be offline", "OK");
            } 
            finally 
            {
                IsBusy = false;
            }


        }

    }
}

