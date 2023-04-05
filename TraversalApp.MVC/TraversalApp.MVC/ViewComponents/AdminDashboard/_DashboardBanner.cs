using Microsoft.AspNetCore.Mvc;

namespace TraversalApp.MVC.ViewComponents.AdminDashboard
{
    public class _DashboardBanner : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
