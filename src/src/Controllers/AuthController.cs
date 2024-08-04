using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace src.Controllers
{
    public class AuthController : Controller
    {
        [Route("/")]
        [Route("[controller]/Login")]
        public ActionResult Index()
        {
            return View("Login");
        }

        public ActionResult Register()
        {
            return View("Register");
        }
    }
}
