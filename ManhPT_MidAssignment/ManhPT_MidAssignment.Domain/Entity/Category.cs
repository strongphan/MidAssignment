using System.ComponentModel.DataAnnotations;

namespace ManhPT_MidAssignment.Domain.Entity
{
    public class Category : BaseEntity
    {

        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
