using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PointengBE.Migrations
{
    public partial class promoters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SalesPromoter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USERID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PROM_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PROM_CITY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SALES_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MONTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    STATUS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SD_CODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SD_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SHOP_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REGION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CITY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZONE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AREA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SUBAREA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SUPERVISOR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RETAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SUBNO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ACTIVEANDHAVECALL = table.Column<int>(type: "int", nullable: true),
                    FIRST_RECHARGE = table.Column<int>(type: "int", nullable: true),
                    Point = table.Column<int>(type: "int", nullable: true),
                    Extrapoint = table.Column<int>(type: "int", nullable: true),
                    ToalPoint = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesPromoter", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesPromoter");
        }
    }
}
