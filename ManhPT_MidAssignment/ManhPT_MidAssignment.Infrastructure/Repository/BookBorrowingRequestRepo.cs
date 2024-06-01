using ManhPT_MidAssignment.Application.Common.Paging;
using ManhPT_MidAssignment.Application.IRpository;
using ManhPT_MidAssignment.Domain.Entity;
using ManhPT_MidAssignment.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ManhPT_MidAssignment.Infrastructure.Repository
{
    public class BookBorrowingRequestRepo(LibraryContext dbContext) : BaseRepo<BookBorrowingRequest>(dbContext), IBookBorrowingRequestRepo
    {
        public async Task<PaginationResponse<BookBorrowingRequest>> GetRequestAsync(FilterRequest request)
        {
            IQueryable<BookBorrowingRequest> query = dbContext.BookBorrowingRequests;

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                query = query.Where(p =>
                    p.Requestor.Name.Contains(request.SearchTerm));
            }
            var totalCount = await query.CountAsync();
            var items = await query.Skip((request.Page - 1) * request.PageSize).Take(request.PageSize).ToListAsync();
            return new(items, totalCount);
        }

        public async Task<PaginationResponse<BookBorrowingRequest>> GetRequestNotReturnedAsync(FilterRequest request)
        {
            IQueryable<BookBorrowingRequest> query = dbContext.BookBorrowingRequests.Where(r => r.IsReturn == false);

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                query = query.Where(p =>
                    p.Requestor.Name.Contains(request.SearchTerm));
            }
            var totalCount = await query.CountAsync();
            var items = await query.Skip((request.Page - 1) * request.PageSize).Take(request.PageSize).ToListAsync();
            return new(items, totalCount);
        }

        public async Task<List<BookBorrowingRequest>> GetRequestsByUserAndMonthAsync(Guid userId, int month)
        {
            return await dbContext.BookBorrowingRequests
                .Where(r => r.RequestorId == userId && r.DateRequested.Month == month)
                .ToListAsync();
        }

    }
}