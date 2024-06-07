using ManhPT_MidAssignment.Application.Common.Paging;
using ManhPT_MidAssignment.Application.Services.BorrowRequestService;
using ManhPT_MidAssignment.Domain.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ManhPT_MidAssignment.API.Controllers
{
    [Route("api/borrowing_request")]
    [ApiController]
    public class BorrowRequestsController : ControllerBase
    {
        private readonly IBorrowRequestService _service;
        private Guid UserId => Guid.Parse(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
        private string UserName => Convert.ToString(User.Claims.First(c => c.Type == ClaimTypes.Name).Value);

        public BorrowRequestsController(IBorrowRequestService service)
        {
            _service = service;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var dto = await _service.GetByIdAsync(id);
            return Ok(dto);
        }
        [HttpPost("filter")]
        public async Task<IActionResult> GetRequestAsync(FilterRequest request)
        {
            var res = await _service.GetRequestAsync(request);
            return Ok(res);
        }
        [Authorize(Roles = nameof(Role.Admin))]
        [HttpPost("filter/not_returned")]
        public async Task<IActionResult> GetRequestNotReturnedAsync(FilterRequest request)
        {
            var res = await _service.GetRequestNotReturnedAsync(request);
            return Ok(res);
        }
        [HttpPost("user/{requestId}")]
        public async Task<IActionResult> GetRequestNotReturnedAsync(FilterRequest request, Guid requestId)
        {
            var res = await _service.GetRequestByRequestorIdAsync(request, requestId);
            return Ok(res);
        }
        [HttpPost]
        [Authorize(Roles = nameof(Role.User))]
        public async Task<IActionResult> BorrowBooksAsync(List<Guid> bookIds)
        {
            var res = await _service.BorrowBooksAsync(UserId, UserName, bookIds);
            return Ok(res);
        }
        [HttpPut("status/{requestId}")]
        [Authorize(Roles = nameof(Role.Admin))]
        public async Task<IActionResult> UpdateRequestStatusAsync(Guid requestId, Status status)
        {
            var res = await _service.UpdateRequestStatusAsync(UserId, UserName, requestId, status);
            return Ok(res);
        }
        [HttpPut("return/{requestId}")]
        [Authorize(Roles = nameof(Role.Admin))]
        public async Task<IActionResult> ConfirmReturnedAsync(Guid requestId)
        {
            var res = await _service.ConfirmReturnedAsync(UserId, UserName, requestId);
            return Ok(res);
        }
    }
}
