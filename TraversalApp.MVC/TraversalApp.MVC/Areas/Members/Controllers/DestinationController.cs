using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalApp.Core.Services;

namespace TraversalApp.MVC.Areas.Members.Controllers
{
    [Area("Members")]
    [AllowAnonymous]
    [Route("Members/[controller]/[action]")]

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

        public async Task<IActionResult> GetCitiesSearchByName(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;
      
            var values = from x in await _destination.GetAllAsync() select x;
            if (!string.IsNullOrEmpty(searchString))
            {
                values = values.Where(y => y.City.Contains(searchString));
            }
            return View(values.ToList());
        }
    }
}
