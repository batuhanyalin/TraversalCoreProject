using DocumentFormat.OpenXml.Bibliography;
using System.Diagnostics.Metrics;
using TraversalCoreProject.CQRS.Commands.DestinationCommands;
using TraversalCoreProject.DataAccessLayer.Context;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.CQRS.Handlers.DestinationHandlers
{
    public class UpdateDestinationCommandHandler
    {
        private readonly TraversalContext _context;

        public UpdateDestinationCommandHandler(TraversalContext context)
        {
            _context = context;
        }
        public void Handle(UpdateDestinationCommand command)
        {
            var values = _context.Destinations.Find(command.DestinationId);
            values.DayNight = command.DayNight;
            values.Price = command.Price;
            //values.Country = command.Country;
            values.CityId = command.CityId;
            _context.SaveChanges();
        }
    }
}
