using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using maksappservice.DataObjects;
using maksappservice.Models;

namespace maksappservice.Controllers
{
    public class FooditemController : TableController<Fooditem>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Fooditem>(context, Request);
        }

        // GET tables/Fooditem
        public IQueryable<Fooditem> GetAllFooditem()
        {
            return Query(); 
        }

        // GET tables/Fooditem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Fooditem> GetFooditem(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Fooditem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Fooditem> PatchFooditem(string id, Delta<Fooditem> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Fooditem
        public async Task<IHttpActionResult> PostFooditem(Fooditem item)
        {
            Fooditem current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Fooditem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteFooditem(string id)
        {
             return DeleteAsync(id);
        }
    }
}
