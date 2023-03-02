using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PointengBE.Migrations
{
    public partial class AddCalcl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Calculations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Plan = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateEntry = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calculations", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calculations");
        }
    }
}
