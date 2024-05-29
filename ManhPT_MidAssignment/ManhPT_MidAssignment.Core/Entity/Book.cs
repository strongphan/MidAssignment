namespace ManhPT_MidAssignment.Core.Entity
{
    public class Book : BaseEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string? Description { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public int AvailableCopies { get; set; }

        public ICollection<BookBorrowingRequestDetails> BookBorrowingRequestDetails { get; set; }
    }
}
