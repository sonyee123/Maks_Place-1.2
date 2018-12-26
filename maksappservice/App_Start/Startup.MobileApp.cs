using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Authentication;
using Microsoft.Azure.Mobile.Server.Config;
using maksappservice.DataObjects;
using maksappservice.Models;
using Owin;

namespace maksappservice
{
    public partial class Startup
    {
        public static void ConfigureMobileApp(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            new MobileAppConfiguration()
                .UseDefaultConfiguration()
                .ApplyTo(config);

            // Use Entity Framework Code First to create database tables based on your DbContext
            Database.SetInitializer(new MobileServiceInitializer());

            MobileAppSettingsDictionary settings = config.GetMobileAppSettingsProvider().GetMobileAppSettings();

            if (string.IsNullOrEmpty(settings.HostName))
            {
                app.UseAppServiceAuthentication(new AppServiceAuthenticationOptions
                {
                    // This middleware is intended to be used locally for debugging. By default, HostName will
                    // only have a value when running in an App Service application.
                    SigningKey = ConfigurationManager.AppSettings["SigningKey"],
                    ValidAudiences = new[] { ConfigurationManager.AppSettings["ValidAudience"] },
                    ValidIssuers = new[] { ConfigurationManager.AppSettings["ValidIssuer"] },
                    TokenHandler = config.GetAppServiceTokenHandler()
                });
            }

            app.UseWebApi(config);
        }
    }

    public class MobileServiceInitializer : CreateDatabaseIfNotExists<MobileServiceContext>
    {
        protected override void Seed(MobileServiceContext context)
        {
            List<Fooditem> fooditems = new List<Fooditem>
            {
                new Fooditem{menu_id="001",item_name="dadwadawd",item_price=0.13,category="Hoe"}
            };

            foreach (Fooditem fooditem in fooditems)
            {
                context.Set<Fooditem>().Add(fooditem);
            }

            List<Profile> useraccounts = new List<Profile>
            {
                new Profile{user_id="Yuvanesh42",password="yuva4201",first_name="Yuvaneshraj",last_name="Dayalan",phoneno="999",rewardpts=0,nightmode=false},
                new Profile{user_id="JoeHoe69",password="testing1",first_name="Joe",last_name="Hoe",phoneno="696",rewardpts=-10,nightmode=true},
                new Profile{user_id="Ambitionist",password="hanyeesucksdick",first_name="Han Yee",last_name="Lee",phoneno="81989835",rewardpts=5000,nightmode=false}
            };

            foreach (Profile Profile in useraccounts)
            {
                context.Set<Profile>().Add(Profile);
            }

            base.Seed(context);
        }
    }
}

