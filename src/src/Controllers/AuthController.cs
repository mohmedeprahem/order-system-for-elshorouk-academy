using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using src.Models;
using src.Repositories;
using src.Utils;
using src.ViewModels;

namespace src.Controllers
{
    public class AuthController : Controller
    {
        public readonly UserRepository _userRepository;
        public readonly JwtTokenService _jwtTokenService;

        public AuthController(UserRepository userRepository, JwtTokenService jwtTokenService)
        {
            _userRepository = userRepository;
            _jwtTokenService = jwtTokenService;
        }

        [Route("/")]
        [Route("[controller]/Login")]
        public ActionResult Index()
        {
            return View("Login");
        }

        [HttpPost("/[controller]/Register")]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            User user = await _userRepository.GetUserByUsername(model.Username);

            if (user != null)
            {
                ModelState.AddModelError("Username", "Username already exists");
                return View(model);
            }

            model.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);

            User newUser = new User { Username = model.Username, Password = model.Password };

            User result = await _userRepository.Add(newUser);

            if (result == null)
            {
                ModelState.AddModelError("Username", "Username already exists");
                return View(model);
            }

            return View("Login");
        }

        public ActionResult Register()
        {
            return View("Register");
        }
    }
}
