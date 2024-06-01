using ManhPT_MidAssignment.Application.Common.Paging;
using ManhPT_MidAssignment.Application.DTOs.BookDTOs;
using ManhPT_MidAssignment.Application.Services.BookService;
using Microsoft.AspNetCore.Mvc;

namespace ManhPT_MidAssignment.API.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BooksController : BaseController<BookDTO, BookCreateDTO>
    {
        private readonly IBookService _service;

        public BooksController(IBookService service) : base(service)
        {
            _service = service;
        }
        [HttpPost("filter")]
        public async Task<IActionResult> GetFilterAsync(FilterRequest request)
        {
            var res = await _service.GetFilterAsync(request);
            return Ok(res);
        }
    }
}
