namespace TraversalCoreProject.CQRS.Results.DestinationResults
{
    public class GetAllDestinationQueryResult
    {
        public int Id { get; set; }
        public int City { get; set; }
        public int CityId { get; set; }
        public int Capacity { get; set; }
        public string DayNight { get; set; }
        public double Price { get; set; }
    }
}
