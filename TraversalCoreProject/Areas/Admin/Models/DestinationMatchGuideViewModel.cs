namespace TraversalCoreProject.Areas.Admin.Models
{
    public class DestinationMatchGuideViewModel
    {
        public int GuideId { get; set; }
        public int DestinationId { get; set; }
        public string GuideName { get; set; }
        public string GuideImageUrl { get; set; }

        public bool GuideExist { get; set; }
    }
}
