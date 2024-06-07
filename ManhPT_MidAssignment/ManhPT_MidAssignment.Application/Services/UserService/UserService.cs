using AutoMapper;
using ManhPT_MidAssignment.Application.DTOs.AuthDTOs;
using ManhPT_MidAssignment.Application.IRepository;
using ManhPT_MidAssignment.Application.Services.TokenService;
using ManhPT_MidAssignment.Domain.Entity;
using ManhPT_MidAssignment.Domain.Exceptions;

namespace ManhPT_MidAssignment.Application.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public UserService(IUserRepo userRepo, ITokenService tokenService, IMapper mapper)
        {
            _userRepo = userRepo;
            _tokenService = tokenService;
            _mapper = mapper;
        }
        public async Task<UserDTO> GetByIdAsync(Guid id)
        {
            var entity = await _userRepo.GetByIdAsync(id);
            if (entity == null)
            {
                throw new NotFoundException();
            }
            var dto = _mapper.Map<UserDTO>(entity);
            return dto;

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
                return new RegistrationResponse(false, "User already exist");

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
            await _userRepo.InsertAsync(user);
            return new RegistrationResponse(true, "Register success");

        }

    }
}
