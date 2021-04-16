using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EE579.Domain.Migrations
{
    public partial class SupportingDeviceGroupRules : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RuleInputs_Devices_DeviceId",
                table: "RuleInputs");

            migrationBuilder.DropForeignKey(
                name: "FK_RuleOutputs_Devices_DeviceId",
                table: "RuleOutputs");

            migrationBuilder.AlterColumn<string>(
                name: "DeviceId",
                table: "RuleOutputs",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<Guid>(
                name: "DeviceGroupId",
                table: "RuleOutputs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeviceId",
                table: "RuleInputs",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<Guid>(
                name: "DeviceGroupId",
                table: "RuleInputs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RuleOutputs_DeviceGroupId",
                table: "RuleOutputs",
                column: "DeviceGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_RuleInputs_DeviceGroupId",
                table: "RuleInputs",
                column: "DeviceGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_RuleInputs_DeviceGroups_DeviceGroupId",
                table: "RuleInputs",
                column: "DeviceGroupId",
                principalTable: "DeviceGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RuleInputs_Devices_DeviceId",
                table: "RuleInputs",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RuleOutputs_DeviceGroups_DeviceGroupId",
                table: "RuleOutputs",
                column: "DeviceGroupId",
                principalTable: "DeviceGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RuleOutputs_Devices_DeviceId",
                table: "RuleOutputs",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RuleInputs_DeviceGroups_DeviceGroupId",
                table: "RuleInputs");

            migrationBuilder.DropForeignKey(
                name: "FK_RuleInputs_Devices_DeviceId",
                table: "RuleInputs");

            migrationBuilder.DropForeignKey(
                name: "FK_RuleOutputs_DeviceGroups_DeviceGroupId",
                table: "RuleOutputs");

            migrationBuilder.DropForeignKey(
                name: "FK_RuleOutputs_Devices_DeviceId",
                table: "RuleOutputs");

            migrationBuilder.DropIndex(
                name: "IX_RuleOutputs_DeviceGroupId",
                table: "RuleOutputs");

            migrationBuilder.DropIndex(
                name: "IX_RuleInputs_DeviceGroupId",
                table: "RuleInputs");

            migrationBuilder.DropColumn(
                name: "DeviceGroupId",
                table: "RuleOutputs");

            migrationBuilder.DropColumn(
                name: "DeviceGroupId",
                table: "RuleInputs");

            migrationBuilder.AlterColumn<string>(
                name: "DeviceId",
                table: "RuleOutputs",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeviceId",
                table: "RuleInputs",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RuleInputs_Devices_DeviceId",
                table: "RuleInputs",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RuleOutputs_Devices_DeviceId",
                table: "RuleOutputs",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
