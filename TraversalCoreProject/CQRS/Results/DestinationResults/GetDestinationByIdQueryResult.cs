namespace TraversalCoreProject.CQRS.Results.DestinationResults
{
    public class GetDestinationByIdQueryResult
    {
        public int DestinationId { get; set; }
        public int City { get; set; }
        public int CityId { get; set; }
        public string DayNight { get; set; }
        public string Country { get; set; }
        public double Price { get; set; }
    }
}
