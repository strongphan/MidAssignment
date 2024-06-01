using ManhPT_MidAssignment.Domain.Entity;

namespace ManhPT_MidAssignment.Application.IRepository
{
    public interface IUserRepo : IBaseRepo<User>
    {
        Task<User> FindUserByEmailAsync(string email);
    }
}
