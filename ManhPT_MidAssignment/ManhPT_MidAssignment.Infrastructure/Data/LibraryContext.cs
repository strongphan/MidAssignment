using ManhPT_MidAssignment.Domain.Entity;
using ManhPT_MidAssignment.Domain.Enum;
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
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BookBorrowingRequest>()
                .HasOne(br => br.Requestor)
                .WithMany(u => u.BookBorrowingRequests)
                .HasForeignKey(br => br.RequestorId)
                .OnDelete(DeleteBehavior.Restrict);  // Ensure referential integrity on delete

            modelBuilder.Entity<BookBorrowingRequest>()
                .HasOne(br => br.Approver)
                .WithMany()
                .HasForeignKey(br => br.ApproverId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<BookBorrowingRequestDetails>()
                .HasKey(br => new { br.BorrowingRequestId, br.BookId });

            var users = new List<User>()
                {
                        new() { Id= Guid.NewGuid(), Name = "user1", Password = "$2a$12$0NPISodxxD/AH/OGrKghM.xTFgZHmg1MZlDC.FJo6SS7gYSdhdo9i", Role = Role.User, Email = "user1@example.com" , CreatedAt= DateTime.Now, ModifiedAt =DateTime.Now},
                        new() { Id= Guid.NewGuid(), Name = "user2", Password = "$2a$12$0NPISodxxD/AH/OGrKghM.xTFgZHmg1MZlDC.FJo6SS7gYSdhdo9i", Role = Role.User, Email = "user2@example.com" , CreatedAt= DateTime.Now, ModifiedAt =DateTime.Now},
                        new() { Id= Guid.NewGuid(), Name = "admin", Password = "$2a$12$0NPISodxxD/AH/OGrKghM.xTFgZHmg1MZlDC.FJo6SS7gYSdhdo9i", Role = Role.Admin, Email = "admin@example.com" , CreatedAt= DateTime.Now, ModifiedAt =DateTime.Now},
                        new() { Id= Guid.NewGuid(), Name = "user3", Password = "$2a$12$0NPISodxxD/AH/OGrKghM.xTFgZHmg1MZlDC.FJo6SS7gYSdhdo9i", Role = Role.User, Email = "user3@example.com" , CreatedAt= DateTime.Now, ModifiedAt =DateTime.Now},
                        new() { Id= Guid.NewGuid(), Name = "user4", Password = "$2a$12$0NPISodxxD/AH/OGrKghM.xTFgZHmg1MZlDC.FJo6SS7gYSdhdo9i", Role = Role.User, Email = "user4@example.com" , CreatedAt= DateTime.Now, ModifiedAt =DateTime.Now},
                };
            modelBuilder.Entity<User>().HasData(users);

            var categories = new List<Category>()
                {
                    new Category { Id= Guid.NewGuid(), Name = "Fiction" , CreatedAt= DateTime.Now, ModifiedAt =DateTime.Now},
                    new Category { Id= Guid.NewGuid(), Name = "Non-Fiction", CreatedAt= DateTime.Now, ModifiedAt =DateTime.Now },
                    new Category { Id= Guid.NewGuid(), Name = "Science Fiction" , CreatedAt= DateTime.Now, ModifiedAt =DateTime.Now},
                    new Category { Id= Guid.NewGuid(), Name = "Fantasy" , CreatedAt= DateTime.Now, ModifiedAt =DateTime.Now},
                    new Category { Id= Guid.NewGuid(), Name = "Mystery" , CreatedAt= DateTime.Now, ModifiedAt =DateTime.Now},
                };
            modelBuilder.Entity<Category>().HasData(categories);

            var books = new List<Book>()
                {
                    new Book { Id= Guid.NewGuid(), Title = "The Lord of the Rings", Author = "J. R. R. Tolkien", AvailableCopies=10 ,CategoryId = categories[0].Id , CreatedAt= DateTime.Now, ModifiedAt =DateTime.Now}, // Fiction
                    new Book { Id= Guid.NewGuid(), Title =  "A Brief History of Time", Author = "Stephen Hawking", AvailableCopies=10, CategoryId = categories[1].Id, CreatedAt= DateTime.Now, ModifiedAt =DateTime.Now }, // Non-Fiction
                    new Book { Id= Guid.NewGuid(), Title = "Ender's Game", Author = "Orson Scott Card", AvailableCopies=10, CategoryId = categories[2].Id, CreatedAt= DateTime.Now, ModifiedAt =DateTime.Now }, // Science Fiction
                    new Book { Id= Guid.NewGuid(), Title = "The Name of the Wind", Author = "Patrick Rothfuss", AvailableCopies=10, CategoryId = categories[3].Id, CreatedAt= DateTime.Now, ModifiedAt =DateTime.Now }, // Fantasy
                    new Book { Id= Guid.NewGuid(), Title = "And Then There Were None", Author = "Agatha Christie", AvailableCopies=10, CategoryId = categories[4].Id, CreatedAt= DateTime.Now, ModifiedAt =DateTime.Now }, // Mystery
                    new Book { Id= Guid.NewGuid(), Title = "Pride and Prejudice", Author = "Jane Austen", AvailableCopies=10, CategoryId = categories[1].Id, CreatedAt= DateTime.Now, ModifiedAt =DateTime.Now},
                    new Book { Id= Guid.NewGuid(), Title = "To Kill a Mockingbird", Author = "Harper Lee", AvailableCopies=10, CategoryId = categories[2].Id, CreatedAt= DateTime.Now, ModifiedAt =DateTime.Now},
                    new Book { Id= Guid.NewGuid(), Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", AvailableCopies=10, CategoryId = categories[3].Id, CreatedAt= DateTime.Now, ModifiedAt =DateTime.Now},
                    new Book { Id= Guid.NewGuid(), Title = "One Hundred Years of Solitude", Author = "Gabriel García Márquez", AvailableCopies=10, CategoryId = categories[4].Id, CreatedAt= DateTime.Now, ModifiedAt =DateTime.Now},
                    new Book { Id= Guid.NewGuid(), Title = "In Search of Lost Time", Author = "Marcel Proust", AvailableCopies=10, CategoryId = categories[2].Id, CreatedAt= DateTime.Now, ModifiedAt =DateTime.Now},
                    new Book { Id= Guid.NewGuid(), Title = "Don Quixote", Author = "Miguel de Cervantes", AvailableCopies=10, CategoryId = categories[4].Id, CreatedAt= DateTime.Now, ModifiedAt =DateTime.Now},
                    new Book { Id= Guid.NewGuid(), Title = "Frankenstein", Author = "Mary Shelley", AvailableCopies=10, CategoryId = categories[3].Id, CreatedAt= DateTime.Now, ModifiedAt =DateTime.Now},

            };
            modelBuilder.Entity<Book>().HasData(books);


            base.OnModelCreating(modelBuilder);
        }

    }
}
