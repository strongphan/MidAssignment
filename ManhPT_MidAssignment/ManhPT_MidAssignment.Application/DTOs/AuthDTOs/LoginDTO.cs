using System.ComponentModel.DataAnnotations;

namespace ManhPT_MidAssignment.Application.DTOs.AuthDTOs
{
    public class LoginDTO
    {
        [Required, EmailAddress]

        public string? Email { get; set; } = string.Empty;
        [Required]
        public string? Password { get; set; } = string.Empty;
    }
}
