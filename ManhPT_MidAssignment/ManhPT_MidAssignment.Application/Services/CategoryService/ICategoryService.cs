using ManhPT_MidAssignment.Application.DTOs.CategoryDTOs;
using ManhPT_MidAssignment.Application.Service;

namespace ManhPT_MidAssignment.Application.Services.CategoryService
{
    public interface ICategoryService : IBaseService<CategoryDTO, CategoryCreateDTO>
    {
    }
}
