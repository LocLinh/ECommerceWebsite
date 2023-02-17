using AutoMapper;
using Solution.Data.Entities;
using Solution.Data.Models.UserModels;

namespace ECommerceAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterUserDto, LiteUserDto>();
            CreateMap<User, LiteUserDto>();
        }
    }
}
