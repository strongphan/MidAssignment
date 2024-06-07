using ManhPT_MidAssignment.Application.DTOs.CategoryDTOs;
using ManhPT_MidAssignment.Application.Services.CategoryService;
using Microsoft.AspNetCore.Mvc;

namespace ManhPT_MidAssignment.API.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController(ICategoryService service) : BaseController<CategoryDTO, CategoryCreateDTO>(service)
    {
    }
}
