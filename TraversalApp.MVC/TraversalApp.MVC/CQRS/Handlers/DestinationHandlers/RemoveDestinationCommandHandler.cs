using TraversalApp.MVC.CQRS.Commands.DestinationCommands;
using TraversalApp.Repository.Context;

namespace TraversalApp.MVC.CQRS.Handlers.DestinationHandlers
{
    public class RemoveDestinationCommandHandler
    {
        private readonly AppDbContext _context;

        public RemoveDestinationCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public void Handle(RemoveDestinationCommand command)
        {
            var values = _context.Destinations.Find(command.Id);
            _context.Destinations.Remove(values);
            _context.SaveChanges();
        }
    }
}
