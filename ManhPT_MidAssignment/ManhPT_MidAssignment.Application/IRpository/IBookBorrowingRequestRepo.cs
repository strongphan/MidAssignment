using ManhPT_MidAssignment.Application.IRepository;
using ManhPT_MidAssignment.Core.Entity;

namespace ManhPT_MidAssignment.Application.IRpository
{
    public interface IBookBorrowingRequestRepo : IBaseRepo<BookBorrowingRequest>
    {
        Task<List<BookBorrowingRequest>> GetRequestsByUserAndMonth(Guid userId, int month);
        Task AddAsync(BookBorrowingRequest borrowingRequest);
        Task SaveChangesAsync();
    }
}
