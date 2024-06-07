using ManhPT_MidAssignment.Application.DTOs.BorrowingRequest;
using ManhPT_MidAssignment.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace ManhPT_MidAssignment.Application.DTOs.AuthDTOs
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }
        public Role Role { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public ICollection<BorrowingRequestDTO> BookBorrowingRequests { get; set; }
    }
}
