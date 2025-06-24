using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Netronix.API.Migrations.NetronixAuthDb
{
    /// <inheritdoc />
    public partial class AuthDBwithCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d8c83c62-fa3a-46a5-b9da-905c3d7d50e3", "d8c83c62-fa3a-46a5-b9da-905c3d7d50e3", "Customer", "CUSTOMER" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8c83c62-fa3a-46a5-b9da-905c3d7d50e3");
        }
    }
}
