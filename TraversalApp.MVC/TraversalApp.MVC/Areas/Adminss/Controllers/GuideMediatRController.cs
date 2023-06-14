using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalApp.MVC.CQRS.Handlers.GuideHandlers;
using TraversalApp.MVC.CQRS.Queries.GuideQueries;
using TraversalCoreProje.CQRS.Commands.GuideCommands;

namespace TraversalApp.MVC.Areas.Adminss.Controllers
{
    [Area("Adminss")]
    [AllowAnonymous]
    public class GuideMediatRController : Controller
    {
        private readonly IMediator _mediatr;

        public GuideMediatRController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _mediatr.Send(new GetAllGuideQuery());
            return View(values);
        }

        [HttpGet]
        public  async Task<IActionResult> GetGuideById(int id)
        {
            var values = await _mediatr.Send(new GetGuideByIDQuery(id));
            return View(values);
        }

        [HttpGet]
        public IActionResult AddGuide()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddGuide(CreateGuideCommand command)
        {
            await _mediatr.Send(command);
            return RedirectToAction("Index");
        }
    }
}
