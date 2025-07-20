using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Settrix.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class FixingCircularDependency : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Users_CreatedBy",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Users_UpdatedBy",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Config_Companies_CompanyId",
                table: "Config");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Companies_CompanyId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkFlowStep_Companies_CompanyId",
                table: "WorkFlowStep");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_CreatedBy",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_UpdatedBy",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CreatedBy",
                table: "Companies",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_UpdatedBy",
                table: "Companies",
                column: "UpdatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Users_CreatedBy",
                table: "Companies",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Users_UpdatedBy",
                table: "Companies",
                column: "UpdatedBy",
                principalTable: "Users",
                principalColumn: "Id");

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
                name: "FK_WorkFlowStep_Companies_CompanyId",
                table: "WorkFlowStep",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
