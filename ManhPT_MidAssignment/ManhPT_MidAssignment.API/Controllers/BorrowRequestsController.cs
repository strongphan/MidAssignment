using ManhPT_MidAssignment.Application.Common.Paging;
using ManhPT_MidAssignment.Application.Services.BorrowRequestService;
using ManhPT_MidAssignment.Domain.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ManhPT_MidAssignment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BorrowRequestsController : ControllerBase
    {
        private readonly IBorrowRequestService _service;
        private Guid UserId => Guid.Parse(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
        private string UserName => Convert.ToString(User.Claims.First(c => c.Type == ClaimTypes.Name).Value);
        public BorrowRequestsController(IBorrowRequestService service)
        {
            _service = service;
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
        [HttpPost]
        [Authorize(Roles = nameof(Role.User))]
        public async Task<IActionResult> BorrowBooksAsync(List<Guid> bookIds)
        {
            var res = await _service.BorrowBooksAsync(UserId, UserName, bookIds);
            return Ok(res);
        }
        [HttpPut("status")]
        [Authorize(Roles = nameof(Role.Admin))]
        public async Task<IActionResult> UpdateRequestStatus(Guid requestId, Status status)
        {
            var res = await _service.UpdateRequestStatus(UserId, UserName, requestId, status);
            return Ok(res);
        }
        [HttpPut("return")]
        [Authorize(Roles = nameof(Role.Admin))]
        public async Task<IActionResult> ConfirmReturned(Guid requestId)
        {
            var res = await _service.ConfirmReturned(UserId, UserName, requestId);
            return Ok(res);
        }
    }
}
