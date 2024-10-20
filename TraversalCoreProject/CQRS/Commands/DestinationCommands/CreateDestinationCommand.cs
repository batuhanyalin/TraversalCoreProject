using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.CQRS.Commands.DestinationCommands
{
    public class CreateDestinationCommand
    {
        public int City { get; set; }
        public int CityId { get; set; }
        public string DayNight { get; set; }
        public double Price { get; set; }
        public int Capacity { get; set; }
    }
}
