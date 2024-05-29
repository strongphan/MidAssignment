namespace ManhPT_MidAssignment.Core.Entity
{
    public class Category : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
