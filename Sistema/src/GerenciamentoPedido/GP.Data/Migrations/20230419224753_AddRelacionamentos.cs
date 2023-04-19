using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GP.Data.Migrations
{
    public partial class AddRelacionamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CodigoBarrasVolume",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoBarras = table.Column<string>(type: "varchar(200)", nullable: false),
                    PrecoUnitario = table.Column<double>(type: "float", nullable: false),
                    QuantidadeEntrada = table.Column<int>(type: "int", nullable: false),
                    QuantidadeReservada = table.Column<int>(type: "int", nullable: false),
                    QuantidadeSaida = table.Column<int>(type: "int", nullable: false),
                    RecebimentoId = table.Column<int>(type: "int", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    EstoqueId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodigoBarrasVolume", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CodigoBarrasVolume_Estoque_EstoqueId",
                        column: x => x.EstoqueId,
                        principalTable: "Estoque",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CodigoBarrasVolume_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CodigoBarrasVolume_Recebimento_RecebimentoId",
                        column: x => x.RecebimentoId,
                        principalTable: "Recebimento",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CodigoBarrasVolume_EstoqueId",
                table: "CodigoBarrasVolume",
                column: "EstoqueId");

            migrationBuilder.CreateIndex(
                name: "IX_CodigoBarrasVolume_ProdutoId",
                table: "CodigoBarrasVolume",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_CodigoBarrasVolume_RecebimentoId",
                table: "CodigoBarrasVolume",
                column: "RecebimentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CodigoBarrasVolume");
        }
    }
}
