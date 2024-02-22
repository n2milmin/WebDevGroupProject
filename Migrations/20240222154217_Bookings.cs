using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebDevGroupProject.Migrations
{
    /// <inheritdoc />
    public partial class Bookings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FlightId",
                table: "Bookings",
                newName: "ServiceId");

            migrationBuilder.AddColumn<string>(
                name: "ServiceType",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceType",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "Bookings",
                newName: "FlightId");
        }
    }
}
