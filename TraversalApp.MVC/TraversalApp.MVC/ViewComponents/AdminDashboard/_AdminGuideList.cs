using Microsoft.AspNetCore.Mvc;

namespace TraversalApp.MVC.ViewComponents.AdminDashboard
{
    public class _AdminGuideList : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
