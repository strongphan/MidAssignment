using System.ComponentModel.DataAnnotations;

namespace ManhPT_MidAssignment.Domain.Entity
{
    public class Book : BaseEntity
    {

        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; }

        [StringLength(100, MinimumLength = 3)]
        public string Author { get; set; }

        [StringLength(500, MinimumLength = 10)]
        public string? Description { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public int AvailableCopies { get; set; }
        public ICollection<BookBorrowingRequestDetails> BookBorrowingRequestDetails { get; set; }
    }
}
