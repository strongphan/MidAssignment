using System.ComponentModel.DataAnnotations;

namespace ManhPT_MidAssignment.Application.DTOs.CategoryDTOs
{
    public class CategoryDTO
    {
        public Guid Id { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
    }
}
