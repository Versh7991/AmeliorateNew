using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AmeliorateAegis.Migrations
{
    public partial class AddedRegionalEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Budget",
                columns: table => new
                {
                    BudgetID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BudgetDescr = table.Column<string>(maxLength: 250, nullable: false),
                    RegionalID = table.Column<int>(nullable: false),
                    BudgetAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    BalanceAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budget", x => x.BudgetID);
                });

            migrationBuilder.CreateTable(
                name: "Center",
                columns: table => new
                {
                    CenterID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CenterCode = table.Column<string>(maxLength: 50, nullable: true),
                    CenterName = table.Column<string>(nullable: true),
                    Addressline1 = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Addressline2 = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Suburb = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    City = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Province = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Center", x => x.CenterID);
                });

            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    ContractID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractDescr = table.Column<string>(nullable: false),
                    ContractName = table.Column<string>(nullable: false),
                    BudgetID = table.Column<int>(nullable: false),
                    Date = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.ContractID);
                });

            migrationBuilder.CreateTable(
                name: "ContractItems",
                columns: table => new
                {
                    ContractItemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractItem = table.Column<string>(maxLength: 50, nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ContractID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractItems", x => x.ContractItemID);
                });

            migrationBuilder.CreateTable(
                name: "Regional_Center",
                columns: table => new
                {
                    RegionalCenterID = table.Column<int>(nullable: false),
                    CenterID = table.Column<int>(nullable: false),
                    RegionalID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regional_Center", x => x.RegionalCenterID);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleVisit",
                columns: table => new
                {
                    ScheduleVisitID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitDescr = table.Column<string>(maxLength: 250, nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: true),
                    Time = table.Column<string>(fixedLength: true, maxLength: 10, nullable: true),
                    Duration = table.Column<string>(maxLength: 50, nullable: true),
                    ReasonForVisit = table.Column<string>(maxLength: 250, nullable: true),
                    RegionalID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleVisit", x => x.ScheduleVisitID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Budget");

            migrationBuilder.DropTable(
                name: "Center");

            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "ContractItems");

            migrationBuilder.DropTable(
                name: "Regional_Center");

            migrationBuilder.DropTable(
                name: "ScheduleVisit");
        }
    }
}
