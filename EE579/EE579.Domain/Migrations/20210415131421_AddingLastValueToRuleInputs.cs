using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EE579.Domain.Migrations
{
    public partial class AddingLastValueToRuleInputs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RuleInputs_Rules_RuleId",
                table: "RuleInputs");

            migrationBuilder.AlterColumn<Guid>(
                name: "RuleId",
                table: "RuleInputs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LastValue",
                table: "RuleInputs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PotentiometerInput_LastValue",
                table: "RuleInputs",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RuleInputs_Rules_RuleId",
                table: "RuleInputs",
                column: "RuleId",
                principalTable: "Rules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RuleInputs_Rules_RuleId",
                table: "RuleInputs");

            migrationBuilder.DropColumn(
                name: "LastValue",
                table: "RuleInputs");

            migrationBuilder.DropColumn(
                name: "PotentiometerInput_LastValue",
                table: "RuleInputs");

            migrationBuilder.AlterColumn<Guid>(
                name: "RuleId",
                table: "RuleInputs",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_RuleInputs_Rules_RuleId",
                table: "RuleInputs",
                column: "RuleId",
                principalTable: "Rules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
