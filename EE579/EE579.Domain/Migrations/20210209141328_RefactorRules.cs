using Microsoft.EntityFrameworkCore.Migrations;

namespace EE579.Domain.Migrations
{
    public partial class RefactorRules : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Params",
                table: "RuleInputs");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "RuleInputs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "RuleInputs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Peripheral",
                table: "RuleInputs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Value",
                table: "RuleInputs",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "RuleInputs");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "RuleInputs");

            migrationBuilder.DropColumn(
                name: "Peripheral",
                table: "RuleInputs");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "RuleInputs");

            migrationBuilder.AddColumn<string>(
                name: "Params",
                table: "RuleInputs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
