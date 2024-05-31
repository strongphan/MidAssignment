using ManhPT_MidAssignment.Application.DTOs.AuthDTOs;
using ManhPT_MidAssignment.Core.Entity;
using ManhPT_MidAssignment.Core.Enum;

namespace ManhPT_MidAssignment.Application.Services.UserService
{
    public interface IUserService
    {
        Task<User> FindUserByEmailAsync(string email);
        Task<LoginResponse> LoginAsync(LoginDTO dto);
        Task<RegistrationResponse> RegisterAsync(RegisterUserDto dto);
        Task<string> BorrowBooksAsync(Guid userId, string userName, List<Guid> bookIds);
        Task<bool> UpdateRequestStatus(Guid userId, string userName, Guid requestId, Status status);

    }
}