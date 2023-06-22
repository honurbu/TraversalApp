using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TraversalApp.SignalRForMsSql.DAL;
using TraversalApp.SignalRForMsSql.Models;

namespace TraversalApp.SignalRForMsSql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        private readonly VisitorService _visitorService;
        public VisitorController(VisitorService visitorService)
        {
            _visitorService = visitorService;
        }

        [HttpGet]
        public IActionResult CreateVisitor()
        {
            Random random = new Random();
            Enumerable.Range(1, 10).ToList().ForEach(x =>
            {
                foreach (ECity item in Enum.GetValues(typeof(ECity)))
                {
                    var newVisitor = new Visitor
                    {
                        City = item,
                        CityVisitorCount = random.Next(100, 2000),
                        VisitDate = DateTime.UtcNow.Date.AddDays(x)
                    };
                    _visitorService.SaveVisitor(newVisitor).Wait();
                    System.Threading.Thread.Sleep(1000);
                }
            });
            return Ok("Ziyaretçiler başarıyla eklendi !");
        }
    }
}
