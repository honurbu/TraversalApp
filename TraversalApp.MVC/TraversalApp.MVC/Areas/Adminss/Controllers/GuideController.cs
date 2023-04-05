using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using TraversalApp.Core.DTOs;
using TraversalApp.Core.Entites;
using TraversalApp.Core.Services;
using TraversalApp.Service.Validations;

namespace TraversalApp.MVC.Areas.Adminss.Controllers
{
    [Area("Adminss")]

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


        [HttpGet]
        public IActionResult AddGuide()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddGuide(Guide guide)
        {
            GuideValidator guides = new GuideValidator();
            ValidationResult result = guides.Validate(guide);
                    
            if (result.IsValid)
            {
                await _guideService.AddAsync(guide);
                return RedirectToAction("Index");
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditGuide(int id)
        {
            var guides = await _guideService.GetByIdAsync(id);
            return View(guides);
        }

        [HttpPost]
        public async Task<IActionResult> EditGuide(Guide guide)
        {
            await _guideService.UpdateAsync(guide);
            return RedirectToAction("Index");
        }


        public IActionResult ChangeToTrue(int id)
        {
            _guideService.ChangeToTrueByGuid(id);
            return RedirectToAction("Index", "Adminss/Guide");
        }

        public IActionResult ChangeToFalse(int id)
        {
            _guideService.ChangeToFalseByGuid(id);
            return RedirectToAction("Index", "Adminss/Guide");
        }
    }
}
