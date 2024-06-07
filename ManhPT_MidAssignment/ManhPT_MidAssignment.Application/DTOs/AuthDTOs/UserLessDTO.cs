using System.ComponentModel.DataAnnotations;

namespace ManhPT_MidAssignment.Application.DTOs.AuthDTOs
{
    public class UserLessDTO
    {
        public Guid Id { get; set; }
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }
        public string Email { get; set; }

    }
}
