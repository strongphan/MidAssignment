using ManhPT_MidAssignment.Application.Constacts;
using ManhPT_MidAssignment.Application.DTOs.AuthDTOs;
using ManhPT_MidAssignment.Application.Services.TokenService;
using ManhPT_MidAssignment.Core.Entity;
using ManhPT_MidAssignment.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ManhPT_MidAssignment.Infrastructure.Repository
{


    public class UserRepo : IUserRepo
    {
        private readonly LibraryContext _context;
        private readonly ITokenService _tokenService;

        public UserRepo(LibraryContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        public async Task<User> FindUserByEmailAsync(string email) => await _context.Users.FirstOrDefaultAsync(u => u.Email == email);


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

            _context.Users.Add(new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = Core.Enum.Role.User,
                CreatedOn = DateTime.UtcNow,
                ModifiedOn = DateTime.UtcNow,
                CreatedBy = "ManhPhan",
                ModifiedBy = "ManhPhan",
            });
            await _context.SaveChangesAsync();
            return new RegistrationResponse(true, "Register success");

        }
    }
}
