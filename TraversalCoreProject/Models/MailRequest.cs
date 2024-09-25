namespace TraversalCoreProject.Models
{
    public class MailRequest
    {
        public string SenderName { get; set; }
        public string SenderMail { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverMail { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public DateTime SendingTime { get; set; }
    }
}
