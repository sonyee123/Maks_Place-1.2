using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Maks_Place;
using Maks_Place.Model;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Plugin.Connectivity;
using Xamarin.Forms;

[assembly: Dependency(typeof(AzureService))]
namespace Maks_Place
{
    public class AzureService
    {

        public MobileServiceClient Client { get; set; } = null;

        IMobileServiceSyncTable<Fooditem> menutable;
        IMobileServiceSyncTable<Profile> acctable;
        
        public async Task Initialize()
        {
            try { 
            if (Client?.SyncContext?.IsInitialized ?? false)
                return;
                var appUrl = "https://maksplace.azurewebsites.net";

                Client = new MobileServiceClient(appUrl);


            //InitialzeDatabase for path
            var path = "syncstore.db";
            path = Path.Combine(MobileServiceClient.DefaultDatabasePath, path);

            //setup our local sqlite store and intialize our table
            var store = new MobileServiceSQLiteStore(path);
           
            //Define table
            store.DefineTable<Fooditem>();
             store.DefineTable<Profile>();

            
            //Initialize SyncContext
            await Client.SyncContext.InitializeAsync(store); 

            //Get our sync table that will call out to azure
            menutable = Client.GetSyncTable<Fooditem>();
                acctable = Client.GetSyncTable<Profile>();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
            
        }

        

        public async Task SyncMenu()
        {
            try
            {
                if (!CrossConnectivity.Current.IsConnected)
                    return;

                await menutable.PullAsync("allfooditem", menutable.CreateQuery());

                await Client.SyncContext.PushAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unable to sync Menu, that is alright as we have Offline capabilities: " + ex);
            }

        }
        public async Task SyncAccount()
        {
            try
            {
                if (!CrossConnectivity.Current.IsConnected)
                    return;

                await acctable.PullAsync("allprofile", acctable.CreateQuery());

                await Client.SyncContext.PushAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unable to sync Account, that is alright as we have Offline capabilities: " + ex);
            }

        }

        public async Task<IEnumerable<Fooditem>> GetCans()
        {
            //Initialize & Sync
            await Initialize();
            await SyncMenu();

            return await menutable.Where(m => m.category == "Can Drinks").ToEnumerableAsync();
            
        }
        public async Task<IEnumerable<Fooditem>> GetDesserts()
        {
            await Initialize();
            await SyncMenu();

            return await menutable.Where(m => m.category == "Dessert").ToEnumerableAsync();
        }
        public async Task<IEnumerable<Fooditem>> GetRice()
        {
            await Initialize();
            await SyncMenu();

            return await menutable.Where(m => m.category == "Rice").ToEnumerableAsync();
        }
        public async Task<IEnumerable<Fooditem>> GetHnC()
        {
            await Initialize();
            await SyncMenu();

            return await menutable.Where(m => m.category == "Hot & Cold Drinks").ToEnumerableAsync();
        }
        public async Task<IEnumerable<Fooditem>> GetPorridge()
        {
            await Initialize();
            await SyncMenu();

            return await menutable.Where(m => m.category == "Porridge").ToEnumerableAsync();
        }
        public async Task<IEnumerable<Fooditem>> GetNoodles()
        {
            await Initialize();
            await SyncMenu();

            return await menutable.Where(m => m.category == "Noodles").ToEnumerableAsync();
        }
        public async Task<IEnumerable<Fooditem>> GetWestern()
        {
            await Initialize();
            await SyncMenu();

            return await menutable.Where(m => m.category == "Western").ToEnumerableAsync();
        }

        public async Task<IEnumerable<Fooditem>> GetOmelette()
        {
            await Initialize();
            await SyncMenu();

            return await menutable.Where(m => m.category == "Omelette").ToEnumerableAsync();
        }
        public async Task<IEnumerable<Fooditem>> GetHotPlate()
        {
            await Initialize();
            await SyncMenu();

            return await menutable.Where(m => m.category == "Hot Plate").ToEnumerableAsync();
        }
        public async Task<IEnumerable<Fooditem>> GetVegetable()
        {
            await Initialize();
            await SyncMenu();

            return await menutable.Where(m => m.category == "Vegetables").ToEnumerableAsync();
        }
        public async Task<IEnumerable<Fooditem>> GetChicken()
        {
            await Initialize();
            await SyncMenu();

            return await menutable.Where(m => m.category == "Chicken").ToEnumerableAsync();
        }
        public async Task<IEnumerable<Fooditem>> GetBeef()
        {
            await Initialize();
            await SyncMenu();

            return await menutable.Where(m => m.category == "Beef").ToEnumerableAsync();
        }
        public async Task<IEnumerable<Fooditem>> GetSquid()
        {
            await Initialize();
            await SyncMenu();

            return await menutable.Where(m => m.category == "Squid").ToEnumerableAsync();
        }
        public async Task<IEnumerable<Fooditem>> GetWholeFish()
        {
            await Initialize();
            await SyncMenu();

            return await menutable.Where(m => m.category == "Whole Fish").ToEnumerableAsync();
        }
        public async Task<IEnumerable<Fooditem>> GetPrawn()
        {
            await Initialize();
            await SyncMenu();

            return await menutable.Where(m => m.category == "Prawn").ToEnumerableAsync();
        }
        public async Task<IEnumerable<Fooditem>> GetCrab()
        {
            await Initialize();
            await SyncMenu();

            return await menutable.Where(m => m.category == "Crab").ToEnumerableAsync();
        }
        public async Task<IEnumerable<Fooditem>> GetSoup()
        {
            await Initialize();
            await SyncMenu();

            return await menutable.Where(m => m.category == "Soup").ToEnumerableAsync();
        }
        public async Task<IEnumerable<Fooditem>> GetSlicedFish()
        {
            await Initialize();
            await SyncMenu();

            return await menutable.Where(m => m.category == "Sliced Fish").ToEnumerableAsync();
        }
        public async Task<IEnumerable<Fooditem>> GetOthers()
        {
            await Initialize();
            await SyncMenu();

            return await menutable.Where(m => m.category == "Others").ToEnumerableAsync();
        }

        public async Task<IEnumerable<Profile>> GetAccDetails(string id, string password)
        {
            await Initialize();
            await SyncAccount();
           return await acctable.Where(m => m.user_id == id && m.password == password ).ToEnumerableAsync();
            
        }


#if __IOS__
         UIKit.UIViewController GetController()
        {
            var window = UIKit.UIApplication.SharedApplication.KeyWindow;
            var root = window.RootViewController;
            if (root == null)
                return null;

            var current = root;
            while (current.PresentedViewController != null)
            {
                current = current.PresentedViewController;
            }

            return current;
        }
#endif
    }
}
    
