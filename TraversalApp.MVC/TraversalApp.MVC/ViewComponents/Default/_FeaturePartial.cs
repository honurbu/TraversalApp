using Microsoft.AspNetCore.Mvc;
using TraversalApp.Core.Services;

namespace TraversalApp.MVC.ViewComponents.Default
{
    public class _FeaturePartial : ViewComponent
    {
        private readonly IFeatureService _feature;

        public _FeaturePartial(IFeatureService feature)
        {
            _feature = feature;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _feature.GetAllAsync();
            return View(values);
        }
    }
}
