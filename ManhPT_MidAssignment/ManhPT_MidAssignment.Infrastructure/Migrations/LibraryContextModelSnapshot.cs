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

            modelBuilder.Entity("ManhPT_MidAssignment.Core.Entity.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

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
                            Id = new Guid("c3382870-66ae-4575-b860-da5d246d57c3"),
                            Author = "J. R. R. Tolkien",
                            CategoryId = new Guid("1f04fa64-3152-48c7-8fab-8450e6664b2c"),
                            CreatedAt = new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3327),
                            IsAvailable = true,
                            ModifiedAt = new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3328),
                            Title = "The Lord of the Rings"
                        },
                        new
                        {
                            Id = new Guid("79aeedbb-df61-4748-b6e2-8c5461e6f3ef"),
                            Author = "Stephen Hawking",
                            CategoryId = new Guid("6dadbd5e-7271-42d8-bba5-2144c73574cc"),
                            CreatedAt = new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3332),
                            IsAvailable = true,
                            ModifiedAt = new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3333),
                            Title = "A Brief History of Time"
                        },
                        new
                        {
                            Id = new Guid("720e2c5a-2cad-40df-9af6-b543ad1f3621"),
                            Author = "Orson Scott Card",
                            CategoryId = new Guid("01f95049-9e3d-481c-a94c-dc500e417e7a"),
                            CreatedAt = new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3336),
                            IsAvailable = true,
                            ModifiedAt = new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3337),
                            Title = "Ender's Game"
                        },
                        new
                        {
                            Id = new Guid("c23c9363-686c-466f-9cfa-af6f062a4464"),
                            Author = "Patrick Rothfuss",
                            CategoryId = new Guid("e262bd07-fdd5-43ab-ac21-2f8fbd7961a2"),
                            CreatedAt = new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3340),
                            IsAvailable = true,
                            ModifiedAt = new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3340),
                            Title = "The Name of the Wind"
                        },
                        new
                        {
                            Id = new Guid("18e26815-6f42-4deb-99b7-096df3ebf180"),
                            Author = "Agatha Christie",
                            CategoryId = new Guid("c49db540-9936-475e-b537-c962b207ee8b"),
                            CreatedAt = new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3346),
                            IsAvailable = true,
                            ModifiedAt = new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3347),
                            Title = "And Then There Were None"
                        });
                });

            modelBuilder.Entity("ManhPT_MidAssignment.Core.Entity.BookBorrowingRequest", b =>
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

            modelBuilder.Entity("ManhPT_MidAssignment.Core.Entity.BookBorrowingRequestDetails", b =>
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

                    b.HasKey("BorrowingRequestId", "BookId");

                    b.HasIndex("BookBorrowingRequestId");

                    b.HasIndex("BookId");

                    b.ToTable("BookBorrowingRequestDetails");
                });

            modelBuilder.Entity("ManhPT_MidAssignment.Core.Entity.Category", b =>
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
                            Id = new Guid("1f04fa64-3152-48c7-8fab-8450e6664b2c"),
                            CreatedAt = new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3235),
                            ModifiedAt = new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3236),
                            Name = "Fiction"
                        },
                        new
                        {
                            Id = new Guid("6dadbd5e-7271-42d8-bba5-2144c73574cc"),
                            CreatedAt = new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3262),
                            ModifiedAt = new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3262),
                            Name = "Non-Fiction"
                        },
                        new
                        {
                            Id = new Guid("01f95049-9e3d-481c-a94c-dc500e417e7a"),
                            CreatedAt = new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3265),
                            ModifiedAt = new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3265),
                            Name = "Science Fiction"
                        },
                        new
                        {
                            Id = new Guid("e262bd07-fdd5-43ab-ac21-2f8fbd7961a2"),
                            CreatedAt = new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3267),
                            ModifiedAt = new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3268),
                            Name = "Fantasy"
                        },
                        new
                        {
                            Id = new Guid("c49db540-9936-475e-b537-c962b207ee8b"),
                            CreatedAt = new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3270),
                            ModifiedAt = new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3271),
                            Name = "Mystery"
                        });
                });

            modelBuilder.Entity("ManhPT_MidAssignment.Core.Entity.User", b =>
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
                            Id = new Guid("babe40c2-6b18-465b-be89-00994a44d494"),
                            CreatedAt = new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3085),
                            Email = "user1@example.com",
                            ModifiedAt = new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3115),
                            Name = "user1",
                            Password = "$2a$12$0NPISodxxD/AH/OGrKghM.xTFgZHmg1MZlDC.FJo6SS7gYSdhdo9i",
                            Role = 0
                        },
                        new
                        {
                            Id = new Guid("d6d2aeb7-b798-446a-947d-2a4e3926b2a1"),
                            CreatedAt = new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3121),
                            Email = "user2@example.com",
                            ModifiedAt = new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3122),
                            Name = "user2",
                            Password = "$2a$12$0NPISodxxD/AH/OGrKghM.xTFgZHmg1MZlDC.FJo6SS7gYSdhdo9i",
                            Role = 0
                        },
                        new
                        {
                            Id = new Guid("20ec4eb0-71a6-4f00-9e24-28cfa5c1008e"),
                            CreatedAt = new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3125),
                            Email = "admin@example.com",
                            ModifiedAt = new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3125),
                            Name = "admin",
                            Password = "$2a$12$0NPISodxxD/AH/OGrKghM.xTFgZHmg1MZlDC.FJo6SS7gYSdhdo9i",
                            Role = 1
                        },
                        new
                        {
                            Id = new Guid("208b1fc4-a19b-4634-8233-333a521117ec"),
                            CreatedAt = new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3128),
                            Email = "user3@example.com",
                            ModifiedAt = new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3129),
                            Name = "user3",
                            Password = "$2a$12$0NPISodxxD/AH/OGrKghM.xTFgZHmg1MZlDC.FJo6SS7gYSdhdo9i",
                            Role = 0
                        },
                        new
                        {
                            Id = new Guid("9cd712f0-cdaa-4ad7-b7e0-278b68c5ccb0"),
                            CreatedAt = new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3131),
                            Email = "user4@example.com",
                            ModifiedAt = new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3132),
                            Name = "user4",
                            Password = "$2a$12$0NPISodxxD/AH/OGrKghM.xTFgZHmg1MZlDC.FJo6SS7gYSdhdo9i",
                            Role = 0
                        });
                });

            modelBuilder.Entity("ManhPT_MidAssignment.Core.Entity.Book", b =>
                {
                    b.HasOne("ManhPT_MidAssignment.Core.Entity.Category", "Category")
                        .WithMany("Books")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ManhPT_MidAssignment.Core.Entity.BookBorrowingRequest", b =>
                {
                    b.HasOne("ManhPT_MidAssignment.Core.Entity.User", "Approver")
                        .WithMany()
                        .HasForeignKey("ApproverId");

                    b.HasOne("ManhPT_MidAssignment.Core.Entity.User", "Requestor")
                        .WithMany("BookBorrowingRequests")
                        .HasForeignKey("RequestorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Approver");

                    b.Navigation("Requestor");
                });

            modelBuilder.Entity("ManhPT_MidAssignment.Core.Entity.BookBorrowingRequestDetails", b =>
                {
                    b.HasOne("ManhPT_MidAssignment.Core.Entity.BookBorrowingRequest", "BookBorrowingRequest")
                        .WithMany("BookBorrowingRequestDetails")
                        .HasForeignKey("BookBorrowingRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ManhPT_MidAssignment.Core.Entity.Book", "Book")
                        .WithMany("BookBorrowingRequestDetails")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("BookBorrowingRequest");
                });

            modelBuilder.Entity("ManhPT_MidAssignment.Core.Entity.Book", b =>
                {
                    b.Navigation("BookBorrowingRequestDetails");
                });

            modelBuilder.Entity("ManhPT_MidAssignment.Core.Entity.BookBorrowingRequest", b =>
                {
                    b.Navigation("BookBorrowingRequestDetails");
                });

            modelBuilder.Entity("ManhPT_MidAssignment.Core.Entity.Category", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("ManhPT_MidAssignment.Core.Entity.User", b =>
                {
                    b.Navigation("BookBorrowingRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
