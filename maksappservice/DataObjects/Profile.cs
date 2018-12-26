using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Azure.Mobile.Server;

namespace maksappservice.DataObjects
{
    public class Profile: EntityData
    {
        public string user_id { get; set; }
        public string password { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string phoneno { get; set; }
        public bool nightmode { get; set; }
        public int rewardpts { get; set; }
    }
}