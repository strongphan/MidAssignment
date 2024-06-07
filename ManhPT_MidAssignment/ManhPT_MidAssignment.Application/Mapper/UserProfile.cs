using AutoMapper;
using ManhPT_MidAssignment.Application.DTOs.AuthDTOs;
using ManhPT_MidAssignment.Domain.Entity;

namespace ManhPT_MidAssignment.Application.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<User, UserLessDTO>();
        }
    }
}
