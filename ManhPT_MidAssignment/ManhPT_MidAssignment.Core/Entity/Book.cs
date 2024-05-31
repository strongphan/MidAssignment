using System.ComponentModel.DataAnnotations;

namespace ManhPT_MidAssignment.Core.Entity
{
    public class Book : BaseEntity
    {
        public Guid Id { get; set; }

        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; }

        [StringLength(100, MinimumLength = 3)]
        public string Author { get; set; }

        [StringLength(500, MinimumLength = 10)]
        public string? Description { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public bool IsAvailable { get; set; } = true;
        public ICollection<BookBorrowingRequestDetails> BookBorrowingRequestDetails { get; set; }
    }
}
