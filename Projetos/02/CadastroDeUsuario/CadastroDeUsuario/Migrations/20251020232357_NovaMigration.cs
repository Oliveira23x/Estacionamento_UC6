using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroDeUsuario.Migrations
{
    /// <inheritdoc />
    public partial class NovaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataNascimeto",
                table: "Usuario",
                newName: "DataNascimento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataNascimento",
                table: "Usuario",
                newName: "DataNascimeto");
        }
    }
}
