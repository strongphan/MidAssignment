﻿// <auto-generated />
using System;
using ManhPT_MidAssignment.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ManhPT_MidAssignment.Infrastructure.Migrations
{
    [DbContext(typeof(LibraryContext))]
    partial class LibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ManhPT_MidAssignment.Domain.Entity.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("AvailableCopies")
                        .HasColumnType("int");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = new Guid("258e4b1e-4aac-4e75-9876-fd49938de70d"),
                            Author = "J. R. R. Tolkien",
                            AvailableCopies = 10,
                            CategoryId = new Guid("8f6a779d-f748-4e9e-9585-5eaa5ff865b8"),
                            CreatedAt = new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1307),
                            ModifiedAt = new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1308),
                            Title = "The Lord of the Rings"
                        },
                        new
                        {
                            Id = new Guid("17047cfe-4fce-4fa8-9e9f-65c0091c4df4"),
                            Author = "Stephen Hawking",
                            AvailableCopies = 10,
                            CategoryId = new Guid("87557c79-453d-42f6-905c-6187f08ea7d5"),
                            CreatedAt = new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1312),
                            ModifiedAt = new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1312),
                            Title = "A Brief History of Time"
                        },
                        new
                        {
                            Id = new Guid("9a70c16c-1e61-44b8-a14d-492b8fb0ebcd"),
                            Author = "Orson Scott Card",
                            AvailableCopies = 10,
                            CategoryId = new Guid("08b4abbf-de6c-4905-a0cf-f85b191feb6b"),
                            CreatedAt = new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1314),
                            ModifiedAt = new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1315),
                            Title = "Ender's Game"
                        },
                        new
                        {
                            Id = new Guid("3e080535-ecaf-4dea-aa11-fcd68fb903da"),
                            Author = "Patrick Rothfuss",
                            AvailableCopies = 10,
                            CategoryId = new Guid("240aa7ba-54b5-464a-8adc-db5c9776a4a8"),
                            CreatedAt = new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1317),
                            ModifiedAt = new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1317),
                            Title = "The Name of the Wind"
                        },
                        new
                        {
                            Id = new Guid("9e38ea84-524e-47ff-87cc-21357270a565"),
                            Author = "Agatha Christie",
                            AvailableCopies = 10,
                            CategoryId = new Guid("5a28a879-1814-4468-a5b0-8d26a18f730e"),
                            CreatedAt = new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1319),
                            ModifiedAt = new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1320),
                            Title = "And Then There Were None"
                        },
                        new
                        {
                            Id = new Guid("fdad5bad-5082-4989-a195-17d3a56fb830"),
                            Author = "Jane Austen",
                            AvailableCopies = 10,
                            CategoryId = new Guid("87557c79-453d-42f6-905c-6187f08ea7d5"),
                            CreatedAt = new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1322),
                            ModifiedAt = new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1323),
                            Title = "Pride and Prejudice"
                        },
                        new
                        {
                            Id = new Guid("b8230493-7961-489f-a604-299dca142941"),
                            Author = "Harper Lee",
                            AvailableCopies = 10,
                            CategoryId = new Guid("08b4abbf-de6c-4905-a0cf-f85b191feb6b"),
                            CreatedAt = new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1325),
                            ModifiedAt = new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1325),
                            Title = "To Kill a Mockingbird"
                        },
                        new
                        {
                            Id = new Guid("0a6dde70-36ed-4239-a8e1-1200769d0e54"),
                            Author = "F. Scott Fitzgerald",
                            AvailableCopies = 10,
                            CategoryId = new Guid("240aa7ba-54b5-464a-8adc-db5c9776a4a8"),
                            CreatedAt = new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1327),
                            ModifiedAt = new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1328),
                            Title = "The Great Gatsby"
                        },
                        new
                        {
                            Id = new Guid("3714a890-5112-4f7b-9824-d3b4ba90324c"),
                            Author = "Gabriel García Márquez",
                            AvailableCopies = 10,
                            CategoryId = new Guid("5a28a879-1814-4468-a5b0-8d26a18f730e"),
                            CreatedAt = new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1331),
                            ModifiedAt = new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1332),
                            Title = "One Hundred Years of Solitude"
                        },
                        new
                        {
                            Id = new Guid("b2703b5c-2e5a-4432-abc5-dffcb63f8ee3"),
                            Author = "Marcel Proust",
                            AvailableCopies = 10,
                            CategoryId = new Guid("08b4abbf-de6c-4905-a0cf-f85b191feb6b"),
                            CreatedAt = new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1335),
                            ModifiedAt = new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1335),
                            Title = "In Search of Lost Time"
                        },
                        new
                        {
                            Id = new Guid("f182a37f-3bfc-4226-ae3b-0f22e7623f10"),
                            Author = "Miguel de Cervantes",
                            AvailableCopies = 10,
                            CategoryId = new Guid("5a28a879-1814-4468-a5b0-8d26a18f730e"),
                            CreatedAt = new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1337),
                            ModifiedAt = new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1337),
                            Title = "Don Quixote"
                        },
                        new
                        {
                            Id = new Guid("0b268a13-3f2f-4195-aaf0-8e0c838fbf32"),
                            Author = "Mary Shelley",
                            AvailableCopies = 10,
                            CategoryId = new Guid("240aa7ba-54b5-464a-8adc-db5c9776a4a8"),
                            CreatedAt = new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1339),
                            ModifiedAt = new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1340),
                            Title = "Frankenstein"
                        });
                });

            modelBuilder.Entity("ManhPT_MidAssignment.Domain.Entity.BookBorrowingRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ApproverId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateRequested")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsReturn")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RequestorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApproverId");

                    b.HasIndex("RequestorId");

                    b.ToTable("BookBorrowingRequests");
                });

            modelBuilder.Entity("ManhPT_MidAssignment.Domain.Entity.BookBorrowingRequestDetails", b =>
                {
                    b.Property<Guid>("BorrowingRequestId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BookBorrowingRequestId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("BorrowingRequestId", "BookId");

                    b.HasIndex("BookBorrowingRequestId");

                    b.HasIndex("BookId");

                    b.ToTable("BookBorrowingRequestDetails");
                });

            modelBuilder.Entity("ManhPT_MidAssignment.Domain.Entity.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8f6a779d-f748-4e9e-9585-5eaa5ff865b8"),
                            CreatedAt = new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1247),
                            ModifiedAt = new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1248),
                            Name = "Fiction"
                        },
                        new
                        {
                            Id = new Guid("87557c79-453d-42f6-905c-6187f08ea7d5"),
                            CreatedAt = new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1251),
                            ModifiedAt = new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1252),
                            Name = "Non-Fiction"
                        },
                        new
                        {
                            Id = new Guid("08b4abbf-de6c-4905-a0cf-f85b191feb6b"),
                            CreatedAt = new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1253),
                            ModifiedAt = new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1254),
                            Name = "Science Fiction"
                        },
                        new
                        {
                            Id = new Guid("240aa7ba-54b5-464a-8adc-db5c9776a4a8"),
                            CreatedAt = new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1255),
                            ModifiedAt = new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1256),
                            Name = "Fantasy"
                        },
                        new
                        {
                            Id = new Guid("5a28a879-1814-4468-a5b0-8d26a18f730e"),
                            CreatedAt = new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1258),
                            ModifiedAt = new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1258),
                            Name = "Mystery"
                        });
                });

            modelBuilder.Entity("ManhPT_MidAssignment.Domain.Entity.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("dda835e3-6c75-4bb3-a089-a7b02a698ab8"),
                            CreatedAt = new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1129),
                            Email = "user1@example.com",
                            ModifiedAt = new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1146),
                            Name = "user1",
                            Password = "$2a$12$0NPISodxxD/AH/OGrKghM.xTFgZHmg1MZlDC.FJo6SS7gYSdhdo9i",
                            Role = 0
                        },
                        new
                        {
                            Id = new Guid("41a9140f-e580-4839-b3d0-af01f420e71b"),
                            CreatedAt = new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1152),
                            Email = "user2@example.com",
                            ModifiedAt = new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1153),
                            Name = "user2",
                            Password = "$2a$12$0NPISodxxD/AH/OGrKghM.xTFgZHmg1MZlDC.FJo6SS7gYSdhdo9i",
                            Role = 0
                        },
                        new
                        {
                            Id = new Guid("da914301-d0e2-414a-bdc8-3713b77fbba9"),
                            CreatedAt = new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1171),
                            Email = "admin@example.com",
                            ModifiedAt = new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1171),
                            Name = "admin",
                            Password = "$2a$12$0NPISodxxD/AH/OGrKghM.xTFgZHmg1MZlDC.FJo6SS7gYSdhdo9i",
                            Role = 1
                        },
                        new
                        {
                            Id = new Guid("55b3a5aa-6130-444b-9685-2c6ec995c623"),
                            CreatedAt = new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1173),
                            Email = "user3@example.com",
                            ModifiedAt = new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1174),
                            Name = "user3",
                            Password = "$2a$12$0NPISodxxD/AH/OGrKghM.xTFgZHmg1MZlDC.FJo6SS7gYSdhdo9i",
                            Role = 0
                        },
                        new
                        {
                            Id = new Guid("1f28f317-067b-4868-b042-f791b3d1a470"),
                            CreatedAt = new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1175),
                            Email = "user4@example.com",
                            ModifiedAt = new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1176),
                            Name = "user4",
                            Password = "$2a$12$0NPISodxxD/AH/OGrKghM.xTFgZHmg1MZlDC.FJo6SS7gYSdhdo9i",
                            Role = 0
                        });
                });

            modelBuilder.Entity("ManhPT_MidAssignment.Domain.Entity.Book", b =>
                {
                    b.HasOne("ManhPT_MidAssignment.Domain.Entity.Category", "Category")
                        .WithMany("Books")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ManhPT_MidAssignment.Domain.Entity.BookBorrowingRequest", b =>
                {
                    b.HasOne("ManhPT_MidAssignment.Domain.Entity.User", "Approver")
                        .WithMany()
                        .HasForeignKey("ApproverId");

                    b.HasOne("ManhPT_MidAssignment.Domain.Entity.User", "Requestor")
                        .WithMany("BookBorrowingRequests")
                        .HasForeignKey("RequestorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Approver");

                    b.Navigation("Requestor");
                });

            modelBuilder.Entity("ManhPT_MidAssignment.Domain.Entity.BookBorrowingRequestDetails", b =>
                {
                    b.HasOne("ManhPT_MidAssignment.Domain.Entity.BookBorrowingRequest", "BookBorrowingRequest")
                        .WithMany("BookBorrowingRequestDetails")
                        .HasForeignKey("BookBorrowingRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ManhPT_MidAssignment.Domain.Entity.Book", "Book")
                        .WithMany("BookBorrowingRequestDetails")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("BookBorrowingRequest");
                });

            modelBuilder.Entity("ManhPT_MidAssignment.Domain.Entity.Book", b =>
                {
                    b.Navigation("BookBorrowingRequestDetails");
                });

            modelBuilder.Entity("ManhPT_MidAssignment.Domain.Entity.BookBorrowingRequest", b =>
                {
                    b.Navigation("BookBorrowingRequestDetails");
                });

            modelBuilder.Entity("ManhPT_MidAssignment.Domain.Entity.Category", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("ManhPT_MidAssignment.Domain.Entity.User", b =>
                {
                    b.Navigation("BookBorrowingRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
