using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Settrix.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Fixing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CompanyId", "CreatedAt", "CreatedBy", "Email", "IsActive", "Name", "Password", "Role", "SecurityId", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1L, 1L, new DateTime(2025, 4, 30, 1, 6, 33, 737, DateTimeKind.Utc).AddTicks(7933), 1L, "", true, "Bill Gatos", "", 0, new Guid("aaa9640a-2413-4211-b1ea-516f9f95bef1"), null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L);
        }
    }
}
