using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MODEL.Migrations
{
    public partial class seedContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ce40a68-bec5-4804-b969-d889dc493165");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c840e5b4-0b01-4ee1-8de2-cac8a587f2c7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "50e4ae77-1cc2-451d-8a81-3ab7d747fc90", "2", "USER", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d0dd05a4-d25d-489d-8195-2e876d1f31f8", "1", "ADMIN", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AddedToLib", "AppUserId", "Author", "Description", "ISBN", "NoPage", "Publisher", "PublisherDate", "Title", "ViewBook" },
                values: new object[] { 1, new DateTime(2023, 4, 30, 13, 6, 12, 230, DateTimeKind.Local).AddTicks(3635), "74202d20-19ca-42b1-b835-d20b905e9861", "Paulo Coelho", "The story of Santiago, an Andalusian shepherd boy...", "978-0062315007", 208, "HarperOne", new DateTime(1988, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Alchemist", 0 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AddedToLib", "AppUserId", "Author", "Description", "ISBN", "NoPage", "Publisher", "PublisherDate", "Title", "ViewBook" },
                values: new object[] { 2, new DateTime(2023, 4, 30, 13, 6, 12, 230, DateTimeKind.Local).AddTicks(3657), "74202d20-19ca-42b1-b835-d20b905e9861", "Harper Lee", "The story of a young girl and her lawyer father...", "978-0446310789", 336, "Grand Central Publishing", new DateTime(1960, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "To Kill a Mockingbird", 0 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AddedToLib", "AppUserId", "Author", "Description", "ISBN", "NoPage", "Publisher", "PublisherDate", "Title", "ViewBook" },
                values: new object[] { 3, new DateTime(2023, 4, 30, 13, 6, 12, 230, DateTimeKind.Local).AddTicks(3660), "74202d20-19ca-42b1-b835-d20b905e9861", "George Orwell", "A dystopian novel set in a totalitarian society...", "978-0451524935", 328, "Signet Classics", new DateTime(1949, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "1984", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50e4ae77-1cc2-451d-8a81-3ab7d747fc90");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0dd05a4-d25d-489d-8195-2e876d1f31f8");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7ce40a68-bec5-4804-b969-d889dc493165", "2", "USER", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c840e5b4-0b01-4ee1-8de2-cac8a587f2c7", "1", "ADMIN", "ADMIN" });
        }
    }
}
