using ManhPT_MidAssignment.Application.Service;
using ManhPT_MidAssignment.Core.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ManhPT_MidAssignment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TEntityDto, TEntityCreateDto> : ControllerBase
    {
        private readonly IBaseService<TEntityDto, TEntityCreateDto> _service;
        private Guid UserId => Guid.Parse(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
        private string UserName => Convert.ToString(User.Claims.First(c => c.Type == ClaimTypes.Name).Value);
        public BaseController(IBaseService<TEntityDto, TEntityCreateDto> service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var dtos = await _service.GetAllAsync();
            return Ok(dtos);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var dto = await _service.GetByIdAsync(id);
            return Ok(dto);
        }

        [HttpPost]
        [Authorize(Roles = nameof(Role.Admin))]
        public async Task<IActionResult> Insert(TEntityCreateDto dto)
        {
            _service.InsertAsync(dto, UserName);
            return Ok("");
        }

        [HttpPut("{id}")]
        [Authorize(Roles = nameof(Role.Admin))]
        public async Task<IActionResult> Update(Guid id, TEntityCreateDto dto)
        {
            _service.UpdateAsync(id, dto, UserName);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = nameof(Role.Admin))]
        public async Task<IActionResult> Delete(Guid id)
        {
            _service.DeleteAsync(id);
            return Ok();
        }
    }
}
