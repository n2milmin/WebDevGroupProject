using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebDevGroupProject.Migrations
{
    /// <inheritdoc />
    public partial class Booking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Booking",
                table: "Booking");

            migrationBuilder.RenameTable(
                name: "Booking",
                newName: "Bookings");

            migrationBuilder.RenameColumn(
                name: "Till",
                table: "Bookings",
                newName: "BookingStart");

            migrationBuilder.RenameColumn(
                name: "From",
                table: "Bookings",
                newName: "BookingEnd");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Bookings");

            migrationBuilder.RenameTable(
                name: "Bookings",
                newName: "Booking");

            migrationBuilder.RenameColumn(
                name: "BookingStart",
                table: "Booking",
                newName: "Till");

            migrationBuilder.RenameColumn(
                name: "BookingEnd",
                table: "Booking",
                newName: "From");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Booking",
                table: "Booking",
                column: "Id");
        }
    }
}
