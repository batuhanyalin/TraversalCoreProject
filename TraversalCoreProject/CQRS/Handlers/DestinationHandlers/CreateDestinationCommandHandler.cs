using TraversalCoreProject.CQRS.Commands.DestinationCommands;
using TraversalCoreProject.DataAccessLayer.Context;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.CQRS.Handlers.DestinationHandlers
{
    public class CreateDestinationCommandHandler
    {
        private readonly TraversalContext _context;

        public CreateDestinationCommandHandler(TraversalContext context)
        {
            _context = context;
        }
        public void Handle(CreateDestinationCommand createDestinationCommand)
        {
            _context.Destinations.Add(new Destination
            {
                Capacity = createDestinationCommand.Capacity,
                City = createDestinationCommand.City,
                Country = createDestinationCommand.Country,
                DayNight = createDestinationCommand.DayNight,
                Price = createDestinationCommand.Price,
                Status = true,
                Description = "",
                ImageUrl="",
                CoverImage="",
                StartDate = DateTime.Now,
                Detail="",
                Text1="",
                IsFeaturePost=false,              
            });
            _context.SaveChanges();
        }
    }
}
