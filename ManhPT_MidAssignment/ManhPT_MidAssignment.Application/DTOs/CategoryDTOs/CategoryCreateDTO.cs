using System.ComponentModel.DataAnnotations;

namespace ManhPT_MidAssignment.Application.DTOs.CategoryDTOs
{
    public class CategoryCreateDTO
    {

        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
    }
}
