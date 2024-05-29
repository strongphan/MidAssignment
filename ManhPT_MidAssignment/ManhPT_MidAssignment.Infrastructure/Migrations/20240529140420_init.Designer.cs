﻿// <auto-generated />
using System;
using ManhPT_MidAssignment.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ManhPT_MidAssignment.Infrastructure.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20240529140420_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AvailableCopies")
                        .HasColumnType("int");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5a879954-b89a-49fc-9c9a-707809235242"),
                            Author = "J. R. R. Tolkien",
                            AvailableCopies = 0,
                            CategoryId = new Guid("ac7d781f-19fe-4959-b9ed-9a85a68d069c"),
                            Title = "The Lord of the Rings"
                        },
                        new
                        {
                            Id = new Guid("837b48c7-126b-442e-912a-d0c8eca4673c"),
                            Author = "Stephen Hawking",
                            AvailableCopies = 0,
                            CategoryId = new Guid("405bd6ce-4c63-4fbb-976b-9a0c0f9b7dec"),
                            Title = "A Brief History of Time"
                        },
                        new
                        {
                            Id = new Guid("da863ab0-80c0-45f5-9287-193e5e85c7e9"),
                            Author = "Orson Scott Card",
                            AvailableCopies = 0,
                            CategoryId = new Guid("f7e248e9-2740-4c1c-93b2-4a69ef1d098a"),
                            Title = "Ender's Game"
                        },
                        new
                        {
                            Id = new Guid("18fcf2db-7d32-43c2-bfd5-7eafeecf8694"),
                            Author = "Patrick Rothfuss",
                            AvailableCopies = 0,
                            CategoryId = new Guid("75da2709-d25f-445d-9d08-da5c893b7733"),
                            Title = "The Name of the Wind"
                        },
                        new
                        {
                            Id = new Guid("be84bc38-bd43-496a-84d3-f824e76cdf9c"),
                            Author = "Agatha Christie",
                            AvailableCopies = 0,
                            CategoryId = new Guid("d7ce4620-589e-403d-b657-bfbcd7fa1f24"),
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

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateRequested")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

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

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

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

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ac7d781f-19fe-4959-b9ed-9a85a68d069c"),
                            Name = "Fiction"
                        },
                        new
                        {
                            Id = new Guid("405bd6ce-4c63-4fbb-976b-9a0c0f9b7dec"),
                            Name = "Non-Fiction"
                        },
                        new
                        {
                            Id = new Guid("f7e248e9-2740-4c1c-93b2-4a69ef1d098a"),
                            Name = "Science Fiction"
                        },
                        new
                        {
                            Id = new Guid("75da2709-d25f-445d-9d08-da5c893b7733"),
                            Name = "Fantasy"
                        },
                        new
                        {
                            Id = new Guid("d7ce4620-589e-403d-b657-bfbcd7fa1f24"),
                            Name = "Mystery"
                        });
                });

            modelBuilder.Entity("ManhPT_MidAssignment.Core.Entity.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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
                            Id = new Guid("389a7dba-4ba0-4f6b-af81-eaa26acde327"),
                            Email = "user1@example.com",
                            Name = "user1",
                            Password = "hashedPassword",
                            Role = 0
                        },
                        new
                        {
                            Id = new Guid("83aefdbf-b60d-4de4-8641-be17f2c04d67"),
                            Email = "user2@example.com",
                            Name = "user2",
                            Password = "hashedPassword",
                            Role = 0
                        },
                        new
                        {
                            Id = new Guid("d5c02a8e-8ddb-4097-9f13-3f443388d79c"),
                            Email = "admin@example.com",
                            Name = "admin",
                            Password = "hashedPassword",
                            Role = 1
                        },
                        new
                        {
                            Id = new Guid("f10096bf-0b7a-4876-8645-e36f086e5873"),
                            Email = "user3@example.com",
                            Name = "user3",
                            Password = "hashedPassword",
                            Role = 0
                        },
                        new
                        {
                            Id = new Guid("0b817c57-270e-4824-9274-055fa097f3c9"),
                            Email = "user4@example.com",
                            Name = "user4",
                            Password = "hashedPassword",
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
