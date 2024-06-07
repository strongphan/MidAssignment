using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ManhPT_MidAssignment.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AvailableCopies = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookBorrowingRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateRequested = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IsReturn = table.Column<bool>(type: "bit", nullable: false),
                    ApproverId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookBorrowingRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookBorrowingRequests_Users_ApproverId",
                        column: x => x.ApproverId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_BookBorrowingRequests_Users_RequestorId",
                        column: x => x.RequestorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookBorrowingRequestDetails",
                columns: table => new
                {
                    BorrowingRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookBorrowingRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookBorrowingRequestDetails", x => new { x.BorrowingRequestId, x.BookId });
                    table.ForeignKey(
                        name: "FK_BookBorrowingRequestDetails_BookBorrowingRequests_BookBorrowingRequestId",
                        column: x => x.BookBorrowingRequestId,
                        principalTable: "BookBorrowingRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookBorrowingRequestDetails_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("021774e2-1195-445c-99de-49c62e523ab2"), new DateTime(2024, 6, 7, 9, 29, 23, 814, DateTimeKind.Local).AddTicks(7227), null, new DateTime(2024, 6, 7, 9, 29, 23, 814, DateTimeKind.Local).AddTicks(7228), null, "Non-Fiction" },
                    { new Guid("0d44adf2-c781-45cb-af10-a831843a680f"), new DateTime(2024, 6, 7, 9, 29, 23, 814, DateTimeKind.Local).AddTicks(7233), null, new DateTime(2024, 6, 7, 9, 29, 23, 814, DateTimeKind.Local).AddTicks(7234), null, "Mystery" },
                    { new Guid("0e1d02a8-6052-4384-9b5b-d60d1c9403d5"), new DateTime(2024, 6, 7, 9, 29, 23, 814, DateTimeKind.Local).AddTicks(7229), null, new DateTime(2024, 6, 7, 9, 29, 23, 814, DateTimeKind.Local).AddTicks(7230), null, "Science Fiction" },
                    { new Guid("1a9158d2-26c0-4c05-b6dd-773dcd1ff63a"), new DateTime(2024, 6, 7, 9, 29, 23, 814, DateTimeKind.Local).AddTicks(7231), null, new DateTime(2024, 6, 7, 9, 29, 23, 814, DateTimeKind.Local).AddTicks(7232), null, "Fantasy" },
                    { new Guid("65209f03-4db1-49be-bea4-12073495ae6b"), new DateTime(2024, 6, 7, 9, 29, 23, 814, DateTimeKind.Local).AddTicks(7207), null, new DateTime(2024, 6, 7, 9, 29, 23, 814, DateTimeKind.Local).AddTicks(7208), null, "Fiction" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Email", "ModifiedAt", "ModifiedBy", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { new Guid("0007b24b-c914-41fd-b674-6a2d5b38226d"), new DateTime(2024, 6, 7, 9, 29, 23, 814, DateTimeKind.Local).AddTicks(7097), null, "admin@example.com", new DateTime(2024, 6, 7, 9, 29, 23, 814, DateTimeKind.Local).AddTicks(7098), null, "admin", "$2a$12$0NPISodxxD/AH/OGrKghM.xTFgZHmg1MZlDC.FJo6SS7gYSdhdo9i", 1 },
                    { new Guid("30caa91c-9e16-464b-801e-23dc6b849edb"), new DateTime(2024, 6, 7, 9, 29, 23, 814, DateTimeKind.Local).AddTicks(7103), null, "user4@example.com", new DateTime(2024, 6, 7, 9, 29, 23, 814, DateTimeKind.Local).AddTicks(7103), null, "user4", "$2a$12$0NPISodxxD/AH/OGrKghM.xTFgZHmg1MZlDC.FJo6SS7gYSdhdo9i", 0 },
                    { new Guid("8d6862bc-162e-47c4-b70d-45db33167b29"), new DateTime(2024, 6, 7, 9, 29, 23, 814, DateTimeKind.Local).AddTicks(7094), null, "user2@example.com", new DateTime(2024, 6, 7, 9, 29, 23, 814, DateTimeKind.Local).AddTicks(7094), null, "user2", "$2a$12$0NPISodxxD/AH/OGrKghM.xTFgZHmg1MZlDC.FJo6SS7gYSdhdo9i", 0 },
                    { new Guid("d0be0600-cae9-42ff-8879-79618b7ea7eb"), new DateTime(2024, 6, 7, 9, 29, 23, 814, DateTimeKind.Local).AddTicks(7069), null, "user1@example.com", new DateTime(2024, 6, 7, 9, 29, 23, 814, DateTimeKind.Local).AddTicks(7087), null, "user1", "$2a$12$0NPISodxxD/AH/OGrKghM.xTFgZHmg1MZlDC.FJo6SS7gYSdhdo9i", 0 },
                    { new Guid("e9f29034-0170-4c6f-b6de-803087674b2f"), new DateTime(2024, 6, 7, 9, 29, 23, 814, DateTimeKind.Local).AddTicks(7100), null, "user3@example.com", new DateTime(2024, 6, 7, 9, 29, 23, 814, DateTimeKind.Local).AddTicks(7101), null, "user3", "$2a$12$0NPISodxxD/AH/OGrKghM.xTFgZHmg1MZlDC.FJo6SS7gYSdhdo9i", 0 }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "AvailableCopies", "CategoryId", "CreatedAt", "CreatedBy", "Description", "ModifiedAt", "ModifiedBy", "Title" },
                values: new object[,]
                {
                    { new Guid("03383ea8-cf5d-403c-8fd3-e3bf8ab36c20"), "Gabriel García Márquez", 10, new Guid("0d44adf2-c781-45cb-af10-a831843a680f"), new DateTime(2024, 6, 7, 9, 29, 23, 814, DateTimeKind.Local).AddTicks(7310), null, null, new DateTime(2024, 6, 7, 9, 29, 23, 814, DateTimeKind.Local).AddTicks(7311), null, "One Hundred Years of Solitude" },
                    { new Guid("4d3a4488-06a4-47b6-96d2-06170f501a62"), "Harper Lee", 10, new Guid("0e1d02a8-6052-4384-9b5b-d60d1c9403d5"), new DateTime(2024, 6, 7, 9, 29, 23, 814, DateTimeKind.Local).AddTicks(7305), null, null, new DateTime(2024, 6, 7, 9, 29, 23, 814, DateTimeKind.Local).AddTicks(7306), null, "To Kill a Mockingbird" },
                    { new Guid("66dafbbe-7632-4c57-bffc-56e8b8374ca4"), "Mary Shelley", 10, new Guid("1a9158d2-26c0-4c05-b6dd-773dcd1ff63a"), new DateTime(2024, 6, 7, 9, 29, 23, 814, DateTimeKind.Local).AddTicks(7318), null, null, new DateTime(2024, 6, 7, 9, 29, 23, 814, DateTimeKind.Local).AddTicks(7319), null, "Frankenstein" },
                    { new Guid("696630fa-26d1-4f2b-9130-6de86dfb966b"), "Agatha Christie", 10, new Guid("0d44adf2-c781-45cb-af10-a831843a680f"), new DateTime(2024, 6, 7, 9, 29, 23, 814, DateTimeKind.Local).AddTicks(7299), null, null, new DateTime(2024, 6, 7, 9, 29, 23, 814, DateTimeKind.Local).AddTicks(7300), null, "And Then There Were None" },
                    { new Guid("7304dfdf-1737-4615-be6c-30a817a9eefb"), "Orson Scott Card", 10, new Guid("0e1d02a8-6052-4384-9b5b-d60d1c9403d5"), new DateTime(2024, 6, 7, 9, 29, 23, 814, DateTimeKind.Local).AddTicks(7292), null, null, new DateTime(2024, 6, 7, 9, 29, 23, 814, DateTimeKind.Local).AddTicks(7292), null, "Ender's Game" },
                    { new Guid("82e9c557-88ed-40e3-a0e2-e9339a6510af"), "Jane Austen", 10, new Guid("021774e2-1195-445c-99de-49c62e523ab2"), new DateTime(2024, 6, 7, 9, 29, 23, 814, DateTimeKind.Local).AddTicks(7303), null, null, new DateTime(2024, 6, 7, 9, 29, 23, 814, DateTimeKind.Local).AddTicks(7303), null, "Pride and Prejudice" },
                    { new Guid("8a6f2788-28f2-42ae-8fd4-024c695ce374"), "F. Scott Fitzgerald", 10, new Guid("1a9158d2-26c0-4c05-b6dd-773dcd1ff63a"), new DateTime(2024, 6, 7, 9, 29, 23, 814, DateTimeKind.Local).AddTicks(7308), null, null, new DateTime(2024, 6, 7, 9, 29, 23, 814, DateTimeKind.Local).AddTicks(7308), null, "The Great Gatsby" },
                    { new Guid("8d6c1f7d-3775-444e-82c5-c194482aaeac"), "Marcel Proust", 10, new Guid("0e1d02a8-6052-4384-9b5b-d60d1c9403d5"), new DateTime(2024, 6, 7, 9, 29, 23, 814, DateTimeKind.Local).AddTicks(7313), null, null, new DateTime(2024, 6, 7, 9, 29, 23, 814, DateTimeKind.Local).AddTicks(7314), null, "In Search of Lost Time" },
                    { new Guid("96b77c6a-7e66-4c18-b699-35d8880afa91"), "Patrick Rothfuss", 10, new Guid("1a9158d2-26c0-4c05-b6dd-773dcd1ff63a"), new DateTime(2024, 6, 7, 9, 29, 23, 814, DateTimeKind.Local).AddTicks(7294), null, null, new DateTime(2024, 6, 7, 9, 29, 23, 814, DateTimeKind.Local).AddTicks(7295), null, "The Name of the Wind" },
                    { new Guid("ba8c650a-9ac1-4c50-aa57-ba327bea3744"), "Stephen Hawking", 10, new Guid("021774e2-1195-445c-99de-49c62e523ab2"), new DateTime(2024, 6, 7, 9, 29, 23, 814, DateTimeKind.Local).AddTicks(7289), null, null, new DateTime(2024, 6, 7, 9, 29, 23, 814, DateTimeKind.Local).AddTicks(7289), null, "A Brief History of Time" },
                    { new Guid("f6dea16e-cc8e-4bff-9ddb-319af23a597f"), "J. R. R. Tolkien", 10, new Guid("65209f03-4db1-49be-bea4-12073495ae6b"), new DateTime(2024, 6, 7, 9, 29, 23, 814, DateTimeKind.Local).AddTicks(7284), null, null, new DateTime(2024, 6, 7, 9, 29, 23, 814, DateTimeKind.Local).AddTicks(7285), null, "The Lord of the Rings" },
                    { new Guid("ffdb73c2-5fb6-4b65-be7a-42404f6d320f"), "Miguel de Cervantes", 10, new Guid("0d44adf2-c781-45cb-af10-a831843a680f"), new DateTime(2024, 6, 7, 9, 29, 23, 814, DateTimeKind.Local).AddTicks(7316), null, null, new DateTime(2024, 6, 7, 9, 29, 23, 814, DateTimeKind.Local).AddTicks(7316), null, "Don Quixote" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookBorrowingRequestDetails_BookBorrowingRequestId",
                table: "BookBorrowingRequestDetails",
                column: "BookBorrowingRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_BookBorrowingRequestDetails_BookId",
                table: "BookBorrowingRequestDetails",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookBorrowingRequests_ApproverId",
                table: "BookBorrowingRequests",
                column: "ApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_BookBorrowingRequests_RequestorId",
                table: "BookBorrowingRequests",
                column: "RequestorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookBorrowingRequestDetails");

            migrationBuilder.DropTable(
                name: "BookBorrowingRequests");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
