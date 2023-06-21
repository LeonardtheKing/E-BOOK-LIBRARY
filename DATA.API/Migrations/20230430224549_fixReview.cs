using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MODEL.Migrations
{
    public partial class fixReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ca71b24-145a-484a-b685-15fb183aeed7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e570095b-f80b-473e-bf2c-2b459334f0ef");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7b3ba078-ccff-4d88-b60e-ab64884a7f21", "1", "ADMIN", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c8cd36b2-e431-4662-8c19-d0dfe4c691b9", "2", "USER", "USER" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "AddedToLib",
                value: new DateTime(2023, 4, 30, 23, 45, 48, 756, DateTimeKind.Local).AddTicks(7299));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "AddedToLib",
                value: new DateTime(2023, 4, 30, 23, 45, 48, 756, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "AddedToLib",
                value: new DateTime(2023, 4, 30, 23, 45, 48, 756, DateTimeKind.Local).AddTicks(7316));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 4, 30, 23, 45, 48, 756, DateTimeKind.Local).AddTicks(7332));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 4, 30, 23, 45, 48, 756, DateTimeKind.Local).AddTicks(7334));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 4, 30, 23, 45, 48, 756, DateTimeKind.Local).AddTicks(7335));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b3ba078-ccff-4d88-b60e-ab64884a7f21");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8cd36b2-e431-4662-8c19-d0dfe4c691b9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8ca71b24-145a-484a-b685-15fb183aeed7", "2", "USER", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e570095b-f80b-473e-bf2c-2b459334f0ef", "1", "ADMIN", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "AddedToLib",
                value: new DateTime(2023, 4, 30, 16, 19, 28, 47, DateTimeKind.Local).AddTicks(2669));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "AddedToLib",
                value: new DateTime(2023, 4, 30, 16, 19, 28, 47, DateTimeKind.Local).AddTicks(2691));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "AddedToLib",
                value: new DateTime(2023, 4, 30, 16, 19, 28, 47, DateTimeKind.Local).AddTicks(2695));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 4, 30, 16, 19, 28, 47, DateTimeKind.Local).AddTicks(2876));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 4, 30, 16, 19, 28, 47, DateTimeKind.Local).AddTicks(2881));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 4, 30, 16, 19, 28, 47, DateTimeKind.Local).AddTicks(2885));
        }
    }
}
