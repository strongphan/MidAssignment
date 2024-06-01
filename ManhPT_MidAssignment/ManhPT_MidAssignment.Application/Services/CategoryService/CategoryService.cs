using AutoMapper;
using ManhPT_MidAssignment.Application.DTOs.CategoryDTOs;
using ManhPT_MidAssignment.Application.IRepository;
using ManhPT_MidAssignment.Application.Service;
using ManhPT_MidAssignment.Domain.Entity;

namespace ManhPT_MidAssignment.Application.Services.CategoryService
{
    public class CategoryService : BaseService<Category, CategoryDTO, CategoryCreateDTO>, ICategoryService
    {
        public CategoryService(ICategoryRepo repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public override void ValidateDTO(CategoryCreateDTO dto)
        {
            var a = 1;
        }
    }
}
