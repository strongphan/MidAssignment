using ManhPT_MidAssignment.Application.DTOs.AuthDTOs;
using ManhPT_MidAssignment.Application.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace ManhPT_MidAssignment.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var dto = await _userService.GetByIdAsync(id);
            return Ok(dto);
        }
        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> LoginAsync(LoginDTO dto)
        {
            var result = await _userService.LoginAsync(dto);
            return Ok(result);
        }
        [HttpPost("register")]
        public async Task<ActionResult<LoginResponse>> RegisterAsync(RegisterUserDto dto)
        {
            var result = await _userService.RegisterAsync(dto);
            return Ok(result);
        }
    }

}
