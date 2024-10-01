using MediatR;
using TraversalCoreProject.CQRS.Results.ContactResults;

namespace TraversalCoreProject.CQRS.Queries.ContactQueries
{
    public class GetContactByIdQuery : IRequest<GetContactByIdQueryResult>
    {
        public int Id { get; set; }

        public GetContactByIdQuery(int ıd)
        {
            Id = ıd;
        }
    }
}
