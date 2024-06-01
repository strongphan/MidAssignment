using ManhPT_MidAssignment.Application.Common.Paging;
using ManhPT_MidAssignment.Application.DTOs.BorrowingRequest;
using ManhPT_MidAssignment.Domain.Enum;

namespace ManhPT_MidAssignment.Application.Services.BorrowRequestService
{
    public interface IBorrowRequestService
    {
        Task<string> BorrowBooksAsync(Guid userId, string userName, List<Guid> bookIds);
        Task<bool> UpdateRequestStatus(Guid userId, string userName, Guid requestId, Status status);
        Task<bool> ConfirmReturned(Guid userId, string userName, Guid requestId);
        Task<PaginationResponse<BorrowingRequestDTO>> GetRequestAsync(FilterRequest request);
        Task<PaginationResponse<BorrowingRequestDTO>> GetRequestNotReturnedAsync(FilterRequest request);
    }
}
