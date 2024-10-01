using MediatR;

namespace TraversalCoreProject.CQRS.Commands.ContactCommands
{
    public class CreateContactCommand : IRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public DateTime SendingDate { get; set; }
        public bool IsApproved { get; set; }
    }
}
