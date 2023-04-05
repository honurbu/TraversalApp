using Microsoft.AspNetCore.Mvc;

namespace TraversalApp.MVC.Controllers
{
    public class ErrorPageController : Controller
    {
        public async Task<IActionResult> Error404(int code)
        {
            return View();
        }
    }
}
