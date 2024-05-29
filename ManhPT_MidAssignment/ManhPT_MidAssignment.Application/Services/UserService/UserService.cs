using ManhPT_MidAssignment.Application.Constacts;
using ManhPT_MidAssignment.Application.DTOs.AuthDTOs;
using ManhPT_MidAssignment.Core.Entity;

namespace ManhPT_MidAssignment.Application.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;

        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }
        public async Task<User> FindUserByEmailAsync(string email) => await _userRepo.FindUserByEmailAsync(email);

        public async Task<LoginResponse> LoginAsync(LoginDTO dto) => await _userRepo.LoginAsync(dto);

        public async Task<RegistrationResponse> RegisterAsync(RegisterUserDto dto) => await _userRepo.RegisterAsync(dto);
    }
}
