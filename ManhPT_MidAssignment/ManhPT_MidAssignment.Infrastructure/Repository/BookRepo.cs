using ManhPT_MidAssignment.Application.Common.Paging;
using ManhPT_MidAssignment.Application.IRepository;
using ManhPT_MidAssignment.Domain.Entity;
using ManhPT_MidAssignment.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ManhPT_MidAssignment.Infrastructure.Repository
{
    public class BookRepo(LibraryContext dbContext) : BaseRepo<Book>(dbContext), IBookRepo
    {
        public async Task<PaginationResponse<Book>> GetFilterAsync(FilterRequest request)
        {
            IQueryable<Book> query = _context.Books;

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                query = query.Where(p =>
                    p.Title.Contains(request.SearchTerm) ||
                    p.Author.Contains(request.SearchTerm));
            }

            if (request.SortOrder?.ToLower() == "desc")
            {
                query = query.OrderByDescending(GetSortProperty(request));
            }
            else
            {
                query = query.OrderBy(GetSortProperty(request));
            }
            var totalCount = await query.CountAsync();
            var items = await query.Skip((request.Page - 1) * request.PageSize).Take(request.PageSize).ToListAsync();
            return new(items, totalCount);
        }
        private static Expression<Func<Book, object>> GetSortProperty(FilterRequest request) =>
        request.SortColumn?.ToLower() switch
        {
            "title" => product => product.Title,
            "author" => product => product.Author,
            _ => product => product.ModifiedAt
        };
    }
}
