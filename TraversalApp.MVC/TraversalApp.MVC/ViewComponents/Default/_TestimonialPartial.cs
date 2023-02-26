using Microsoft.AspNetCore.Mvc;
using TraversalApp.Core.Services;

namespace TraversalApp.MVC.ViewComponents.Default
{
    public class _TestimonialPartial : ViewComponent
    {
        private readonly ITestimonialService _testimonialService;

        public _TestimonialPartial(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _testimonialService.GetAllAsync();
            return View(values);
        }
    }
}
