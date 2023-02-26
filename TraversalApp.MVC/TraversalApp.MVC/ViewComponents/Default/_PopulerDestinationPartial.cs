using Microsoft.AspNetCore.Mvc;
using TraversalApp.Core.Services;

namespace TraversalApp.MVC.ViewComponents.Default
{
    public class _PopulerDestinationPartial : ViewComponent
    {

        private readonly IDestinationService _destination;

        public _PopulerDestinationPartial(IDestinationService destination)
        {
            _destination = destination;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _destination.GetAllAsync();
            return View(values);
        }
    }
}
