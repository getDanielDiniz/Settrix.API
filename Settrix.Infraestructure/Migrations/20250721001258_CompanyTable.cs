using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Settrix.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class CompanyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Config_Company_CompanyId",
                table: "Config");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Company_CompanyId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkFlowStep_Company_CompanyId",
                table: "WorkFlowStep");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Company",
                table: "Company");

            migrationBuilder.RenameTable(
                name: "Company",
                newName: "Companies");

            migrationBuilder.AddColumn<long>(
                name: "CompanyId2",
                table: "Users",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cnpj",
                table: "Companies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Companies",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "Companies",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Companies",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "Companies",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CompanyId", "CompanyId2", "CreatedAt", "SecurityId" },
                values: new object[] { 5L, null, new DateTime(2025, 7, 21, 0, 12, 57, 719, DateTimeKind.Utc).AddTicks(330), new Guid("fa025071-7408-4dd2-8568-37bd88ae89b8") });

            migrationBuilder.CreateIndex(
                name: "IX_Users_CompanyId2",
                table: "Users",
                column: "CompanyId2",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CreatedBy",
                table: "Companies",
                column: "CreatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Users_CreatedBy",
                table: "Companies",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Config_Companies_CompanyId",
                table: "Config",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Companies_CompanyId",
                table: "Users",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Companies_CompanyId2",
                table: "Users",
                column: "CompanyId2",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkFlowStep_Companies_CompanyId",
                table: "WorkFlowStep",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Users_CreatedBy",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Config_Companies_CompanyId",
                table: "Config");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Companies_CompanyId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Companies_CompanyId2",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkFlowStep_Companies_CompanyId",
                table: "WorkFlowStep");

            migrationBuilder.DropIndex(
                name: "IX_Users_CompanyId2",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_CreatedBy",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CompanyId2",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Cnpj",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Companies");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "Company");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Company",
                table: "Company",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CompanyId", "CreatedAt", "SecurityId" },
                values: new object[] { 1L, new DateTime(2025, 4, 30, 1, 6, 33, 737, DateTimeKind.Utc).AddTicks(7933), new Guid("aaa9640a-2413-4211-b1ea-516f9f95bef1") });

            migrationBuilder.AddForeignKey(
                name: "FK_Config_Company_CompanyId",
                table: "Config",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Company_CompanyId",
                table: "Users",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkFlowStep_Company_CompanyId",
                table: "WorkFlowStep",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
