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
    public class ProfileController : TableController<Profile>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Profile>(context, Request);
        }

        // GET tables/Profile
        public IQueryable<Profile> GetAllUserAccount()
        {
            return Query(); 
        }

        // GET tables/Profile/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Profile> GetUserAccount(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Profile/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Profile> PatchUserAccount(string id, Delta<Profile> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Profile
        public async Task<IHttpActionResult> PostUserAccount(Profile item)
        {
            Profile current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Profile/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteUserAccount(string id)
        {
             return DeleteAsync(id);
        }
    }
}
