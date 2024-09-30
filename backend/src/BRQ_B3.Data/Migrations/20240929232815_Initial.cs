using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BRQ_B3.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CalculoCDB",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValorInicial = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cdi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxaBanco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Meses = table.Column<int>(type: "int", nullable: false),
                    ValorFinal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculoCDB", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalculoCDB");
        }
    }
}
