using System;
using System.Collections.Generic;
using System.Text;

namespace Maks_Place.Model
{
    public class Fooditem
    {
        public string Id { get; set; }

        public string menu_id { get; set; }

        public string item_name { get; set; }

        public decimal item_price { get; set; }

        public string category { get; set; }

        [Microsoft.WindowsAzure.MobileServices.Version]
        public string AzureVersion { get; set; }
    }
}
