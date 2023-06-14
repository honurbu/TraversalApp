using Microsoft.EntityFrameworkCore;
using TraversalApp.MVC.CQRS.Results.DestinationResults;
using TraversalApp.Repository.Context;

namespace TraversalApp.MVC.CQRS.Handlers.DestinationHandlers
{
    public class GetAllDestinationQueryHandler
    {    
        private readonly AppDbContext _context;

        public GetAllDestinationQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public List<GetAllDestinationQueryResult> Handle()
        {
            var values = _context.Destinations.Select(x=> new GetAllDestinationQueryResult
            {
                Id = x.Id,
                Capacities = (int)x.Capacity,
                Cities = x.City,
                DayNights = x.DayNight,
                Prices = x.Price
            }).AsNoTracking().ToList();

            return values;
        }
    }
}
