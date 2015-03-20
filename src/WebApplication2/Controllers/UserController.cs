using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;

namespace WebApplication2.Controllers
{
    public class UserController : Controller
    {
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ActionResult Index()
        {
            return View(UserManager.Users);
        }
    }
}