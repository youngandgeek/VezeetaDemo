using Microsoft.EntityFrameworkCore.Migrations;

namespace VezeetaDemo.Migrations
{
    public partial class sign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "AspNetUsers",
                newName: "ConfirmPassword");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "744085cc-76e3-4b96-9541-15944dce6b6f", "1", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "20804fb4-53bc-46b8-9b9a-45de8a6c88e1", "2", "Patient", "Patient" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "36304e67-53e1-4fce-9409-90875affcfa4", "3", "Doctor", "Doctor" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20804fb4-53bc-46b8-9b9a-45de8a6c88e1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36304e67-53e1-4fce-9409-90875affcfa4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "744085cc-76e3-4b96-9541-15944dce6b6f");

            migrationBuilder.RenameColumn(
                name: "ConfirmPassword",
                table: "AspNetUsers",
                newName: "Image");

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
    }
}
