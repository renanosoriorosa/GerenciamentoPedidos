using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GP.Data.Migrations
{
    public partial class TesteSemEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoProduto",
                table: "Produto");

            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "Produto",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Produto",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Estoque",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: true),
                    Descricao = table.Column<string>(type: "varchar(200)", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estoque", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estoque");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Produto");

            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "Produto",
                type: "varchar(200)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AddColumn<int>(
                name: "TipoProduto",
                table: "Produto",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
