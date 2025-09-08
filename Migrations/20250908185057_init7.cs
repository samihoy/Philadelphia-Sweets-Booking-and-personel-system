using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Philadelphia_Sweets_booking_System__Resturant_.Migrations
{
    /// <inheritdoc />
    public partial class init7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bokkings_Customers_CustomerId",
                table: "Bokkings");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bokkings",
                table: "Bokkings");

            migrationBuilder.DropIndex(
                name: "IX_Bokkings_CustomerId",
                table: "Bokkings");

            migrationBuilder.DropColumn(
                name: "IsAvalible",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "BookedTime",
                table: "Bokkings");

            migrationBuilder.DropColumn(
                name: "ContactInformainPhone",
                table: "Bokkings");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Bokkings");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Bokkings");

            migrationBuilder.RenameTable(
                name: "Bokkings",
                newName: "Bookings");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Tables",
                newName: "TableNumber");

            migrationBuilder.RenameColumn(
                name: "capacity",
                table: "Bookings",
                newName: "DurationMinutes");

            migrationBuilder.RenameColumn(
                name: "TableId",
                table: "Bookings",
                newName: "BookedbyId");

            migrationBuilder.AlterColumn<string>(
                name: "ContactInformationMail",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ContactInformationPhone",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BookingTable",
                columns: table => new
                {
                    BookingsId = table.Column<int>(type: "int", nullable: false),
                    TablesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingTable", x => new { x.BookingsId, x.TablesId });
                    table.ForeignKey(
                        name: "FK_BookingTable_Bookings_BookingsId",
                        column: x => x.BookingsId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingTable_Tables_TablesId",
                        column: x => x.TablesId,
                        principalTable: "Tables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_BookedbyId",
                table: "Bookings",
                column: "BookedbyId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingTable_TablesId",
                table: "BookingTable",
                column: "TablesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Employees_BookedbyId",
                table: "Bookings",
                column: "BookedbyId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Employees_BookedbyId",
                table: "Bookings");

            migrationBuilder.DropTable(
                name: "BookingTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_BookedbyId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "ContactInformationPhone",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Bookings");

            migrationBuilder.RenameTable(
                name: "Bookings",
                newName: "Bokkings");

            migrationBuilder.RenameColumn(
                name: "TableNumber",
                table: "Tables",
                newName: "Number");

            migrationBuilder.RenameColumn(
                name: "DurationMinutes",
                table: "Bokkings",
                newName: "capacity");

            migrationBuilder.RenameColumn(
                name: "BookedbyId",
                table: "Bokkings",
                newName: "TableId");

            migrationBuilder.AddColumn<bool>(
                name: "IsAvalible",
                table: "Tables",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "ContactInformationMail",
                table: "Bokkings",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<TimeOnly>(
                name: "BookedTime",
                table: "Bokkings",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<int>(
                name: "ContactInformainPhone",
                table: "Bokkings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Bokkings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateOnly>(
                name: "Date",
                table: "Bokkings",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bokkings",
                table: "Bokkings",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    MadeBookingId = table.Column<int>(type: "int", nullable: false),
                    TableId = table.Column<int>(type: "int", nullable: false),
                    BookedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_Bokkings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bokkings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_Employees_MadeBookingId",
                        column: x => x.MadeBookingId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_Tables_TableId",
                        column: x => x.TableId,
                        principalTable: "Tables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsAvalible",
                value: true);

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsAvalible",
                value: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bokkings_CustomerId",
                table: "Bokkings",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_BookingId",
                table: "Booking",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_MadeBookingId",
                table: "Booking",
                column: "MadeBookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_TableId",
                table: "Booking",
                column: "TableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bokkings_Customers_CustomerId",
                table: "Bokkings",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
