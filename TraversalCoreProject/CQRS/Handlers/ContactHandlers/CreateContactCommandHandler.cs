using MediatR;
using TraversalCoreProject.CQRS.Commands.ContactCommands;
using TraversalCoreProject.DataAccessLayer.Context;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.CQRS.Handlers.ContactHandlers
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand>
    {
        private readonly TraversalContext _context;

        public CreateContactCommandHandler(TraversalContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateContactCommand request, CancellationToken cancellationToken) //Geriye bir sonuç dönmeyecekse MediatR da Unit ifadesi yazılır, bu void gibi davranır.
        {
            _context.Contacts.Add(new Contact
            {
               Email = request.Email,
               Name = request.Name,
               Phone = request.Phone,
               SendingDate=DateTime.Now,
               IsApproved=false,
               Surname=request.Surname,
               Subject=request.Subject,
               Text=request.Text,
            });
            await _context.SaveChangesAsync();
            //Unit.value 
            return Unit.Value;
        }
    }
}
