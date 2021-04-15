using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EE579.Domain.Migrations
{
    public partial class AddedDeviceWebId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Rules_RuleId",
                table: "Events");

            migrationBuilder.AlterColumn<Guid>(
                name: "RuleId",
                table: "Events",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "WebId",
                table: "Devices",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Rules_RuleId",
                table: "Events",
                column: "RuleId",
                principalTable: "Rules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Rules_RuleId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "WebId",
                table: "Devices");

            migrationBuilder.AlterColumn<Guid>(
                name: "RuleId",
                table: "Events",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Rules_RuleId",
                table: "Events",
                column: "RuleId",
                principalTable: "Rules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
