using Microsoft.EntityFrameworkCore.Migrations;

namespace EE579.Domain.Migrations
{
    public partial class RefactorRuleInputOutputs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Params",
                table: "RuleOutputs");

            migrationBuilder.AddColumn<int>(
                name: "Colour",
                table: "RuleOutputs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Direction",
                table: "RuleOutputs",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "RuleOutputs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "RuleOutputs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LedBlinkOutput_Colour",
                table: "RuleOutputs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LedBlinkOutput_Period",
                table: "RuleOutputs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LedBlinkOutput_Peripheral",
                table: "RuleOutputs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LedBreatheOutput_Colour",
                table: "RuleOutputs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LedBreatheOutput_Period",
                table: "RuleOutputs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LedBreatheOutput_Peripheral",
                table: "RuleOutputs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LedCycleOutput_Period",
                table: "RuleOutputs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LedFadeOutput_Colour",
                table: "RuleOutputs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LedFadeOutput_Peripheral",
                table: "RuleOutputs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OffDuration",
                table: "RuleOutputs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OnDuration",
                table: "RuleOutputs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "RuleOutputs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Peripheral",
                table: "RuleOutputs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Value",
                table: "RuleOutputs",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GreaterThan",
                table: "RuleInputs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LessThan",
                table: "RuleInputs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PotentiometerInput_GreaterThan",
                table: "RuleInputs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PotentiometerInput_LessThan",
                table: "RuleInputs",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Colour",
                table: "RuleOutputs");

            migrationBuilder.DropColumn(
                name: "Direction",
                table: "RuleOutputs");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "RuleOutputs");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "RuleOutputs");

            migrationBuilder.DropColumn(
                name: "LedBlinkOutput_Colour",
                table: "RuleOutputs");

            migrationBuilder.DropColumn(
                name: "LedBlinkOutput_Period",
                table: "RuleOutputs");

            migrationBuilder.DropColumn(
                name: "LedBlinkOutput_Peripheral",
                table: "RuleOutputs");

            migrationBuilder.DropColumn(
                name: "LedBreatheOutput_Colour",
                table: "RuleOutputs");

            migrationBuilder.DropColumn(
                name: "LedBreatheOutput_Period",
                table: "RuleOutputs");

            migrationBuilder.DropColumn(
                name: "LedBreatheOutput_Peripheral",
                table: "RuleOutputs");

            migrationBuilder.DropColumn(
                name: "LedCycleOutput_Period",
                table: "RuleOutputs");

            migrationBuilder.DropColumn(
                name: "LedFadeOutput_Colour",
                table: "RuleOutputs");

            migrationBuilder.DropColumn(
                name: "LedFadeOutput_Peripheral",
                table: "RuleOutputs");

            migrationBuilder.DropColumn(
                name: "OffDuration",
                table: "RuleOutputs");

            migrationBuilder.DropColumn(
                name: "OnDuration",
                table: "RuleOutputs");

            migrationBuilder.DropColumn(
                name: "Period",
                table: "RuleOutputs");

            migrationBuilder.DropColumn(
                name: "Peripheral",
                table: "RuleOutputs");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "RuleOutputs");

            migrationBuilder.DropColumn(
                name: "GreaterThan",
                table: "RuleInputs");

            migrationBuilder.DropColumn(
                name: "LessThan",
                table: "RuleInputs");

            migrationBuilder.DropColumn(
                name: "PotentiometerInput_GreaterThan",
                table: "RuleInputs");

            migrationBuilder.DropColumn(
                name: "PotentiometerInput_LessThan",
                table: "RuleInputs");

            migrationBuilder.AddColumn<string>(
                name: "Params",
                table: "RuleOutputs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
