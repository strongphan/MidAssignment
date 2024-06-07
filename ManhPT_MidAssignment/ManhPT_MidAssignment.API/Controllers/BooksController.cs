using ManhPT_MidAssignment.Application.Common.Paging;
using ManhPT_MidAssignment.Application.DTOs.BookDTOs;
using ManhPT_MidAssignment.Application.Services.BookService;
using Microsoft.AspNetCore.Mvc;

namespace ManhPT_MidAssignment.API.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController(IBookService service) : BaseController<BookDTO, BookCreateDTO>(service)
    {
        private readonly IBookService _service = service;

        [HttpPost("filter")]
        public async Task<IActionResult> GetFilterAsync(FilterRequest request)
        {
            var res = await _service.GetFilterAsync(request);
            return Ok(res);
        }
        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetByCategoryAsync(Guid categoryId)
        {
            var res = await _service.GetByCategoryAsync(categoryId);
            return Ok(res);
        }
    }
}
