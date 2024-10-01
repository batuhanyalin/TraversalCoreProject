namespace TraversalCoreProject.CQRS.Results.ContactResults
{
    public class GetAllContactQueryResult
    {
        public int ContactId { get; set; }
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
