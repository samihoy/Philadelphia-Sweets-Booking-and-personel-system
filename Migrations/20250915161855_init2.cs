using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Philadelphia_Sweets_booking_System__Resturant_.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Menues",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateOnly(2025, 9, 15));

            migrationBuilder.UpdateData(
                table: "Menues",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateOnly(2025, 9, 15));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Menues",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateOnly(2025, 9, 12));

            migrationBuilder.UpdateData(
                table: "Menues",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateOnly(2025, 9, 12));
        }
    }
}
