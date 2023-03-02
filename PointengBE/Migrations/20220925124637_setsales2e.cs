using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PointengBE.Migrations
{
    public partial class setsales2e : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "STREET",
                table: "Location");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "STREET",
                table: "Location",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
