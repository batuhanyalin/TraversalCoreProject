﻿using AutoMapper;
using DocumentFormat.OpenXml.Presentation;
using TraversalCoreProject.DtoLayer.AdminAreaDtos.AboutDtos;
using TraversalCoreProject.DtoLayer.AdminAreaDtos.AnnouncementDtos;
using TraversalCoreProject.DtoLayer.AdminAreaDtos.ContactDtos;
using TraversalCoreProject.DtoLayer.AdminAreaDtos.DestinationDtos;
using TraversalCoreProject.DtoLayer.AdminAreaDtos.IndexBannerDtos;
using TraversalCoreProject.DtoLayer.AdminAreaDtos.MemberDtos;
using TraversalCoreProject.DtoLayer.AdminAreaDtos.NewsletterDtos;
using TraversalCoreProject.DtoLayer.AdminAreaDtos.ProfileDtos;
using TraversalCoreProject.DtoLayer.AdminAreaDtos.ReservationDtos;
using TraversalCoreProject.DtoLayer.AdminAreaDtos.RoleDtos;
using TraversalCoreProject.DtoLayer.AdminAreaDtos.SocialMediaDtos;
using TraversalCoreProject.DtoLayer.AdminAreaDtos.TagDtos;
using TraversalCoreProject.DtoLayer.AdminAreaDtos.TestimonialDtos;
using TraversalCoreProject.DtoLayer.DefaultDtos.AboutDtos;
using TraversalCoreProject.DtoLayer.DefaultDtos.CommentDtos;
using TraversalCoreProject.DtoLayer.DefaultDtos.ContactDtos;
using TraversalCoreProject.DtoLayer.DefaultDtos.DestinationDtos;
using TraversalCoreProject.DtoLayer.DefaultDtos.FooterDtos;
using TraversalCoreProject.DtoLayer.DefaultDtos.GuideDtos;
using TraversalCoreProject.DtoLayer.DefaultDtos.IndexBannerDtos;
using TraversalCoreProject.DtoLayer.DefaultDtos.TestimonialDtos;
using TraversalCoreProject.DtoLayer.LoginDtos;
using TraversalCoreProject.DtoLayer.MemberAreaDtos.AnnouncementDtos;
using TraversalCoreProject.DtoLayer.MemberAreaDtos.ProfileDtos;
using TraversalCoreProject.DtoLayer.MemberAreaDtos.ReservationDtos;
using TraversalCoreProject.DtoLayer.RegisterDtos;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Destination, DestinationListDto>().ReverseMap();
            CreateMap<Destination, PopularDestinationListDto>().ReverseMap();
            CreateMap<Destination, FeaturePostListDto>().ReverseMap();
            CreateMap<Destination, DestinationCreateDto>().ReverseMap();

            CreateMap<Destination, DestinationUpdateDto>().ForMember(dest => dest.TagMatchList, opt => opt.MapFrom(src => src.DestinationTags.FirstOrDefault())).ReverseMap();

            CreateMap<TraversalCoreProject.EntityLayer.Concrete.Tag, DestinationUpdateDto.DestinationTag>().ReverseMap();

            CreateMap<Destination, DestinationUpdateDto>().ForMember(dest => dest.GuideMatchList, opt => opt.MapFrom(src => src.DestinationMatchGuides.FirstOrDefault())).ReverseMap();

            CreateMap<AppUser, DestinationUpdateDto.DestinationGuide>().ReverseMap();

            CreateMap<TraversalCoreProject.EntityLayer.Concrete.Comment, CommentCreateDto>().ReverseMap();
            CreateMap<TraversalCoreProject.EntityLayer.Concrete.Comment, CommentListDto>().ReverseMap();

            CreateMap<IndexBanner, IndexBannerShowDto>().ReverseMap();

            CreateMap<AppUser, RegisterDto>().ReverseMap();
            CreateMap<AppUser, ApplicationDto>().ReverseMap();
            CreateMap<AppUser, LoginDto>().ReverseMap();
            CreateMap<AppUser, GuideListDto>().ReverseMap();
            CreateMap<AppUser, GuideDetailDto>().ReverseMap();
            CreateMap<AppUser, MyProfileUpdateDto>().ReverseMap();
            CreateMap<AppUser, AdminMyProfileUpdateDto>().ReverseMap();
            CreateMap<AppUser, MemberUpdateDto>().ReverseMap();
            CreateMap<AppUser, MemberListDto>().ReverseMap();
            CreateMap<AppUser, MemberCreateDto>().ReverseMap();

            CreateMap<Newsletter, NewsletterSubscribeDto>().ReverseMap();
            CreateMap<Newsletter, NewsletterListDto>().ReverseMap();
            CreateMap<SocialMedia, SocialMediaDtos>().ReverseMap();

            CreateMap<Testimonial, TestimonialCreateDto>().ReverseMap();
            CreateMap<Testimonial, TestimonialUpdateDto>().ReverseMap();
            CreateMap<Testimonial, TestimonialListDtoAdmin>().ReverseMap();

            CreateMap<Testimonial, TestimonialListDto>().ReverseMap();

            CreateMap<Contact, ContactCreateDto>().ReverseMap();
            CreateMap<Contact, ContactListDto>().ReverseMap();

            CreateMap<Reservation, AdminNewReservationDto>().ReverseMap();
            CreateMap<Reservation, AdminListReservationDto>().ReverseMap();
            CreateMap<Reservation, MemberListMyReservationDto>().ReverseMap();
            CreateMap<Reservation, AdminReservationUpdateDto>().ReverseMap();

            CreateMap<Announcement, AnnouncementCreateDto>().ReverseMap();
            CreateMap<Announcement, AnnouncementListDto>().ReverseMap();
            CreateMap<Announcement, MemberAnnouncementListDto>().ReverseMap();

            CreateMap<AppRole, RoleListDto>().ReverseMap();
            CreateMap<AppRole, RoleCreateDto>().ReverseMap();
            CreateMap<AppRole, RoleUpdateDto>().ReverseMap();

            CreateMap<IndexBanner, IndexBannerListDto>().ReverseMap();
            CreateMap<IndexBanner, IndexBannerCreateDto>().ReverseMap();
            CreateMap<IndexBanner, IndexBannerUpdateDto>().ReverseMap();

            CreateMap<About, AboutUpdateDto>().ReverseMap();
            CreateMap<About, AboutShowDto>().ReverseMap();

            CreateMap<SocialMedia, SocialMediaListDto>().ReverseMap();

            CreateMap<Destination, DestinationUpdateDto>()
           .ForMember(dest => dest.GuideMatchList, opt => opt.Ignore())
           .ForMember(dest => dest.TagMatchList, opt => opt.Ignore())
           .ForMember(dest => dest.DestinationTags, opt => opt.MapFrom(src => src.DestinationTags));

            CreateMap<DestinationTag, DestinationUpdateDto.DestinationTag>().ReverseMap();

            CreateMap<TraversalCoreProject.EntityLayer.Concrete.Tag, TagListDto>().ReverseMap();
            CreateMap<TraversalCoreProject.EntityLayer.Concrete.Tag, TagCreateDto>().ReverseMap();
            CreateMap<TraversalCoreProject.EntityLayer.Concrete.Tag, TagUpdateDto>().ReverseMap();

        }
    }
}
