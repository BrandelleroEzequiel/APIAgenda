using AutoMapper;
using BEAgenda.Entities;
using BEAgenda.Models;

namespace BEAgenda.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
        }
    }
}
