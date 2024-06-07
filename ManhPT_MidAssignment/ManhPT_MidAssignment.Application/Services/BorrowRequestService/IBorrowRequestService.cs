using ManhPT_MidAssignment.Application.Common.Paging;
using ManhPT_MidAssignment.Application.DTOs.BorrowingRequest;
using ManhPT_MidAssignment.Domain.Enum;

namespace ManhPT_MidAssignment.Application.Services.BorrowRequestService
{
    public interface IBorrowRequestService
    {
        Task<BorrowingRequestDTO> GetByIdAsync(Guid Id);
        Task<string> BorrowBooksAsync(Guid userId, string userName, List<Guid> bookIds);
        Task<bool> UpdateRequestStatusAsync(Guid userId, string userName, Guid requestId, Status status);
        Task<bool> ConfirmReturnedAsync(Guid userId, string userName, Guid requestId);
        Task<PaginationResponse<BorrowingRequestDTO>> GetRequestAsync(FilterRequest request);
        Task<PaginationResponse<BorrowingRequestDTO>> GetRequestNotReturnedAsync(FilterRequest request);
        Task<PaginationResponse<BorrowingRequestDTO>> GetRequestByRequestorIdAsync(FilterRequest filter, Guid id);
    }
}
