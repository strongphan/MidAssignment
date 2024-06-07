using ManhPT_MidAssignment.Application.DTOs.AuthDTOs;
using ManhPT_MidAssignment.Domain.Entity;

namespace ManhPT_MidAssignment.Application.Services.UserService
{
    public interface IUserService
    {
        Task<User> FindUserByEmailAsync(string email);
        Task<LoginResponse> LoginAsync(LoginDTO dto);
        Task<RegistrationResponse> RegisterAsync(RegisterUserDto dto);
        Task<UserDTO> GetByIdAsync(Guid id);

    }
}