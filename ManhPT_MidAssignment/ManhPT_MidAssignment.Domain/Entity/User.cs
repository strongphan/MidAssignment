using ManhPT_MidAssignment.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace ManhPT_MidAssignment.Domain.Entity
{
    public class User : BaseEntity
    {
        public Guid Id { get; set; }

        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public ICollection<BookBorrowingRequest> BookBorrowingRequests { get; set; }
    }
}
