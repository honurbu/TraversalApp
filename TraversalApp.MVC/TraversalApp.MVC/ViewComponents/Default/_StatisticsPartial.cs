using Microsoft.AspNetCore.Mvc;
using TraversalApp.Repository.Context;

namespace TraversalApp.MVC.ViewComponents.Default
{
    public class _StatisticsPartial : ViewComponent
    {
        private readonly AppDbContext _context;

        public _StatisticsPartial(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = _context.Destinations.Count();
            ViewBag.v2 = _context.Guides.Count();
            ViewBag.v3 = "1076";
            return View(); 
        }
    }
}
