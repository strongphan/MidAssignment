using ManhPT_MidAssignment.Application.Common.Paging;
using ManhPT_MidAssignment.Application.IRpository;
using ManhPT_MidAssignment.Domain.Entity;
using ManhPT_MidAssignment.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ManhPT_MidAssignment.Infrastructure.Repository
{
    public class BookBorrowingRequestRepo(LibraryContext dbContext) : BaseRepo<BookBorrowingRequest>(dbContext), IBookBorrowingRequestRepo
    {
        public async override Task<BookBorrowingRequest?> GetByIdAsync(Guid id)
        {
            return await _table.AsNoTracking().Include(b => b.BookBorrowingRequestDetails).ThenInclude(d => d.Book)
                               .Include(b => b.Requestor)
                               .Include(b => b.Approver)
                               .FirstOrDefaultAsync(b => b.Id == id);
        }
        public async Task<PaginationResponse<BookBorrowingRequest>> GetRequestAsync(FilterRequest request)
        {
            IQueryable<BookBorrowingRequest> query = _table.AsNoTracking()
                                .Include(b => b.BookBorrowingRequestDetails).ThenInclude(d => d.Book)
                               .Include(b => b.Requestor)
                               .Include(b => b.Approver);

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                query = query.Where(p =>
                    p.Requestor.Name.Contains(request.SearchTerm));
            }
            if (request.SortOrder?.ToLower() == "descend")
            {
                query = query.OrderByDescending(GetSortProperty(request));
            }
            else
            {
                query = query.OrderBy(GetSortProperty(request));
            }
            var totalCount = await query.CountAsync();
            var items = await query.Skip((request.Page - 1) * request.PageSize).Take(request.PageSize).AsNoTracking().ToListAsync();
            return new(items, totalCount);
        }

        public async Task<PaginationResponse<BookBorrowingRequest>> GetRequestByRequestorIdAsync(FilterRequest request, Guid requestorId)
        {
            IQueryable<BookBorrowingRequest> query = _table.AsNoTracking().Include(b => b.BookBorrowingRequestDetails)
                                                         .ThenInclude(d => d.Book)
                                                        .Include(b => b.Requestor)
                                                        .Include(b => b.Approver)
                                                        .Where(r => r.RequestorId == requestorId);
            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                query = query.Where(p =>
                    p.Requestor.Name.Contains(request.SearchTerm));
            }
            if (request.SortOrder?.ToLower() == "descend")
            {
                query = query.OrderByDescending(GetSortProperty(request));
            }
            else
            {
                query = query.OrderBy(GetSortProperty(request));
            }
            var totalCount = await query.CountAsync();
            var items = await query.Skip((request.Page - 1) * request.PageSize).Take(request.PageSize).AsNoTracking().ToListAsync();
            return new(items, totalCount);
        }

        public async Task<PaginationResponse<BookBorrowingRequest>> GetRequestNotReturnedAsync(FilterRequest request)
        {
            IQueryable<BookBorrowingRequest> query = _table.AsNoTracking()
                .Include(b => b.BookBorrowingRequestDetails)
                                .ThenInclude(d => d.Book)
                                  .Include(b => b.Requestor)
                                  .Include(b => b.Approver)
                               .Where(r => r.IsReturn == false);

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                query = query.Where(p =>
                    p.Requestor.Name.Contains(request.SearchTerm));
            }
            if (request.SortOrder?.ToLower() == "descend")
            {
                query = query.OrderByDescending(GetSortProperty(request));
            }
            else
            {
                query = query.OrderBy(GetSortProperty(request));
            }
            var totalCount = await query.CountAsync();
            var items = await query.Skip((request.Page - 1) * request.PageSize).Take(request.PageSize).AsNoTracking().ToListAsync();
            return new(items, totalCount);
        }

        public async Task<List<BookBorrowingRequest>> GetRequestsByUserAndMonthAsync(Guid userId, int month, int year)
        {
            return await _table.Where(r => r.RequestorId == userId && r.DateRequested.Month == month && r.DateRequested.Year == year).AsNoTracking().ToListAsync();
        }
        private static Expression<Func<BookBorrowingRequest, object>> GetSortProperty(FilterRequest request) =>
        request.SortColumn?.ToLower() switch
        {
            "requestor" => book => book.Requestor.Name,
            "dateRequested" => book => book.DateRequested,
            "status" => book => book.Status,
            _ => book => book.DateRequested
        };
    }
}