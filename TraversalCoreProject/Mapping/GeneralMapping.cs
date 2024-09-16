using AutoMapper;
using TraversalCoreProject.DtoLayer.DefaultDtos.DestinationDtos;
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
            CreateMap<AppUser,RegisterDto>().ReverseMap();
            CreateMap<AppUser,LoginDto>().ReverseMap();
        }
    }
}
