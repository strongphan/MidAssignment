using ManhPT_MidAssignment.Application.DTOs.CategoryDTOs;
using ManhPT_MidAssignment.Application.Services.CategoryService;
using Microsoft.AspNetCore.Mvc;

namespace ManhPT_MidAssignment.API.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoriesController : BaseController<CategoryDTO, CategoryCreateDTO>
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service) : base(service)
        {
            _service = service;
        }
    }
}
