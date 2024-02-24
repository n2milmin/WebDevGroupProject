using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebDevGroupProject.Migrations
{
    /// <inheritdoc />
    public partial class Flights : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Availability",
                table: "Car_Rentals",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Car_Rentals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Model",
                table: "Car_Rentals");

            migrationBuilder.AlterColumn<string>(
                name: "Availability",
                table: "Car_Rentals",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
