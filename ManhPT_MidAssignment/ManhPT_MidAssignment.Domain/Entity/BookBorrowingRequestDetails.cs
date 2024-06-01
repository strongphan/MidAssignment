namespace ManhPT_MidAssignment.Domain.Entity
{
    public class BookBorrowingRequestDetails : BaseEntity
    {
        public Guid BorrowingRequestId { get; set; }
        public BookBorrowingRequest BookBorrowingRequest { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }

    }
}
