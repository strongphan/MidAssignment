using ManhPT_MidAssignment.Application.IRpository;
using ManhPT_MidAssignment.Core.Entity;
using ManhPT_MidAssignment.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ManhPT_MidAssignment.Infrastructure.Repository
{
    public class BookBorrowingRequestRepo(LibraryContext dbContext) : BaseRepo<BookBorrowingRequest>(dbContext), IBookBorrowingRequestRepo
    {
        public async Task<List<BookBorrowingRequest>> GetRequestsByUserAndMonth(Guid userId, int month)
        {
            return await dbContext.BookBorrowingRequests
                .Where(r => r.RequestorId == userId && r.DateRequested.Month == month)
                .ToListAsync();
        }

        public async Task AddAsync(BookBorrowingRequest borrowingRequest)
        {
            await dbContext.BookBorrowingRequests.AddAsync(borrowingRequest);
        }

        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}