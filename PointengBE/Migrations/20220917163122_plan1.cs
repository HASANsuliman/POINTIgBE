using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PointengBE.Migrations
{
    public partial class plan1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Month = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogHistories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Month = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PointPrice = table.Column<int>(type: "int", nullable: false),
                    MinValue = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserUpdate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateEntry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateUpdated = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RangeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Month = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RangeFrom = table.Column<int>(type: "int", nullable: false),
                    RangeTo = table.Column<int>(type: "int", nullable: false),
                    SubConfigId = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    ExtraPoints = table.Column<int>(type: "int", nullable: false),
                    REGION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CITY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZONE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AREA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SUBAREA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateEntry = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SUBDEALER = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectConfigs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DirectConfigs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Month = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RangeFrom = table.Column<int>(type: "int", nullable: false),
                    RangeTo = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateEntry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectConfigs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DirectConfigs_Plan_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DirectConfigs_PlanId",
                table: "DirectConfigs",
                column: "PlanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomClaims");

            migrationBuilder.DropTable(
                name: "DirectConfigs");

            migrationBuilder.DropTable(
                name: "LogHistories");

            migrationBuilder.DropTable(
                name: "SubDirectConfigs");

            migrationBuilder.DropTable(
                name: "Plan");
        }
    }
}
