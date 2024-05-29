using ManhPT_MidAssignment.Core.Enum;

namespace ManhPT_MidAssignment.Core.Entity
{
    public class User : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public string Email { get; set; }
        public ICollection<BookBorrowingRequest> BookBorrowingRequests { get; set; }
    }
}
