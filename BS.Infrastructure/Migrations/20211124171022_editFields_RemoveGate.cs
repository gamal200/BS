using Microsoft.EntityFrameworkCore.Migrations;

namespace BS.Infrastructure.Migrations
{
    public partial class editFields_RemoveGate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExitGates_Gate_GateId",
                table: "ExitGates");

            migrationBuilder.AlterColumn<int>(
                name: "GateId",
                table: "ExitGates",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "GateType",
                table: "ExitGates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ExitGates_Gate_GateId",
                table: "ExitGates",
                column: "GateId",
                principalTable: "Gate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExitGates_Gate_GateId",
                table: "ExitGates");

            migrationBuilder.DropColumn(
                name: "GateType",
                table: "ExitGates");

            migrationBuilder.AlterColumn<int>(
                name: "GateId",
                table: "ExitGates",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ExitGates_Gate_GateId",
                table: "ExitGates",
                column: "GateId",
                principalTable: "Gate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
