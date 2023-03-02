using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PointengBE.Migrations
{
    public partial class setnewsales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MONTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SD_CODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SD_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SHOP_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REGION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CITY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZONE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AREA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SUBAREA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    STREET = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SUPERVISOR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RETAIL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DAY = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MONTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    ACTIVEANDHAVECALL = table.Column<int>(type: "int", nullable: false),
                    FIRST_RECHARGE = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Sale");
        }
    }
}
