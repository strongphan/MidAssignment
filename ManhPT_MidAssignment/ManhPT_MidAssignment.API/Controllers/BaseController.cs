using ManhPT_MidAssignment.Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace ManhPT_MidAssignment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TEntityDto, TEntityCreateDto> : ControllerBase
    {
        private readonly IBaseService<TEntityDto, TEntityCreateDto> _service;

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
        public async Task<IActionResult> Insert(TEntityCreateDto dto)
        {
            _service.InsertAsync(dto);
            return Ok("");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, TEntityCreateDto dto)
        {
            _service.UpdateAsync(id, dto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            _service.DeleteAsync(id);
            return Ok();
        }
    }
}
