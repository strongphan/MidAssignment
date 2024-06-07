using ManhPT_MidAssignment.Domain.Enum;

namespace ManhPT_MidAssignment.Domain.Entity
{
    public class BookBorrowingRequest : BaseEntity
    {

        public Guid RequestorId { get; set; }
        public User Requestor { get; set; }
        public DateTime DateRequested { get; set; }
        public Status Status { get; set; } = Status.Waiting;
        public bool IsReturn { get; set; } = false;
        public Guid? ApproverId { get; set; } // nullable for pending requests
        public User Approver { get; set; }

        public ICollection<BookBorrowingRequestDetails> BookBorrowingRequestDetails { get; set; }
    }
}
