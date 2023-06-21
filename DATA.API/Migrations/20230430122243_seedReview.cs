using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MODEL.Migrations
{
    public partial class seedReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50e4ae77-1cc2-451d-8a81-3ab7d747fc90");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0dd05a4-d25d-489d-8195-2e876d1f31f8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "93a85c21-a7c1-4ee8-bec5-f7fe310a4c23", "2", "USER", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f3c08c9e-9e9c-400e-8611-914f6a9f4d5f", "1", "ADMIN", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "AddedToLib",
                value: new DateTime(2023, 4, 30, 13, 22, 43, 8, DateTimeKind.Local).AddTicks(6003));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "AddedToLib",
                value: new DateTime(2023, 4, 30, 13, 22, 43, 8, DateTimeKind.Local).AddTicks(6023));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "AddedToLib",
                value: new DateTime(2023, 4, 30, 13, 22, 43, 8, DateTimeKind.Local).AddTicks(6026));

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "AppUserId", "BookId", "Comment", "DateCreated", "Rating", "Title" },
                values: new object[] { 1, "74202d20-19ca-42b1-b835-d20b905e9861", 3, "The book was lengthy but I loved it", new DateTime(2023, 4, 30, 13, 22, 43, 8, DateTimeKind.Local).AddTicks(6059), 4, "Golden boy" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "AppUserId", "BookId", "Comment", "DateCreated", "Rating", "Title" },
                values: new object[] { 2, "74202d20-19ca-42b1-b835-d20b905e9861", 2, "The books were lengthy but I loved it", new DateTime(2023, 4, 30, 13, 22, 43, 8, DateTimeKind.Local).AddTicks(6062), 3, "Golden girl" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "AppUserId", "BookId", "Comment", "DateCreated", "Rating", "Title" },
                values: new object[] { 3, "74202d20-19ca-42b1-b835-d20b905e9861", 2, "The book was lengthy but I loved it", new DateTime(2023, 4, 30, 13, 22, 43, 8, DateTimeKind.Local).AddTicks(6064), 4, "Golden woman" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93a85c21-a7c1-4ee8-bec5-f7fe310a4c23");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3c08c9e-9e9c-400e-8611-914f6a9f4d5f");

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "50e4ae77-1cc2-451d-8a81-3ab7d747fc90", "2", "USER", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d0dd05a4-d25d-489d-8195-2e876d1f31f8", "1", "ADMIN", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "AddedToLib",
                value: new DateTime(2023, 4, 30, 13, 6, 12, 230, DateTimeKind.Local).AddTicks(3635));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "AddedToLib",
                value: new DateTime(2023, 4, 30, 13, 6, 12, 230, DateTimeKind.Local).AddTicks(3657));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "AddedToLib",
                value: new DateTime(2023, 4, 30, 13, 6, 12, 230, DateTimeKind.Local).AddTicks(3660));
        }
    }
}
