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
            migrationBuilder.DropColumn(
                name: "Prices",
                table: "Flights");

            migrationBuilder.RenameColumn(
                name: "Departure",
                table: "Flights",
                newName: "DepartureTime");

            migrationBuilder.RenameColumn(
                name: "Arrival",
                table: "Flights",
                newName: "ArrivalTime");

            migrationBuilder.RenameColumn(
                name: "Airlines",
                table: "Flights",
                newName: "Airline");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Flights",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Flights");

            migrationBuilder.RenameColumn(
                name: "DepartureTime",
                table: "Flights",
                newName: "Departure");

            migrationBuilder.RenameColumn(
                name: "ArrivalTime",
                table: "Flights",
                newName: "Arrival");

            migrationBuilder.RenameColumn(
                name: "Airline",
                table: "Flights",
                newName: "Airlines");

            migrationBuilder.AddColumn<int>(
                name: "Prices",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
