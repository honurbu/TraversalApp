using Microsoft.AspNetCore.Mvc;
using TraversalApp.Core.Entites;
using TraversalApp.Core.Services;

namespace TraversalApp.MVC.Controllers
{
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


        [HttpGet]
        public async Task<IActionResult> DestinationDetails(int id)
        {
            ViewBag.i = id;
            var values = await _destination.GetByIdAsync(id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> DestinationDetails(Destination destination)
        {
            return View();
        }
    }
}
