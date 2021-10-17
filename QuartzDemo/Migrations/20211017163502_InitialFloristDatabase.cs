using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuartzDemo.Migrations
{
    public partial class InitialFloristDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flowers",
                columns: table => new
                {
                    FlowerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlowerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhenAdded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flowers", x => x.FlowerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flowers");
        }
    }
}
