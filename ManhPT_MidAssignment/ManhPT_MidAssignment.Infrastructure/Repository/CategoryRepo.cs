using ManhPT_MidAssignment.Application.IRepository;
using ManhPT_MidAssignment.Domain.Entity;
using ManhPT_MidAssignment.Infrastructure.Data;

namespace ManhPT_MidAssignment.Infrastructure.Repository
{
    public class CategoryRepo(LibraryContext dbContext) : BaseRepo<Category>(dbContext), ICategoryRepo
    {
    }
}
