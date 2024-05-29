using ManhPT_MidAssignment.Application.Constacts;
using ManhPT_MidAssignment.Core.Entity;
using ManhPT_MidAssignment.Infrastructure.Data;

namespace ManhPT_MidAssignment.Infrastructure.Repository
{
    public class BookRepo : BaseRepo<Book>, IBookRepo
    {
        public BookRepo(LibraryContext dbContext) : base(dbContext)
        {

        }
    }
}
