using TraversalApp.MVC.CQRS.Commands.DestinationCommands;
using TraversalApp.Repository.Context;

namespace TraversalApp.MVC.CQRS.Handlers.DestinationHandlers
{
    public class UpdateDestinationCommandHandler
    {
        private readonly AppDbContext _context;

        public UpdateDestinationCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public void Handle(UpdateDestinationCommand command)
        {
            var values = _context.Destinations.Find(command.Id);
            values.City = command.Cities;
            values.DayNight = command.DayNights;
            values.Price = command.Prices; 
            _context.SaveChanges();

        }
    }
}
