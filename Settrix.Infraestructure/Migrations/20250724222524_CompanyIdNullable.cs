using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Settrix.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class CompanyIdNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "CompanyId",
                table: "Users",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 24, 22, 25, 24, 323, DateTimeKind.Utc).AddTicks(4185));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CompanyId", "CreatedAt", "SecurityId" },
                values: new object[] { null, new DateTime(2025, 7, 24, 22, 25, 24, 318, DateTimeKind.Utc).AddTicks(1923), new Guid("b0768b17-fa61-4246-a36b-21e3b9e37a64") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "CompanyId",
                table: "Users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 24, 21, 31, 43, 616, DateTimeKind.Utc).AddTicks(6496));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CompanyId", "CreatedAt", "SecurityId" },
                values: new object[] { null, new DateTime(2025, 7, 24, 21, 31, 43, 611, DateTimeKind.Utc).AddTicks(6066), new Guid("320ef9b7-608c-4fb0-9c57-83bcb73694e8") });
        }
    }
}
