using Microsoft.AspNetCore.Mvc;

namespace TraversalApp.MVC.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
