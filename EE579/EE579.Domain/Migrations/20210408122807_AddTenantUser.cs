using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EE579.Domain.Migrations
{
    public partial class AddTenantUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_Users_OwnerId",
                table: "Tenants");

            migrationBuilder.DropForeignKey(
                name: "FK_TenantUser_Tenants_TenantsId",
                table: "TenantUser");

            migrationBuilder.DropForeignKey(
                name: "FK_TenantUser_Users_UsersId",
                table: "TenantUser");

            migrationBuilder.DropIndex(
                name: "IX_Tenants_OwnerId",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Tenants");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "TenantUser",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "TenantsId",
                table: "TenantUser",
                newName: "TenantId");

            migrationBuilder.RenameIndex(
                name: "IX_TenantUser_UsersId",
                table: "TenantUser",
                newName: "IX_TenantUser_UserId");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "TenantUser",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TenantUser_Tenants_TenantId",
                table: "TenantUser");

            migrationBuilder.DropForeignKey(
                name: "FK_TenantUser_Users_UserId",
                table: "TenantUser");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "TenantUser");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "TenantUser",
                newName: "UsersId");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "TenantUser",
                newName: "TenantsId");

            migrationBuilder.RenameIndex(
                name: "IX_TenantUser_UserId",
                table: "TenantUser",
                newName: "IX_TenantUser_UsersId");

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "Tenants",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_OwnerId",
                table: "Tenants",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_Users_OwnerId",
                table: "Tenants",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TenantUser_Tenants_TenantsId",
                table: "TenantUser",
                column: "TenantsId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TenantUser_Users_UsersId",
                table: "TenantUser",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
