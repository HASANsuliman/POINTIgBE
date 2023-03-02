using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PointengBE.Migrations
{
    public partial class setnew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AREA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CITY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REGION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SUBAREA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesRep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sd_Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Shop_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Supervisor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZONE = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });
        }
    }
}
