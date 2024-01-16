using Microsoft.EntityFrameworkCore.Migrations;

namespace VezeetaDemo.Migrations
{
    public partial class phoneAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "51cd1593-2bd7-42b1-94ff-80afedb28678" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "51cd1593-2bd7-42b1-94ff-80afedb28678");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "b5d420b7-84d6-41d0-93a2-9ff1c688fdfe");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "dacbfb16-7552-4724-8a48-415b73ca1ee7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "cd8daeb6-178d-4c88-a3d5-23bb73f3aa5f");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "Price", "SecurityStamp", "Specialization", "TwoFactorEnabled", "UserName" },
                values: new object[] { "550d1ce7-bd51-4cd4-beee-98f2c4fd39f2", 0, "b0d2ee09-7789-4ccc-b936-672f7eebd118", null, "Admin@vezeeta.com", false, "admin", 0, "vezeeta", false, null, null, null, "AQAAAAEAACcQAAAAEK/lMNw+2wlN/FfOjRaAeNwgZWZfj4ZVCKnZugh3XU2cUU/d03uBrD6UO/C3kHW4Jg==", "1234567890", null, false, null, "28290007-f41b-42a6-adf4-ecb4e835dde0", null, false, "Admin@vezeeta.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "550d1ce7-bd51-4cd4-beee-98f2c4fd39f2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "550d1ce7-bd51-4cd4-beee-98f2c4fd39f2" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "550d1ce7-bd51-4cd4-beee-98f2c4fd39f2");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "c2df0b76-67b8-4ec0-8989-99a2933e2690");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "decf2667-b3fa-4968-b81b-7a439ff37cd1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "21fe2d02-b811-4726-b912-2f85efabc5dc");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Price", "SecurityStamp", "Specialization", "TwoFactorEnabled", "UserName" },
                values: new object[] { "51cd1593-2bd7-42b1-94ff-80afedb28678", 0, "f8bae63b-b9b3-4251-a4c8-f17dab7fbcd0", null, "Admin@vezeeta.com", false, "admin", 0, "vezeeta", false, null, null, null, "AQAAAAEAACcQAAAAEFw3YmasUZQqxv/SIKkeU/JUAClp9EbCIR1ypnDtSULfNnEcMzmprEph6VAPJHYvAg==", null, false, null, "bc37f39e-91f8-4e95-8895-ad3acafb0790", null, false, "Admin@vezeeta.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "51cd1593-2bd7-42b1-94ff-80afedb28678" });
        }
    }
}
