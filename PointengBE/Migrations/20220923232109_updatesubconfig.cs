using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PointengBE.Migrations
{
    public partial class updatesubconfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DateEntry",
                table: "SubDirectConfigs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Sd_Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Shop_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Supervisor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesRep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REGION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CITY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZONE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AREA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SUBAREA = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateEntry",
                table: "SubDirectConfigs",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
