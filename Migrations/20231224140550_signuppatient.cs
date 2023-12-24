using Microsoft.EntityFrameworkCore.Migrations;

namespace VezeetaDemo.Migrations
{
    public partial class signuppatient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "140ffaa0-b583-4713-bf25-025c13dc8c11", "1", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "04afa8a0-39e4-43b2-8c9c-6ca97ae2fb6d", "2", "Patient", "Patient" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1611f7a3-36ec-455e-b6f4-5d127b05d960", "3", "Doctor", "Doctor" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04afa8a0-39e4-43b2-8c9c-6ca97ae2fb6d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "140ffaa0-b583-4713-bf25-025c13dc8c11");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1611f7a3-36ec-455e-b6f4-5d127b05d960");
        }
    }
}
