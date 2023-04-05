using Microsoft.AspNetCore.Mvc;

namespace TraversalApp.MVC.Areas.Adminss.Controllers
{
    [Area("Adminss")]

    public class DashboardController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
