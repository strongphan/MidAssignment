using AutoMapper;
using ManhPT_MidAssignment.Application.DTOs.CategoryDTOs;
using ManhPT_MidAssignment.Core.Entity;

namespace ManhPT_MidAssignment.Application.Mapper
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryCreateDTO, Category>();
        }
    }
}
