namespace TraversalCoreProject.CQRS.Results.ContactResults
{
    public class GetContactByIdQueryResult
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
    }
}
