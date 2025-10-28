using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstacionamentoSenac.API.Migrations
{
    /// <inheritdoc />
    public partial class AlterarNovoVeiculo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VeicuiloId",
                table: "Motoristas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VeicuiloId",
                table: "Motoristas",
                type: "int",
                nullable: true);
        }
    }
}
