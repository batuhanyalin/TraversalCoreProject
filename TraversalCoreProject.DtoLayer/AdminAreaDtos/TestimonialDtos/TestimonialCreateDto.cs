using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversalCoreProject.DtoLayer.AdminAreaDtos.TestimonialDtos
{
    public class TestimonialCreateDto
    {
        public string ClientName { get; set; }
        public string ClientSurname { get; set; }
        public string Text { get; set; }
        public DateTime CommentDate { get; set; }
        public string ClientImageUrl { get; set; }
        public bool IsApproved { get; set; }
        public IFormFile Image {  get; set; }
    }
}
