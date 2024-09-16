using AutoMapper;
using TraversalCoreProject.DtoLayer.DefaultDtos.ApplicationDtos;
using TraversalCoreProject.DtoLayer.DefaultDtos.CommentDtos;
using TraversalCoreProject.DtoLayer.DefaultDtos.ContactDtos;
using TraversalCoreProject.DtoLayer.DefaultDtos.DestinationDtos;
using TraversalCoreProject.DtoLayer.DefaultDtos.FooterDtos;
using TraversalCoreProject.DtoLayer.DefaultDtos.IndexBannerDtos;
using TraversalCoreProject.DtoLayer.DefaultDtos.TestimonialDtos;
using TraversalCoreProject.DtoLayer.LoginDtos;
using TraversalCoreProject.DtoLayer.RegisterDtos;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<Destination,DestinationListDto>().ReverseMap();
            CreateMap<Destination,PopularDestinationListDto>().ReverseMap();
            CreateMap<Destination,FeaturePostListDto>().ReverseMap();

            CreateMap<Comment,CommentCreateDto>().ReverseMap();
            CreateMap<Comment,CommentListDto>().ReverseMap();

            CreateMap<IndexBanner,IndexBannerShowDto>().ReverseMap();

            CreateMap<AppUser,RegisterDto>().ReverseMap();
            CreateMap<AppUser,LoginDto>().ReverseMap();

            CreateMap<Newsletter,NewsletterSubscribeDto>().ReverseMap();
            CreateMap<SocialMedia,SocialMediaDtos>().ReverseMap();

            CreateMap<Testimonial,TestimonialListDto>().ReverseMap();

            CreateMap<Contact, ContactCreateDto>().ReverseMap();
            CreateMap<Application, ApplicationCreateDto>().ReverseMap();
        }
    }
}
