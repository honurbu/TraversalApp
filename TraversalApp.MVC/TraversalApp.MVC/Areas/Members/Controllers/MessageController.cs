using Microsoft.AspNetCore.Mvc;

namespace TraversalApp.MVC.Areas.Members.Controllers
{
    [Area("Members")]

    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
