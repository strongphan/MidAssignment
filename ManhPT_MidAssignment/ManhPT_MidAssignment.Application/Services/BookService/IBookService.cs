using ManhPT_MidAssignment.Application.Common.Paging;
using ManhPT_MidAssignment.Application.DTOs.BookDTOs;
using ManhPT_MidAssignment.Application.Service;

namespace ManhPT_MidAssignment.Application.Services.BookService
{
    public interface IBookService : IBaseService<BookDTO, BookCreateDTO>
    {
        Task<PaginationResponse<BookDTO>> GetFilterAsync(FilterRequest request);
    }


}