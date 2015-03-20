using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;

namespace WebApplication2.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationUserManager _userManager;

        public UserController(ApplicationUserManager userManager)
        {
            _userManager = userManager;
        }
       
        public ActionResult Index()
        {
            return View(_userManager.Users);
        }
    }
}