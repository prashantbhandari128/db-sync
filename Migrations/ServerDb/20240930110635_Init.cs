using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DatabaseSync.Migrations.ServerDb
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationID);
                    table.ForeignKey(
                        name: "FK_Locations_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "john@example.com", "John Doe", "1234567890" },
                    { 2, "jane@example.com", "Jane Smith", "0987654321" },
                    { 3, "alice@example.com", "Alice Johnson", "1122334455" },
                    { 4, "bob@example.com", "Bob Brown", "2233445566" },
                    { 5, "charlie@example.com", "Charlie White", "3344556677" },
                    { 6, "david@example.com", "David Green", "4455667788" },
                    { 7, "eve@example.com", "Eve Blue", "5566778899" },
                    { 8, "frank@example.com", "Frank Black", "6677889900" },
                    { 9, "grace@example.com", "Grace Silver", "7788990011" },
                    { 10, "hank@example.com", "Hank Gold", "8899001122" },
                    { 11, "ivy@example.com", "Ivy Red", "9900112233" },
                    { 12, "jake@example.com", "Jake Violet", "1010101010" },
                    { 13, "liam@example.com", "Liam Orange", "1111111111" },
                    { 14, "mia@example.com", "Mia Cyan", "1212121212" },
                    { 15, "noah@example.com", "Noah Brown", "1313131313" },
                    { 16, "olivia@example.com", "Olivia Pink", "1414141414" },
                    { 17, "peter@example.com", "Peter Gray", "1515151515" },
                    { 18, "quinn@example.com", "Quinn Magenta", "1616161616" },
                    { 19, "ryan@example.com", "Ryan Lime", "1717171717" },
                    { 20, "sophia@example.com", "Sophia Peach", "1818181818" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationID", "Address", "CustomerID" },
                values: new object[,]
                {
                    { 1, "Address 1 - 1", 1 },
                    { 2, "Address 1 - 2", 1 },
                    { 3, "Address 1 - 3", 1 },
                    { 4, "Address 2 - 1", 2 },
                    { 5, "Address 2 - 2", 2 },
                    { 6, "Address 2 - 3", 2 },
                    { 7, "Address 3 - 1", 3 },
                    { 8, "Address 3 - 2", 3 },
                    { 9, "Address 3 - 3", 3 },
                    { 10, "Address 4 - 1", 4 },
                    { 11, "Address 4 - 2", 4 },
                    { 12, "Address 4 - 3", 4 },
                    { 13, "Address 5 - 1", 5 },
                    { 14, "Address 5 - 2", 5 },
                    { 15, "Address 5 - 3", 5 },
                    { 16, "Address 6 - 1", 6 },
                    { 17, "Address 6 - 2", 6 },
                    { 18, "Address 6 - 3", 6 },
                    { 19, "Address 7 - 1", 7 },
                    { 20, "Address 7 - 2", 7 },
                    { 21, "Address 7 - 3", 7 },
                    { 22, "Address 8 - 1", 8 },
                    { 23, "Address 8 - 2", 8 },
                    { 24, "Address 8 - 3", 8 },
                    { 25, "Address 9 - 1", 9 },
                    { 26, "Address 9 - 2", 9 },
                    { 27, "Address 9 - 3", 9 },
                    { 28, "Address 10 - 1", 10 },
                    { 29, "Address 10 - 2", 10 },
                    { 30, "Address 10 - 3", 10 },
                    { 31, "Address 11 - 1", 11 },
                    { 32, "Address 11 - 2", 11 },
                    { 33, "Address 11 - 3", 11 },
                    { 34, "Address 12 - 1", 12 },
                    { 35, "Address 12 - 2", 12 },
                    { 36, "Address 12 - 3", 12 },
                    { 37, "Address 13 - 1", 13 },
                    { 38, "Address 13 - 2", 13 },
                    { 39, "Address 13 - 3", 13 },
                    { 40, "Address 14 - 1", 14 },
                    { 41, "Address 14 - 2", 14 },
                    { 42, "Address 14 - 3", 14 },
                    { 43, "Address 15 - 1", 15 },
                    { 44, "Address 15 - 2", 15 },
                    { 45, "Address 15 - 3", 15 },
                    { 46, "Address 16 - 1", 16 },
                    { 47, "Address 16 - 2", 16 },
                    { 48, "Address 16 - 3", 16 },
                    { 49, "Address 17 - 1", 17 },
                    { 50, "Address 17 - 2", 17 },
                    { 51, "Address 17 - 3", 17 },
                    { 52, "Address 18 - 1", 18 },
                    { 53, "Address 18 - 2", 18 },
                    { 54, "Address 18 - 3", 18 },
                    { 55, "Address 19 - 1", 19 },
                    { 56, "Address 19 - 2", 19 },
                    { 57, "Address 19 - 3", 19 },
                    { 58, "Address 20 - 1", 20 },
                    { 59, "Address 20 - 2", 20 },
                    { 60, "Address 20 - 3", 20 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_CustomerID",
                table: "Locations",
                column: "CustomerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
