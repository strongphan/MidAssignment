using ManhPT_MidAssignment.Application.Common.Paging;
using ManhPT_MidAssignment.Domain.Entity;

namespace ManhPT_MidAssignment.Application.IRepository
{
    public interface IBookRepo : IBaseRepo<Book>
    {
        Task<PaginationResponse<Book>> GetFilterAsync(FilterRequest request);
    }
}
