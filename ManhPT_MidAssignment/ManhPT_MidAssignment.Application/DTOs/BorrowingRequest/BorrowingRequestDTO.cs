using ManhPT_MidAssignment.Domain.Entity;
using ManhPT_MidAssignment.Domain.Enum;

namespace ManhPT_MidAssignment.Application.DTOs.BorrowingRequest
{
    public class BorrowingRequestDTO
    {
        public Guid Id { get; set; }
        public Guid RequestorId { get; set; }
        public User Requestor { get; set; }
        public DateTime DateRequested { get; set; }
        public Status Status { get; set; }
        public bool IsReturn { get; set; } = false;
        public Guid? ApproverId { get; set; } // nullable for pending requests
        public User Approver { get; set; }
    }
}
