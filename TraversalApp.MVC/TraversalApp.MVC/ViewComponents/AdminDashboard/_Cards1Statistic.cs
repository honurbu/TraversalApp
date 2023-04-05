using Microsoft.AspNetCore.Mvc;
using TraversalApp.Repository.Context;

namespace TraversalApp.MVC.ViewComponents.AdminDashboard
{
    public class _Cards1Statistic : ViewComponent
    {
        private readonly AppDbContext _context;

        public _Cards1Statistic(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.v1 = _context.Destinations.Count();
            ViewBag.v2 = _context.Users.Count();
            return View();
        }
    }
}
