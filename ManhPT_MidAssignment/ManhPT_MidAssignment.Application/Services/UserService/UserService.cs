using ManhPT_MidAssignment.Application.DTOs.AuthDTOs;
using ManhPT_MidAssignment.Application.IRepository;
using ManhPT_MidAssignment.Application.Services.TokenService;
using ManhPT_MidAssignment.Domain.Entity;

namespace ManhPT_MidAssignment.Application.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly ITokenService _tokenService;

        public UserService(IUserRepo userRepo, ITokenService tokenService)
        {
            _userRepo = userRepo;
            _tokenService = tokenService;
        }
        public async Task<User> FindUserByEmailAsync(string email) => await _userRepo.FindUserByEmailAsync(email);

        public async Task<LoginResponse> LoginAsync(LoginDTO dto)
        {
            var getUser = await FindUserByEmailAsync(dto.Email!);
            if (getUser == null)
                return new LoginResponse(false, "User not found");

            bool checkPassword = BCrypt.Net.BCrypt.Verify(dto.Password, getUser.Password);
            if (checkPassword)
            {
                return new LoginResponse(true, "Login success", _tokenService.GenerateJWT(getUser));

            }
            else
            {
                return new LoginResponse(false, "Invalid credentials");
            }
        }

        public async Task<RegistrationResponse> RegisterAsync(RegisterUserDto dto)
        {
            var getUser = await FindUserByEmailAsync(dto.Email!);
            if (getUser != null)
                return new RegistrationResponse(false, "User alredy exist");

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = Domain.Enum.Role.User,
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow,
                CreatedBy = "ManhPhan",
                ModifiedBy = "ManhPhan",
            };
            _userRepo.InsertAsync(user);
            return new RegistrationResponse(true, "Register success");

        }

    }
}
