using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.DtoLayer.AdminAreaDtos.DestinationDtos
{
    public class DestinationCreateDto
    {
        public int CityId { get; set; }
        public City City { get; set; }
        public string DayNight { get; set; }
        public DateTime StartDate { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public string CoverImage { get; set; }
        public string Text1 { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }
        public int Capacity { get; set; }
        public bool Status { get; set; }
        public bool IsFeaturePost { get; set; }
        public List<DestinationTag> DestinationTags { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Reservation> Reservations { get; set; }
        public List<DestinationMatchGuide> DestinationMatchGuides { get; set; }
        public IFormFile ImageUpload { get; set; }
        public IFormFile CoverImageUpload { get; set; }
        public List<DestinationGuide> GuideMatchList { get; set; }
        public List<DestinationTag> TagMatchList { get; set; }
        public class DestinationGuide
        {
            public int GuideId { get; set; }
            public int DestinationId { get; set; }
            public string GuideName { get; set; }
            public string GuideImageUrl { get; set; }
            public bool GuideExist { get; set; }
        }
        public class DestinationTag
        {
            public int TagId { get; set; }
            public string TagName { get; set; }
            public int DestinationId { get; set; }
            public bool TagExist { get; set; }

        }
    }
}
