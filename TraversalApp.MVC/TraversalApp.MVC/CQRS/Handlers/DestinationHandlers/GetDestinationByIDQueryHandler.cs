using TraversalApp.MVC.CQRS.Queries.DestinationQueries;
using TraversalApp.MVC.CQRS.Results.DestinationResults;
using TraversalApp.Repository.Context;

namespace TraversalApp.MVC.CQRS.Handlers.DestinationHandlers
{
    public class GetDestinationByIDQueryHandler
    {
        private readonly AppDbContext _context;

        public GetDestinationByIDQueryHandler(AppDbContext context)
        {
            _context = context;
        }


        public GetDestinationByIDQueryResult Handle(GetDestinationByIDQuery query)
        {
            var values = _context.Destinations.Find(query.DestId);
            return new GetDestinationByIDQueryResult {
                Id= values.Id,
                Cities = values.City,
                Prices = values.Price,
                DayNights = values.DayNight               
                 
            };
        }
    }
}
