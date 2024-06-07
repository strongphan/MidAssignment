using ManhPT_MidAssignment.Application.DTOs.BookDTOs;

namespace ManhPT_MidAssignment.Application.DTOs.BorrowingRequest
{
    public class BorrowingRequestDetailDTO
    {
        public Guid BorrowingRequestId { get; set; }
        public Guid BookId { get; set; }
        public BookDTO Book { get; set; }
        public int Quantity { get; set; }
    }
}
