using Microsoft.AspNetCore.Mvc;
using TraversalApp.Core.Services;
using TraversalApp.Service.Services;

namespace TraversalApp.MVC.ViewComponents.MembersDashboard
{
    public class _GuideList : ViewComponent
    {
        private readonly IGuideService _guideService;

        public _GuideList(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        { 
            var guides = await _guideService.GetAllAsync();
            return View(guides); 
        }
    }
}
