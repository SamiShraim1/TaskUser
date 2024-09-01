using Microsoft.AspNetCore.Mvc;
using TaskUser.Data;
using TaskUser.Models;

namespace TaskUser.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext context;

        public UsersController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult InactiveUsers()
        {
            var inactiveUsers = context.Users.Where(u => !u.IsActive).ToList();
            return View(inactiveUsers);
        }


        [HttpPost]
        public IActionResult ActivateUser(Guid id)
        {
            var user = context.Users.Find(id);
            if (user != null)
            {
                user.IsActive = true;
                context.SaveChanges();
            }
            return RedirectToAction("InactiveUsers");
        }
    }
}
