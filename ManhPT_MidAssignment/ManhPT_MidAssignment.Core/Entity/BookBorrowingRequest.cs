using ManhPT_MidAssignment.Core.Enum;

namespace ManhPT_MidAssignment.Core.Entity
{
    public class BookBorrowingRequest : BaseEntity
    {

        public Guid Id { get; set; }
        public Guid RequestorId { get; set; }
        public User Requestor { get; set; }
        public DateTime DateRequested { get; set; }
        public Status Status { get; set; }
        public Guid? ApproverId { get; set; } // nullable for pending requests
        public User Approver { get; set; }

        public ICollection<BookBorrowingRequestDetails> BookBorrowingRequestDetails { get; set; }
    }
}
