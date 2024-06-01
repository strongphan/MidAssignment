using ManhPT_MidAssignment.Application.IRepository;
using ManhPT_MidAssignment.Domain.Entity;
using ManhPT_MidAssignment.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ManhPT_MidAssignment.Infrastructure.Repository
{


    public class UserRepo(LibraryContext context) : BaseRepo<User>(context), IUserRepo
    {
        public async Task<User> FindUserByEmailAsync(string email) => await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
}
