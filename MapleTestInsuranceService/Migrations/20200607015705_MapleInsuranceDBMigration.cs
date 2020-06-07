using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MapleTestInsuranceService.Migrations
{
    public partial class MapleInsuranceDBMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoveragePlans",
                columns: table => new
                {
                    PlanId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoveragePlanName = table.Column<string>(nullable: true),
                    EligibilityDateFrom = table.Column<DateTime>(nullable: true),
                    EligibilityDateTo = table.Column<DateTime>(nullable: true),
                    EligibilityCountry = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoveragePlans", x => x.PlanId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(nullable: true),
                    CustomerAddress = table.Column<string>(nullable: true),
                    CustomerGender = table.Column<string>(nullable: false),
                    CustomerCountry = table.Column<string>(nullable: true),
                    CustomerDateOfBirth = table.Column<DateTime>(nullable: true),
                    SaleDate = table.Column<DateTime>(nullable: true),
                    CoveragePlan = table.Column<string>(nullable: true),
                    NetPrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "RateCharts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoveragePlanName = table.Column<string>(nullable: true),
                    CustomerGender = table.Column<string>(nullable: false),
                    CustomerAgeFrom = table.Column<int>(nullable: false),
                    CustomerAgeTo = table.Column<int>(nullable: false),
                    NetPrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RateCharts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CoveragePlans",
                columns: new[] { "PlanId", "CoveragePlanName", "EligibilityCountry", "EligibilityDateFrom", "EligibilityDateTo" },
                values: new object[,]
                {
                    { 1L, "Gold", "USA", new DateTime(2009, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, "Platinum", "CAN", new DateTime(2005, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, "Silver", "OTHER", new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "RateCharts",
                columns: new[] { "Id", "CoveragePlanName", "CustomerAgeFrom", "CustomerAgeTo", "CustomerGender", "NetPrice" },
                values: new object[,]
                {
                    { 1L, "Gold", 18, 40, "M", 1000.0 },
                    { 2L, "Gold", 41, 100, "M", 2000.0 },
                    { 3L, "Gold", 18, 40, "F", 1200.0 },
                    { 4L, "Gold", 41, 100, "F", 2500.0 },
                    { 5L, "Silver", 18, 40, "M", 1500.0 },
                    { 6L, "Silver", 41, 100, "M", 2600.0 },
                    { 7L, "Silver", 18, 40, "F", 1900.0 },
                    { 8L, "Silver", 41, 100, "F", 2800.0 },
                    { 9L, "Platinum", 18, 40, "M", 1900.0 },
                    { 10L, "Platinum", 41, 100, "M", 2900.0 },
                    { 11L, "Platinum", 18, 40, "F", 2100.0 },
                    { 12L, "Platinum", 41, 100, "F", 3200.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoveragePlans");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "RateCharts");
        }
    }
}
