using Microsoft.EntityFrameworkCore.Migrations;

namespace EE579.Domain.Migrations
{
    public partial class AddWebhookOutput : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ForwardMessage",
                table: "RuleOutputs",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "RuleOutputs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForwardMessage",
                table: "RuleOutputs");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "RuleOutputs");
        }
    }
}
