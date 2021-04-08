using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EE579.Domain.Migrations
{
    public partial class RuleInputOutputTenants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TenantUser_Tenants_TenantId",
                table: "TenantUser");

            migrationBuilder.DropForeignKey(
                name: "FK_TenantUser_Users_UserId",
                table: "TenantUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TenantUser",
                table: "TenantUser");

            migrationBuilder.RenameTable(
                name: "TenantUser",
                newName: "TenantUsers");

            migrationBuilder.RenameIndex(
                name: "IX_TenantUser_UserId",
                table: "TenantUsers",
                newName: "IX_TenantUsers_UserId");

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "RuleOutputs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "RuleInputs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TenantUsers",
                table: "TenantUsers",
                columns: new[] { "TenantId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_RuleOutputs_TenantId",
                table: "RuleOutputs",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_RuleInputs_TenantId",
                table: "RuleInputs",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_RuleInputs_Tenants_TenantId",
                table: "RuleInputs",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RuleOutputs_Tenants_TenantId",
                table: "RuleOutputs",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TenantUsers_Tenants_TenantId",
                table: "TenantUsers",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TenantUsers_Users_UserId",
                table: "TenantUsers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RuleInputs_Tenants_TenantId",
                table: "RuleInputs");

            migrationBuilder.DropForeignKey(
                name: "FK_RuleOutputs_Tenants_TenantId",
                table: "RuleOutputs");

            migrationBuilder.DropForeignKey(
                name: "FK_TenantUsers_Tenants_TenantId",
                table: "TenantUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_TenantUsers_Users_UserId",
                table: "TenantUsers");

            migrationBuilder.DropIndex(
                name: "IX_RuleOutputs_TenantId",
                table: "RuleOutputs");

            migrationBuilder.DropIndex(
                name: "IX_RuleInputs_TenantId",
                table: "RuleInputs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TenantUsers",
                table: "TenantUsers");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "RuleOutputs");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "RuleInputs");

            migrationBuilder.RenameTable(
                name: "TenantUsers",
                newName: "TenantUser");

            migrationBuilder.RenameIndex(
                name: "IX_TenantUsers_UserId",
                table: "TenantUser",
                newName: "IX_TenantUser_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TenantUser",
                table: "TenantUser",
                columns: new[] { "TenantId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TenantUser_Tenants_TenantId",
                table: "TenantUser",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TenantUser_Users_UserId",
                table: "TenantUser",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
