using System;
using System.Collections.Generic;
using System.Text;

namespace Maks_Place.Model
{
   public class Profile
    {
        public string Id { get; set; }

        public string user_id { get; set; }

        public string password { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set; }

        public string phoneno { get; set; }

        public bool nightmode { get; set; }

        public int rewardpts { get; set; }

        [Microsoft.WindowsAzure.MobileServices.Version]
        public string AzureVersion { get; set; }
    }
}
