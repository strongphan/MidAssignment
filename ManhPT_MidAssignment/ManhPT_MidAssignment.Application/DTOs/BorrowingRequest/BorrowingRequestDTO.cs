using ManhPT_MidAssignment.Application.DTOs.AuthDTOs;
using ManhPT_MidAssignment.Domain.Enum;

namespace ManhPT_MidAssignment.Application.DTOs.BorrowingRequest
{
    public class BorrowingRequestDTO
    {
        public Guid Id { get; set; }
        public Guid RequestorId { get; set; }
        public UserLessDTO Requestor { get; set; }
        public DateTime DateRequested { get; set; }
        public Status Status { get; set; }
        public bool IsReturn { get; set; } = false;
        public Guid? ApproverId { get; set; }
        public UserLessDTO Approver { get; set; }
        public ICollection<BorrowingRequestDetailDTO> BookBorrowingRequestDetails { get; set; }
    }
}
