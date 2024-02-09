using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RentFraudDetector.Shared.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyDbId = table.Column<int>(type: "int", nullable: false),
                    StaffNumber = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FirstName = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Surname = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    SortCode = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    BranchName = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    AccountNumber = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    AccountName = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    RollNumber = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Key = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Vector = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Conway" },
                    { 2, "Countryside" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
