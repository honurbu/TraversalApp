using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalApp.Core.Entites;

namespace TraversalApp.MVC.Areas.Members.Controllers
{
    [Area("Members")]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var users =await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.userName = users.Name + " " + users.Surname;
            ViewBag.userImage = users.ImageUrl;
            return View();
        }
    }
}
