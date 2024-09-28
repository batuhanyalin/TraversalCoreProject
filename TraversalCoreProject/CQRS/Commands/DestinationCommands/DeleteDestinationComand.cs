namespace TraversalCoreProject.CQRS.Commands.DestinationCommands
{
    public class DeleteDestinationComand
    {
        public DeleteDestinationComand(int destinationId)
        {
            DestinationId = destinationId;
        }

        public int DestinationId { get; set; }
    }
}
