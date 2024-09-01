using Microsoft.AspNetCore.Mvc;
using TaskUser.Data;
using TaskUser.Models;

namespace TaskUser.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly ApplicationDbContext context;

        public AuthenticationController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Register(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return RedirectToAction(nameof(Login));
        }


        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(User user)
        {
            var checkUser = context.Users.Where(x => x.UserName == user.UserName && x.Password == user.Password);
            if (checkUser.Any())
            {
                return RedirectToAction("InactiveUsers","Users");
            }

            ViewBag.Error = "invalid username / password";
            return View(user);
        }
    }
}
