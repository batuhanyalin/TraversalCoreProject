﻿using AutoMapper;
using TraversalCoreProject.DtoLayer.AdminAreaDtos.DestinationDtos;
using TraversalCoreProject.DtoLayer.AdminAreaDtos.MemberDtos;
using TraversalCoreProject.DtoLayer.AdminAreaDtos.ProfileDtos;
using TraversalCoreProject.DtoLayer.AdminAreaDtos.ReservationDtos;
using TraversalCoreProject.DtoLayer.DefaultDtos.CommentDtos;
using TraversalCoreProject.DtoLayer.DefaultDtos.ContactDtos;
using TraversalCoreProject.DtoLayer.DefaultDtos.DestinationDtos;
using TraversalCoreProject.DtoLayer.DefaultDtos.FooterDtos;
using TraversalCoreProject.DtoLayer.DefaultDtos.GuideDtos;
using TraversalCoreProject.DtoLayer.DefaultDtos.IndexBannerDtos;
using TraversalCoreProject.DtoLayer.DefaultDtos.TestimonialDtos;
using TraversalCoreProject.DtoLayer.LoginDtos;
using TraversalCoreProject.DtoLayer.MemberAreaDtos.ProfileDtos;
using TraversalCoreProject.DtoLayer.MemberAreaDtos.ReservationDtos;
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
            CreateMap<Destination,DestinationCreateDto>().ReverseMap();
            CreateMap<Destination,DestinationUpdateDto>().ReverseMap();

            CreateMap<Comment,CommentCreateDto>().ReverseMap();
            CreateMap<Comment,CommentListDto>().ReverseMap();

            CreateMap<IndexBanner,IndexBannerShowDto>().ReverseMap();

            CreateMap<AppUser,RegisterDto>().ReverseMap();
            CreateMap<AppUser,LoginDto>().ReverseMap();
            CreateMap<AppUser,GuideListDto>().ReverseMap();
            CreateMap<AppUser,GuideDetailDto>().ReverseMap();
            CreateMap<AppUser,MyProfileUpdateDto>().ReverseMap();
            CreateMap<AppUser,AdminMyProfileUpdateDto>().ReverseMap();
            CreateMap<AppUser, MemberUpdateDto>().ReverseMap();
            CreateMap<AppUser, MemberListDto>().ReverseMap();
            CreateMap<AppUser, MemberCreateDto>().ReverseMap();

            CreateMap<Newsletter,NewsletterSubscribeDto>().ReverseMap();
            CreateMap<SocialMedia,SocialMediaDtos>().ReverseMap();

            CreateMap<Testimonial,TestimonialListDto>().ReverseMap();

            CreateMap<Contact, ContactCreateDto>().ReverseMap();

            CreateMap<Reservation, AdminNewReservationDto>().ReverseMap();
            CreateMap<Reservation, AdminListReservationDto>().ReverseMap();
            CreateMap<Reservation, MemberListMyReservationDto>().ReverseMap();
            CreateMap<Reservation, AdminReservationUpdateDto>().ReverseMap();
        }
    }
}
