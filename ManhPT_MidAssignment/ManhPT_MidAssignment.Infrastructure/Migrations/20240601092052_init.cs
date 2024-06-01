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
                        onDelete: ReferentialAction.Cascade);
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
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BookBorrowingRequests_Users_RequestorId",
                        column: x => x.RequestorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookBorrowingRequestDetails",
                columns: table => new
                {
                    BorrowingRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookBorrowingRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
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
                    { new Guid("08b4abbf-de6c-4905-a0cf-f85b191feb6b"), new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1253), null, new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1254), null, "Science Fiction" },
                    { new Guid("240aa7ba-54b5-464a-8adc-db5c9776a4a8"), new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1255), null, new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1256), null, "Fantasy" },
                    { new Guid("5a28a879-1814-4468-a5b0-8d26a18f730e"), new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1258), null, new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1258), null, "Mystery" },
                    { new Guid("87557c79-453d-42f6-905c-6187f08ea7d5"), new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1251), null, new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1252), null, "Non-Fiction" },
                    { new Guid("8f6a779d-f748-4e9e-9585-5eaa5ff865b8"), new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1247), null, new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1248), null, "Fiction" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Email", "ModifiedAt", "ModifiedBy", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { new Guid("1f28f317-067b-4868-b042-f791b3d1a470"), new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1175), null, "user4@example.com", new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1176), null, "user4", "$2a$12$0NPISodxxD/AH/OGrKghM.xTFgZHmg1MZlDC.FJo6SS7gYSdhdo9i", 0 },
                    { new Guid("41a9140f-e580-4839-b3d0-af01f420e71b"), new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1152), null, "user2@example.com", new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1153), null, "user2", "$2a$12$0NPISodxxD/AH/OGrKghM.xTFgZHmg1MZlDC.FJo6SS7gYSdhdo9i", 0 },
                    { new Guid("55b3a5aa-6130-444b-9685-2c6ec995c623"), new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1173), null, "user3@example.com", new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1174), null, "user3", "$2a$12$0NPISodxxD/AH/OGrKghM.xTFgZHmg1MZlDC.FJo6SS7gYSdhdo9i", 0 },
                    { new Guid("da914301-d0e2-414a-bdc8-3713b77fbba9"), new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1171), null, "admin@example.com", new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1171), null, "admin", "$2a$12$0NPISodxxD/AH/OGrKghM.xTFgZHmg1MZlDC.FJo6SS7gYSdhdo9i", 1 },
                    { new Guid("dda835e3-6c75-4bb3-a089-a7b02a698ab8"), new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1129), null, "user1@example.com", new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1146), null, "user1", "$2a$12$0NPISodxxD/AH/OGrKghM.xTFgZHmg1MZlDC.FJo6SS7gYSdhdo9i", 0 }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "AvailableCopies", "CategoryId", "CreatedAt", "CreatedBy", "Description", "ModifiedAt", "ModifiedBy", "Title" },
                values: new object[,]
                {
                    { new Guid("0a6dde70-36ed-4239-a8e1-1200769d0e54"), "F. Scott Fitzgerald", 10, new Guid("240aa7ba-54b5-464a-8adc-db5c9776a4a8"), new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1327), null, null, new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1328), null, "The Great Gatsby" },
                    { new Guid("0b268a13-3f2f-4195-aaf0-8e0c838fbf32"), "Mary Shelley", 10, new Guid("240aa7ba-54b5-464a-8adc-db5c9776a4a8"), new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1339), null, null, new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1340), null, "Frankenstein" },
                    { new Guid("17047cfe-4fce-4fa8-9e9f-65c0091c4df4"), "Stephen Hawking", 10, new Guid("87557c79-453d-42f6-905c-6187f08ea7d5"), new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1312), null, null, new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1312), null, "A Brief History of Time" },
                    { new Guid("258e4b1e-4aac-4e75-9876-fd49938de70d"), "J. R. R. Tolkien", 10, new Guid("8f6a779d-f748-4e9e-9585-5eaa5ff865b8"), new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1307), null, null, new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1308), null, "The Lord of the Rings" },
                    { new Guid("3714a890-5112-4f7b-9824-d3b4ba90324c"), "Gabriel García Márquez", 10, new Guid("5a28a879-1814-4468-a5b0-8d26a18f730e"), new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1331), null, null, new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1332), null, "One Hundred Years of Solitude" },
                    { new Guid("3e080535-ecaf-4dea-aa11-fcd68fb903da"), "Patrick Rothfuss", 10, new Guid("240aa7ba-54b5-464a-8adc-db5c9776a4a8"), new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1317), null, null, new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1317), null, "The Name of the Wind" },
                    { new Guid("9a70c16c-1e61-44b8-a14d-492b8fb0ebcd"), "Orson Scott Card", 10, new Guid("08b4abbf-de6c-4905-a0cf-f85b191feb6b"), new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1314), null, null, new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1315), null, "Ender's Game" },
                    { new Guid("9e38ea84-524e-47ff-87cc-21357270a565"), "Agatha Christie", 10, new Guid("5a28a879-1814-4468-a5b0-8d26a18f730e"), new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1319), null, null, new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1320), null, "And Then There Were None" },
                    { new Guid("b2703b5c-2e5a-4432-abc5-dffcb63f8ee3"), "Marcel Proust", 10, new Guid("08b4abbf-de6c-4905-a0cf-f85b191feb6b"), new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1335), null, null, new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1335), null, "In Search of Lost Time" },
                    { new Guid("b8230493-7961-489f-a604-299dca142941"), "Harper Lee", 10, new Guid("08b4abbf-de6c-4905-a0cf-f85b191feb6b"), new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1325), null, null, new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1325), null, "To Kill a Mockingbird" },
                    { new Guid("f182a37f-3bfc-4226-ae3b-0f22e7623f10"), "Miguel de Cervantes", 10, new Guid("5a28a879-1814-4468-a5b0-8d26a18f730e"), new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1337), null, null, new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1337), null, "Don Quixote" },
                    { new Guid("fdad5bad-5082-4989-a195-17d3a56fb830"), "Jane Austen", 10, new Guid("87557c79-453d-42f6-905c-6187f08ea7d5"), new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1322), null, null, new DateTime(2024, 6, 1, 16, 20, 52, 330, DateTimeKind.Local).AddTicks(1323), null, "Pride and Prejudice" }
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
