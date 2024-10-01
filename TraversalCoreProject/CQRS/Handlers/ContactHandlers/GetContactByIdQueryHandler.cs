using MediatR;
using Microsoft.EntityFrameworkCore;
using TraversalCoreProject.CQRS.Queries.ContactQueries;
using TraversalCoreProject.CQRS.Results.ContactResults;
using TraversalCoreProject.DataAccessLayer.Context;

namespace TraversalCoreProject.CQRS.Handlers.ContactHandlers
{
    public class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQuery, GetContactByIdQueryResult>
    {
        private readonly TraversalContext _context;

        public GetContactByIdQueryHandler(TraversalContext context)
        {
            _context = context;
        }

        public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _context.Contacts.FindAsync(request.Id);
            return new GetContactByIdQueryResult
            {
                ContactId = value.ContactId,
                Email = value.Email,
                Name = value.Name,
                Phone = value.Phone,
                Subject = value.Subject,
                Surname = value.Surname,
                Text = value.Text,
            };
        }
    }
}
