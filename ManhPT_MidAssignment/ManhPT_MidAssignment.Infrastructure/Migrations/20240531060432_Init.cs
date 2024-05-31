using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ManhPT_MidAssignment.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("24b0146e-300e-48bf-8137-4434e8ba83ce"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("6096b564-b777-4c1e-ba05-dbfe8343e337"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("8f8ae81f-c743-4d56-a349-aea155c5106f"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("e5c7d513-fee0-43d7-925f-24ede7ed4519"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("fbb422c6-0da8-4848-9c27-8048f5e8ad82"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1623ec3f-b2c2-449b-b507-40d3e2dae52a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("19e3996d-466f-45ca-980f-5483f5e4429b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("774c4f47-4bb7-4245-8578-fc5ba755a7c9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("95d7bd4f-bfa2-47dc-90d4-a40e71e62d89"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b5bc1522-2b85-4d42-b22a-d4e4f1cbff30"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("241eafaf-9bdd-41a3-b6f6-aad88ad9bed5"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4921485f-b512-45b0-9458-9c9c2ce6b0f3"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("89f71e04-6cc9-42e0-ba58-92376f46bd89"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("aaac17c8-1c2f-4c0d-b018-4615204b6c6e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ce0e8bda-5e8a-422b-aacd-164b70cffcec"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("01f95049-9e3d-481c-a94c-dc500e417e7a"), new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3265), null, new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3265), null, "Science Fiction" },
                    { new Guid("1f04fa64-3152-48c7-8fab-8450e6664b2c"), new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3235), null, new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3236), null, "Fiction" },
                    { new Guid("6dadbd5e-7271-42d8-bba5-2144c73574cc"), new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3262), null, new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3262), null, "Non-Fiction" },
                    { new Guid("c49db540-9936-475e-b537-c962b207ee8b"), new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3270), null, new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3271), null, "Mystery" },
                    { new Guid("e262bd07-fdd5-43ab-ac21-2f8fbd7961a2"), new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3267), null, new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3268), null, "Fantasy" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Email", "ModifiedAt", "ModifiedBy", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { new Guid("208b1fc4-a19b-4634-8233-333a521117ec"), new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3128), null, "user3@example.com", new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3129), null, "user3", "$2a$12$0NPISodxxD/AH/OGrKghM.xTFgZHmg1MZlDC.FJo6SS7gYSdhdo9i", 0 },
                    { new Guid("20ec4eb0-71a6-4f00-9e24-28cfa5c1008e"), new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3125), null, "admin@example.com", new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3125), null, "admin", "$2a$12$0NPISodxxD/AH/OGrKghM.xTFgZHmg1MZlDC.FJo6SS7gYSdhdo9i", 1 },
                    { new Guid("9cd712f0-cdaa-4ad7-b7e0-278b68c5ccb0"), new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3131), null, "user4@example.com", new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3132), null, "user4", "$2a$12$0NPISodxxD/AH/OGrKghM.xTFgZHmg1MZlDC.FJo6SS7gYSdhdo9i", 0 },
                    { new Guid("babe40c2-6b18-465b-be89-00994a44d494"), new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3085), null, "user1@example.com", new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3115), null, "user1", "$2a$12$0NPISodxxD/AH/OGrKghM.xTFgZHmg1MZlDC.FJo6SS7gYSdhdo9i", 0 },
                    { new Guid("d6d2aeb7-b798-446a-947d-2a4e3926b2a1"), new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3121), null, "user2@example.com", new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3122), null, "user2", "$2a$12$0NPISodxxD/AH/OGrKghM.xTFgZHmg1MZlDC.FJo6SS7gYSdhdo9i", 0 }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CategoryId", "CreatedAt", "CreatedBy", "Description", "IsAvailable", "ModifiedAt", "ModifiedBy", "Title" },
                values: new object[,]
                {
                    { new Guid("18e26815-6f42-4deb-99b7-096df3ebf180"), "Agatha Christie", new Guid("c49db540-9936-475e-b537-c962b207ee8b"), new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3346), null, null, true, new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3347), null, "And Then There Were None" },
                    { new Guid("720e2c5a-2cad-40df-9af6-b543ad1f3621"), "Orson Scott Card", new Guid("01f95049-9e3d-481c-a94c-dc500e417e7a"), new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3336), null, null, true, new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3337), null, "Ender's Game" },
                    { new Guid("79aeedbb-df61-4748-b6e2-8c5461e6f3ef"), "Stephen Hawking", new Guid("6dadbd5e-7271-42d8-bba5-2144c73574cc"), new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3332), null, null, true, new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3333), null, "A Brief History of Time" },
                    { new Guid("c23c9363-686c-466f-9cfa-af6f062a4464"), "Patrick Rothfuss", new Guid("e262bd07-fdd5-43ab-ac21-2f8fbd7961a2"), new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3340), null, null, true, new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3340), null, "The Name of the Wind" },
                    { new Guid("c3382870-66ae-4575-b860-da5d246d57c3"), "J. R. R. Tolkien", new Guid("1f04fa64-3152-48c7-8fab-8450e6664b2c"), new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3327), null, null, true, new DateTime(2024, 5, 31, 13, 4, 31, 511, DateTimeKind.Local).AddTicks(3328), null, "The Lord of the Rings" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("18e26815-6f42-4deb-99b7-096df3ebf180"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("720e2c5a-2cad-40df-9af6-b543ad1f3621"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("79aeedbb-df61-4748-b6e2-8c5461e6f3ef"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("c23c9363-686c-466f-9cfa-af6f062a4464"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("c3382870-66ae-4575-b860-da5d246d57c3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("208b1fc4-a19b-4634-8233-333a521117ec"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("20ec4eb0-71a6-4f00-9e24-28cfa5c1008e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9cd712f0-cdaa-4ad7-b7e0-278b68c5ccb0"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("babe40c2-6b18-465b-be89-00994a44d494"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d6d2aeb7-b798-446a-947d-2a4e3926b2a1"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("01f95049-9e3d-481c-a94c-dc500e417e7a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1f04fa64-3152-48c7-8fab-8450e6664b2c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6dadbd5e-7271-42d8-bba5-2144c73574cc"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c49db540-9936-475e-b537-c962b207ee8b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e262bd07-fdd5-43ab-ac21-2f8fbd7961a2"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("241eafaf-9bdd-41a3-b6f6-aad88ad9bed5"), null, null, null, null, "Fantasy" },
                    { new Guid("4921485f-b512-45b0-9458-9c9c2ce6b0f3"), null, null, null, null, "Science Fiction" },
                    { new Guid("89f71e04-6cc9-42e0-ba58-92376f46bd89"), null, null, null, null, "Fiction" },
                    { new Guid("aaac17c8-1c2f-4c0d-b018-4615204b6c6e"), null, null, null, null, "Non-Fiction" },
                    { new Guid("ce0e8bda-5e8a-422b-aacd-164b70cffcec"), null, null, null, null, "Mystery" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Email", "ModifiedAt", "ModifiedBy", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { new Guid("1623ec3f-b2c2-449b-b507-40d3e2dae52a"), null, null, "user4@example.com", null, null, "user4", "hashedPassword", 0 },
                    { new Guid("19e3996d-466f-45ca-980f-5483f5e4429b"), null, null, "user3@example.com", null, null, "user3", "hashedPassword", 0 },
                    { new Guid("774c4f47-4bb7-4245-8578-fc5ba755a7c9"), null, null, "admin@example.com", null, null, "admin", "hashedPassword", 1 },
                    { new Guid("95d7bd4f-bfa2-47dc-90d4-a40e71e62d89"), null, null, "user2@example.com", null, null, "user2", "hashedPassword", 0 },
                    { new Guid("b5bc1522-2b85-4d42-b22a-d4e4f1cbff30"), null, null, "user1@example.com", null, null, "user1", "hashedPassword", 0 }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CategoryId", "CreatedAt", "CreatedBy", "Description", "IsAvailable", "ModifiedAt", "ModifiedBy", "Title" },
                values: new object[,]
                {
                    { new Guid("24b0146e-300e-48bf-8137-4434e8ba83ce"), "Orson Scott Card", new Guid("4921485f-b512-45b0-9458-9c9c2ce6b0f3"), null, null, null, true, null, null, "Ender's Game" },
                    { new Guid("6096b564-b777-4c1e-ba05-dbfe8343e337"), "Agatha Christie", new Guid("ce0e8bda-5e8a-422b-aacd-164b70cffcec"), null, null, null, true, null, null, "And Then There Were None" },
                    { new Guid("8f8ae81f-c743-4d56-a349-aea155c5106f"), "Patrick Rothfuss", new Guid("241eafaf-9bdd-41a3-b6f6-aad88ad9bed5"), null, null, null, true, null, null, "The Name of the Wind" },
                    { new Guid("e5c7d513-fee0-43d7-925f-24ede7ed4519"), "J. R. R. Tolkien", new Guid("89f71e04-6cc9-42e0-ba58-92376f46bd89"), null, null, null, true, null, null, "The Lord of the Rings" },
                    { new Guid("fbb422c6-0da8-4848-9c27-8048f5e8ad82"), "Stephen Hawking", new Guid("aaac17c8-1c2f-4c0d-b018-4615204b6c6e"), null, null, null, true, null, null, "A Brief History of Time" }
                });
        }
    }
}
