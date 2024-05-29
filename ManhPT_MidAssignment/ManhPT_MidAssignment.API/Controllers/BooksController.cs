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
    }
}
