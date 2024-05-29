using ManhPT_MidAssignment.Core.Entity;

namespace ManhPT_MidAssignment.Application.DTOs.BookDTOs
{
    public class BookDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int AvailableCopies { get; set; }
    }
}
