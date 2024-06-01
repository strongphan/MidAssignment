using ManhPT_MidAssignment.Application.IRepository;
using ManhPT_MidAssignment.Domain.Entity;
using ManhPT_MidAssignment.Infrastructure.Data;

namespace ManhPT_MidAssignment.Infrastructure.Repository
{
    public class CategoryRepo : BaseRepo<Category>, ICategoryRepo
    {
        public CategoryRepo(LibraryContext dbContext) : base(dbContext)
        {
        }
    }
}
