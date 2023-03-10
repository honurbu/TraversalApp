using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalApp.Core.Services;

namespace TraversalApp.MVC.Areas.Members.Controllers
{
    [Area("Members")]
    [AllowAnonymous]
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destination;

        public DestinationController(IDestinationService destination)
        {
            _destination = destination;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _destination.GetAllAsync();
            return View(values);
        }
    }
}
