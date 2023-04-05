using Microsoft.AspNetCore.Mvc;
using TraversalApp.Core.Entites;
using TraversalApp.Core.Services;

namespace TraversalApp.MVC.Areas.Adminss.Controllers
{
    [Area("Adminss")]
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;

        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public async Task<IActionResult> Index()
        {
            var destination = await _destinationService.GetAllAsync();
            return View(destination);
        }

        [HttpGet]
        public async Task<IActionResult> AddDestination()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddDestination(Destination destination)
        {
            await _destinationService.AddAsync(destination);
            return RedirectToAction("Index");
        }
            
        public async Task<IActionResult> DeleteDestination(int id)
        {
            var destinations = await _destinationService.GetByIdAsync(id);
            await _destinationService.RemoveAsync(destinations);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateDestination(int id)
        {
            var destination = await _destinationService.GetByIdAsync(id);
            return View(destination);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateDestination(Destination destination)
        {
            await _destinationService.UpdateAsync(destination);
            return RedirectToAction("Index");
        }



    }
}
