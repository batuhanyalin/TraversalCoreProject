using MediatR;
using TraversalCoreProject.CQRS.Results.ContactResults;

namespace TraversalCoreProject.CQRS.Queries.ContactQueries
{
    public class GetAllContactQuery:IRequest<List<GetAllContactQueryResult>>
    {
    }
}
