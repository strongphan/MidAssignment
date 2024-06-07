using System.ComponentModel.DataAnnotations;

namespace ManhPT_MidAssignment.Application.DTOs.BookDTOs
{
    public class BookCreateDTO
    {
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; }

        [StringLength(100, MinimumLength = 3)]
        public string Author { get; set; }

        [StringLength(500, MinimumLength = 10)]
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        [Required]
        public int AvailableCopies { get; set; }
    }
}
