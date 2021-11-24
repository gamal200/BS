using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BS.Infrastructure.Migrations
{
    public partial class editFields_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "Gate",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Gate",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsUpdated",
                table: "Gate",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Gate",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "ExitGates",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ExitGates",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsUpdated",
                table: "ExitGates",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "ExitGates",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "Employee",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Employee",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsUpdated",
                table: "Employee",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Employee",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "Car",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Car",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsUpdated",
                table: "Car",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Car",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "AccessCardCredit",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AccessCardCredit",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsUpdated",
                table: "AccessCardCredit",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "AccessCardCredit",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "AccessCard",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AccessCard",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsUpdated",
                table: "AccessCard",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "AccessCard",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "Gate");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Gate");

            migrationBuilder.DropColumn(
                name: "IsUpdated",
                table: "Gate");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Gate");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "ExitGates");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ExitGates");

            migrationBuilder.DropColumn(
                name: "IsUpdated",
                table: "ExitGates");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "ExitGates");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "IsUpdated",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "IsUpdated",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "AccessCardCredit");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AccessCardCredit");

            migrationBuilder.DropColumn(
                name: "IsUpdated",
                table: "AccessCardCredit");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "AccessCardCredit");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "AccessCard");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AccessCard");

            migrationBuilder.DropColumn(
                name: "IsUpdated",
                table: "AccessCard");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "AccessCard");
        }
    }
}
