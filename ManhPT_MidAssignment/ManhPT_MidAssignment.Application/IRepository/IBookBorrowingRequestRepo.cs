using ManhPT_MidAssignment.Application.Common.Paging;
using ManhPT_MidAssignment.Application.IRepository;
using ManhPT_MidAssignment.Domain.Entity;

namespace ManhPT_MidAssignment.Application.IRpository
{
    public interface IBookBorrowingRequestRepo : IBaseRepo<BookBorrowingRequest>
    {
        Task<List<BookBorrowingRequest>> GetRequestsByUserAndMonthAsync(Guid userId, int month);
        Task<PaginationResponse<BookBorrowingRequest>> GetRequestAsync(FilterRequest filterRequest);
        Task<PaginationResponse<BookBorrowingRequest>> GetRequestNotReturnedAsync(FilterRequest filterRequest);
    }
}
