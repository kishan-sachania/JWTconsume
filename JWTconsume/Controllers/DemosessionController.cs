using JWTconsume.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JWTconsume.Controllers
{
    public class DemosessionController : Controller
    {
        private readonly IHttpContextAccessor context;

        public DemosessionController(IHttpContextAccessor httpContextAccessor)
        {
            context = httpContextAccessor;
        }
        public IActionResult Index()
        {
            CurrentUser user =new CurrentUser();
            string CurrentUser=context.HttpContext.Session.GetString("StringUser");
            user = JsonConvert.DeserializeObject<CurrentUser>(CurrentUser);


            return View(user);
        }
    }
}
