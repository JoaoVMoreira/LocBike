using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocBike.Migrations
{
    public partial class atualizandoTabelaCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Nome",
                table: "Cliente",
                column: "Nome",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cliente_Nome",
                table: "Cliente");
        }
    }
}
