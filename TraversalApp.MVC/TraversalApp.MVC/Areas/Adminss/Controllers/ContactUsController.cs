using Microsoft.AspNetCore.Mvc;
using TraversalApp.Core.Services;

namespace TraversalApp.MVC.Areas.Adminss.Controllers
{
    [Area("Adminss")]
    public class ContactUsController : Controller
    {
        private readonly IContactUsService _contactUsService;

        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        public async Task<IActionResult> Index()
        {
            var messages = await _contactUsService.GetAllAsync();
            return View(messages);
        }

        public  IActionResult ContactUsStatusChangeToFalse(int id)
        {
            _contactUsService.ContactUsStatusChangeToFalse(id);
            return RedirectToAction("Index");  
        }

        public  IActionResult ContactUsStatusChangeToTrue(int id)
        {
            _contactUsService.ContactUsStatusChangeToTrue(id);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> DeleteMessage(int id)
        {
            var messages = await _contactUsService.GetByIdAsync(id);
            await _contactUsService.RemoveAsync(messages);
            return RedirectToAction("Index");
        }


    }
}
