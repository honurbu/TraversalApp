using Microsoft.AspNetCore.Mvc;
using TraversalApp.Core.Services;

namespace TraversalApp.MVC.ViewComponents.Default
{
    public class _SubAboutPartial : ViewComponent
    {
        private readonly ISubAboutService _subAbout;

        public _SubAboutPartial(ISubAboutService subAbout)
        {
            _subAbout = subAbout;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _subAbout.GetAllAsync();
            return View(values);
        }
    }
}
