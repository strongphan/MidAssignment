﻿namespace ManhPT_MidAssignment.Core.Entity
{
    public class BookBorrowingRequestDetails : BaseEntity
    {
        public Guid BorrowingRequestId { get; set; }
        public BookBorrowingRequest BookBorrowingRequest { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }

    }
}
