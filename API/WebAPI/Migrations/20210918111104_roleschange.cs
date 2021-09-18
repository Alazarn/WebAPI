using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class roleschange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0aaf63d-3160-49f2-90c8-2173dfdbc59d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3b00481-1d05-4e19-879f-7b1f124df5cf");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ef94e332-67ae-4ad4-abe3-f7584cc06ead", "b7f7e00d-0bf7-49d1-993e-fd38d4d8641b", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e397dbb4-7450-484d-a780-53218c2b5773", "27a87db4-641f-4dd9-b8fb-cdca7e51dad1", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e397dbb4-7450-484d-a780-53218c2b5773");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef94e332-67ae-4ad4-abe3-f7584cc06ead");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d0aaf63d-3160-49f2-90c8-2173dfdbc59d", "ea1324ea-88ed-4816-9713-9ce8448a4a6d", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f3b00481-1d05-4e19-879f-7b1f124df5cf", "7ab99c65-5d15-42ff-b28f-913c376b242f", "Administrator", "ADMINISTRATOR" });
        }
    }
}
