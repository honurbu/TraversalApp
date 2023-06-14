using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalApp.Core.Repositories;
using TraversalApp.Core.Services;

namespace TraversalApp.MVC.Controllers
{
    [AllowAnonymous]
    public class GuideController : Controller
    {
        private readonly IGuideService _guideService;

        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public async Task<IActionResult> Index()
        {
            var guides = await _guideService.GetAllAsync();
            return View(guides);
        }
    }
}
