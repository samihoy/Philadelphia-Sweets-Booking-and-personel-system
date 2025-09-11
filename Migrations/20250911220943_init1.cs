using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Philadelphia_Sweets_booking_System__Resturant_.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberGuests = table.Column<int>(type: "int", nullable: false),
                    BookedUnderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactInformationPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactInformationMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DurationMinutes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ingredients = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPopular = table.Column<bool>(type: "bit", nullable: false),
                    pictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Video = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Lname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmergencyContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HourlySalery = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Theme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableNumber = table.Column<int>(type: "int", nullable: false),
                    Seats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shift",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkedHours = table.Column<TimeSpan>(type: "time", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shift", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shift_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DishMenu",
                columns: table => new
                {
                    DishesId = table.Column<int>(type: "int", nullable: false),
                    MenusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishMenu", x => new { x.DishesId, x.MenusId });
                    table.ForeignKey(
                        name: "FK_DishMenu_Dishes_DishesId",
                        column: x => x.DishesId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishMenu_Menues_MenusId",
                        column: x => x.MenusId,
                        principalTable: "Menues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "BookedUnderName", "ContactInformationMail", "ContactInformationPhone", "DurationMinutes", "NumberGuests", "StartTime" },
                values: new object[,]
                {
                    { 1, "Max Lundberg", null, "0707254421", 120, 10, new DateTime(2025, 9, 5, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Felix Lundberg", null, "05627321", 120, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Description", "Ingredients", "IsPopular", "Name", "Price", "Video", "pictureUrl" },
                values: new object[,]
                {
                    { 1, "Generic dish 1", "[\"Your soul\"]", false, "I made this....", 120, null, null },
                    { 2, "Generic dish 2", "[\"the soul of your enemy?\"]", false, "I made this.....", 400, null, null }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "EmergencyContact", "Fname", "HourlySalery", "Lname", "PasswordHash", "PhoneNumber", "Role" },
                values: new object[] { 1, "mail@role.com", null, "max", null, "lundberg", "$2a$11$IEs5ywZPW2iRRKW5/GV.we3k2PpmGXOVgbXcZOQ3ufUbk4ZmvJHTm", null, "admin" });

            migrationBuilder.InsertData(
                table: "Menues",
                columns: new[] { "Id", "CreatedAt", "Theme" },
                values: new object[,]
                {
                    { 1, new DateOnly(2025, 9, 12), "vegetarian" },
                    { 2, new DateOnly(2025, 9, 12), "meditteranian" }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "Seats", "TableNumber" },
                values: new object[,]
                {
                    { 1, 6, 1 },
                    { 2, 10, 2 }
                });

            migrationBuilder.InsertData(
                table: "BookingTable",
                columns: new[] { "BookingsId", "TablesId" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_BookingTable_TablesId",
                table: "BookingTable",
                column: "TablesId");

            migrationBuilder.CreateIndex(
                name: "IX_DishMenu_MenusId",
                table: "DishMenu",
                column: "MenusId");

            migrationBuilder.CreateIndex(
                name: "IX_Shift_EmployeeId",
                table: "Shift",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingTable");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "DishMenu");

            migrationBuilder.DropTable(
                name: "Shift");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Tables");

            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "Menues");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
