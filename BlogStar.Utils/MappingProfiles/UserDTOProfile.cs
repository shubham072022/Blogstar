using AutoMapper;
using BlogStar.Shared.Dtos;
using BlogStar.Shared.Models;

namespace BlogStar.Utils.MappingProfiles
{
    public class UserDTOProfile : Profile
    {
        public UserDTOProfile() 
        {
            CreateMap<ApplicationUser, UserDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.ProfileImage, opt => opt.MapFrom(src => src.ProfileImage));
        }
    }
}
