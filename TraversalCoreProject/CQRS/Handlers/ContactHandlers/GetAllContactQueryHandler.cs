using DocumentFormat.OpenXml.Drawing.Charts;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TraversalCoreProject.CQRS.Queries.ContactQueries;
using TraversalCoreProject.CQRS.Results.ContactResults;
using TraversalCoreProject.DataAccessLayer.Context;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.CQRS.Handlers.ContactHandlers
{
    public class GetAllContactQueryHandler : IRequestHandler<GetAllContactQuery, List<GetAllContactQueryResult>> //Bir istek bir yanıt veriyoruz ve implement ediyoruz.
    {
        private readonly TraversalContext _context;

        public GetAllContactQueryHandler(TraversalContext context)
        {
            _context = context;
        }

        public async Task<List<GetAllContactQueryResult>> Handle(GetAllContactQuery request, CancellationToken cancellationToken)
        {

            return await _context.Contacts.Select(x => new GetAllContactQueryResult
            {
                ContactId = x.ContactId,
                Name = x.Name,
                Email = x.Email,
                IsApproved = x.IsApproved,
                Phone = x.Phone,
                SendingDate = x.SendingDate,
                Subject = x.Subject,
                Surname = x.Surname,
                Text = x.Text
            }).AsNoTracking().ToListAsync(); //Listeleme metodu olduğu için AsNoTracking kullanıyorum.

        }
    }
}
