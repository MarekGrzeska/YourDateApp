using AutoMapper;
using YourDateApp.Application.Commands.UpdateUserProfile;
using YourDateApp.Application.Dtos;
using YourDateApp.Domain.Entities;

namespace YourDateApp.Application.Mappings
{
    public class YourDateAppMappingProfile : Profile
    {
        public YourDateAppMappingProfile() 
        {
            CreateMap<User, UserProfileDto>()
                .ForMember(dto => dto.FirstName, opt => opt.MapFrom(src => src.Profile != null ? src.Profile.FirstName : null))
                .ForMember(dto => dto.LastName, opt => opt.MapFrom(src => src.Profile != null ? src.Profile.LastName : null))
                .ForMember(dto => dto.PhotoSrc, opt => opt.MapFrom(src => src.Profile != null ? src.Profile.PhotoSrc : null))
                .ForMember(dto => dto.Country, opt => opt.MapFrom(src => src.Profile != null ? src.Profile.Country : null))
                .ForMember(dto => dto.City, opt => opt.MapFrom(src => src.Profile != null ? src.Profile.City : null))
                .ForMember(dto => dto.Age, opt => opt.MapFrom(src => src.Profile != null ? src.Profile.Age : null));

            CreateMap<UserProfileDto, User>()
                .ForMember(u => u.Profile, opt => opt.MapFrom(src => new ProfileInfo()
                {
                    FirstName = src.FirstName,
                    LastName = src.LastName,
                    PhotoSrc = src.PhotoSrc,
                    Country = src.Country,
                    City = src.City,
                    Age = src.Age,
                }));

            CreateMap<UserProfileDto, UpdateUserProfileCommand>();
            CreateMap<UpdateUserProfileCommand, UserProfileDto>();
            CreateMap<LikeDto, Like>();
            CreateMap<Like, LikeDto>();
            CreateMap<MessageDto, Message>();
            CreateMap<Message, MessageDto>();
        }
    }
}