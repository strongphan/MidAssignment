using ManhPT_MidAssignment.Application.DTOs.AuthDTOs;
using ManhPT_MidAssignment.Core.Entity;

namespace ManhPT_MidAssignment.Application.IRepository
{
    public interface IUserRepo
    {
        Task<RegistrationResponse> RegisterAsync(RegisterUserDto dto);
        Task<LoginResponse> LoginAsync(LoginDTO dto);
        Task<User> FindUserByEmailAsync(string email);
    }
}
