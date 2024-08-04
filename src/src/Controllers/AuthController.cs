using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace src.Controllers
{
    public class AuthController : Controller
    {
        public ActionResult Index()
        {
            return View("Login");
        }
    }
}
