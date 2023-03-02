using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PointengBE.Migrations
{
    public partial class setsales2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Extrapoint",
                table: "Sales",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Point",
                table: "Sales",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ToalPoint",
                table: "Sales",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Extrapoint",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "Point",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "ToalPoint",
                table: "Sales");
        }
    }
}
