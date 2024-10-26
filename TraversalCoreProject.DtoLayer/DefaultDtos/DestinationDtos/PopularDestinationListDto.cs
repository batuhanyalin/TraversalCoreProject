using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.DtoLayer.DefaultDtos.DestinationDtos
{
	public class PopularDestinationListDto
	{
		public int DestinationId { get; set; }
		public string Country { get; set; }
		public string CityId { get; set; }
		public City City { get; set; }
		public string DayNight { get; set; }
		public double Price { get; set; }
		public string ImageUrl { get; set; }
		public string Description { get; set; }
		public string Detail { get; set; }
	}
}
