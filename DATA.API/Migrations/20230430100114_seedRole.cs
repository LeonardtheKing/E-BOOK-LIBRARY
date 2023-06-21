using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MODEL.Migrations
{
    public partial class seedRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7ce40a68-bec5-4804-b969-d889dc493165", "2", "USER", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c840e5b4-0b01-4ee1-8de2-cac8a587f2c7", "1", "ADMIN", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ce40a68-bec5-4804-b969-d889dc493165");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c840e5b4-0b01-4ee1-8de2-cac8a587f2c7");
        }
    }
}
