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
                    StaffNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SortCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AccountNumber = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    AccountName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RollNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Companies_CompanyDbId",
                        column: x => x.CompanyDbId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Conway" },
                    { 2, "Countryside" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompanyDbId",
                table: "Employees",
                column: "CompanyDbId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
