using Microsoft.EntityFrameworkCore.Migrations;

namespace EE579.Domain.Migrations
{
    public partial class AddGenericEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Device_Tenants_TenantId",
                table: "Device");

            migrationBuilder.DropForeignKey(
                name: "FK_DeviceDeviceGroup_Device_DevicesId",
                table: "DeviceDeviceGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_RuleInputs_Device_DeviceId",
                table: "RuleInputs");

            migrationBuilder.DropForeignKey(
                name: "FK_RuleOutputs_Device_DeviceId",
                table: "RuleOutputs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Device",
                table: "Device");

            migrationBuilder.RenameTable(
                name: "Device",
                newName: "Devices");

            migrationBuilder.RenameIndex(
                name: "IX_Device_TenantId",
                table: "Devices",
                newName: "IX_Devices_TenantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Devices",
                table: "Devices",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceDeviceGroup_Devices_DevicesId",
                table: "DeviceDeviceGroup",
                column: "DevicesId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Tenants_TenantId",
                table: "Devices",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeviceDeviceGroup_Devices_DevicesId",
                table: "DeviceDeviceGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Tenants_TenantId",
                table: "Devices");

            migrationBuilder.DropForeignKey(
                name: "FK_RuleInputs_Devices_DeviceId",
                table: "RuleInputs");

            migrationBuilder.DropForeignKey(
                name: "FK_RuleOutputs_Devices_DeviceId",
                table: "RuleOutputs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Devices",
                table: "Devices");

            migrationBuilder.RenameTable(
                name: "Devices",
                newName: "Device");

            migrationBuilder.RenameIndex(
                name: "IX_Devices_TenantId",
                table: "Device",
                newName: "IX_Device_TenantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Device",
                table: "Device",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Device_Tenants_TenantId",
                table: "Device",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceDeviceGroup_Device_DevicesId",
                table: "DeviceDeviceGroup",
                column: "DevicesId",
                principalTable: "Device",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RuleInputs_Device_DeviceId",
                table: "RuleInputs",
                column: "DeviceId",
                principalTable: "Device",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RuleOutputs_Device_DeviceId",
                table: "RuleOutputs",
                column: "DeviceId",
                principalTable: "Device",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
