using Microsoft.AspNetCore.Mvc;

namespace TraversalApp.MVC.ViewComponents.MembersDashboard
{
    public class _PlatformSettings : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
