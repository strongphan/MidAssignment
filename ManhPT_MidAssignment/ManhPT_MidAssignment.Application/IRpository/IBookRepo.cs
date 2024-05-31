using ManhPT_MidAssignment.Application.DTOs.Paging;
using ManhPT_MidAssignment.Core.Entity;

namespace ManhPT_MidAssignment.Application.IRepository
{
    public interface IBookRepo : IBaseRepo<Book>
    {
        Task<PaginationResponse<Book>> GetFilterAsync(FilterRequest request);
    }
}
