using TraversalCoreProject.CQRS.Commands.DestinationCommands;
using TraversalCoreProject.DataAccessLayer.Context;

namespace TraversalCoreProject.CQRS.Handlers.DestinationHandlers
{
    public class DeleteDestinationCommandHandler
    { private readonly TraversalContext _context;

        public DeleteDestinationCommandHandler(TraversalContext context)
        {
            _context = context;
        }
        public void Handle(DeleteDestinationComand command)
        {
            var values = _context.Destinations.Find(command.DestinationId);
            _context.Destinations.Remove(values);
            _context.SaveChanges();
        }
    }
}
