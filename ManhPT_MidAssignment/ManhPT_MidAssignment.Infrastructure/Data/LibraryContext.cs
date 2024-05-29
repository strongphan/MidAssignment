using ManhPT_MidAssignment.Core.Entity;
using ManhPT_MidAssignment.Core.Enum;
using Microsoft.EntityFrameworkCore;

namespace ManhPT_MidAssignment.Infrastructure.Data
{
    public class LibraryContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BookBorrowingRequest> BookBorrowingRequests { get; set; }
        public DbSet<BookBorrowingRequestDetails> BookBorrowingRequestDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.BookBorrowingRequests)
                .WithOne(br => br.Requestor)
                .HasForeignKey(br => br.RequestorId);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CategoryId);

            modelBuilder.Entity<BookBorrowingRequest>()
                .HasOne(br => br.Requestor)
                .WithMany(u => u.BookBorrowingRequests)
                .HasForeignKey(br => br.RequestorId);

            modelBuilder.Entity<BookBorrowingRequest>()
                .HasOne(br => br.Approver)
                .WithMany()
                .HasForeignKey(br => br.ApproverId);

            modelBuilder.Entity<BookBorrowingRequestDetails>()
                .HasKey(br => new { br.BorrowingRequestId, br.BookId }); // Define composite primary key

            var users = new List<User>()
                {
                        new() { Id= Guid.NewGuid(), Name = "user1", Password = "hashedPassword", Role = Role.User, Email = "user1@example.com" },
                        new() { Id= Guid.NewGuid(), Name = "user2", Password = "hashedPassword", Role = Role.User, Email = "user2@example.com" },
                        new() { Id= Guid.NewGuid(), Name = "admin", Password = "hashedPassword", Role = Role.Admin, Email = "admin@example.com" },
                        new() { Id= Guid.NewGuid(), Name = "user3", Password = "hashedPassword", Role = Role.User, Email = "user3@example.com" },
                        new() { Id= Guid.NewGuid(), Name = "user4", Password = "hashedPassword", Role = Role.User, Email = "user4@example.com" },
                };
            modelBuilder.Entity<User>().HasData(users);

            var categories = new List<Category>()
                {
                    new Category { Id= Guid.NewGuid(), Name = "Fiction" },
                    new Category { Id= Guid.NewGuid(), Name = "Non-Fiction" },
                    new Category { Id= Guid.NewGuid(), Name = "Science Fiction" },
                    new Category { Id= Guid.NewGuid(), Name = "Fantasy" },
                    new Category { Id= Guid.NewGuid(), Name = "Mystery" },
                };
            modelBuilder.Entity<Category>().HasData(categories);

            var books = new List<Book>()
                {
                    new Book { Id= Guid.NewGuid(), Title = "The Lord of the Rings", Author = "J. R. R. Tolkien", CategoryId = categories[0].Id }, // Fiction
                    new Book { Id= Guid.NewGuid(), Title =  "A Brief History of Time", Author = "Stephen Hawking", CategoryId = categories[1].Id }, // Non-Fiction
                    new Book { Id= Guid.NewGuid(), Title = "Ender's Game", Author = "Orson Scott Card", CategoryId = categories[2].Id }, // Science Fiction
                    new Book { Id= Guid.NewGuid(), Title = "The Name of the Wind", Author = "Patrick Rothfuss", CategoryId = categories[3].Id }, // Fantasy
                    new Book { Id= Guid.NewGuid(), Title = "And Then There Were None", Author = "Agatha Christie", CategoryId = categories[4].Id }, // Mystery
                };
            modelBuilder.Entity<Book>().HasData(books);


            base.OnModelCreating(modelBuilder);
        }

    }
}
