using TraversalApp.Core.Entites;
using TraversalApp.MVC.CQRS.Commands.DestinationCommands;
using TraversalApp.Repository.Context;

namespace TraversalApp.MVC.CQRS.Handlers.DestinationHandlers
{
    public class CreateDestinationCommandHandler
    {
        private AppDbContext _context;

        public CreateDestinationCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public void Handle(CreateDestinationCommand command)
        {
            _context.Destinations.Add(new Destination
            {

                City = command.City,
                Price = command.Price,
                DayNight = command.DayNight,
                Capacity = command.Capacity,
                Status = true

            });

            _context.SaveChanges(); 
        }
    }
}
