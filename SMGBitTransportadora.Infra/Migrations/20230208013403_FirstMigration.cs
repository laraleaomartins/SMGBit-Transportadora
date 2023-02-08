using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMGBitTransportadora.Infra.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Planilhas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Operacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Paradas = table.Column<int>(type: "int", nullable: false),
                    NumeroViagem = table.Column<int>(type: "int", nullable: false),
                    DataViagem = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Destino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Placa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Motorista = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoVeiculo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KmRodado = table.Column<int>(type: "int", nullable: false),
                    Caixas = table.Column<int>(type: "int", nullable: false),
                    TipoViagem = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planilhas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Planilhas");
        }
    }
}
