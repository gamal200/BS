using Microsoft.EntityFrameworkCore.Migrations;

namespace BS.Infrastructure.Migrations
{
    public partial class editFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CostType",
                table: "Gate");

            migrationBuilder.DropColumn(
                name: "CostValue",
                table: "Gate");

            migrationBuilder.DropColumn(
                name: "GateName",
                table: "Gate");

            migrationBuilder.AddColumn<string>(
                name: "CostType",
                table: "AccessCardCredit",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CostValue",
                table: "AccessCardCredit",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CostType",
                table: "AccessCardCredit");

            migrationBuilder.DropColumn(
                name: "CostValue",
                table: "AccessCardCredit");

            migrationBuilder.AddColumn<string>(
                name: "CostType",
                table: "Gate",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CostValue",
                table: "Gate",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "GateName",
                table: "Gate",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
