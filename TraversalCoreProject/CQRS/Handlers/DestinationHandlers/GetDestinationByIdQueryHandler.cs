using TraversalCoreProject.CQRS.Queries.DestinationQueries;
using TraversalCoreProject.CQRS.Results.DestinationResults;
using TraversalCoreProject.DataAccessLayer.Context;

namespace TraversalCoreProject.CQRS.Handlers.DestinationHandlers
{
    public class GetDestinationByIdQueryHandler
    {
        private readonly TraversalContext _context;

        public GetDestinationByIdQueryHandler(TraversalContext context)
        {
            _context = context;
        }
        public GetDestinationByIdQueryResult Handle(GetDestinationByIdQuery query)
        {
            var values = _context.Destinations.Find(query.id);
            return new GetDestinationByIdQueryResult
            {
                CityId = values.CityId,
                DestinationId = values.DestinationId,
                DayNight = values.DayNight,
                Price = values.Price,
                //Country = values.Country,
            };
        }
    }
}
