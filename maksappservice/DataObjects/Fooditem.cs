using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Azure.Mobile.Server;

namespace maksappservice.DataObjects
{
    public class Fooditem: EntityData
    {
        public string menu_id { get; set; }
        public string item_name { get; set; }
        public double item_price { get; set; }
        public string category { get; set; }
    }
}