using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UC_13_Henrique_Webssite.Migrations
{
    /// <inheritdoc />
    public partial class imoveis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Area",
                table: "Produto",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CEP",
                table: "Produto",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Produto",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Produto",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Produto",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Produto",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagemUrlimoveis",
                table: "Produto",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Area",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "CEP",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "ImagemUrlimoveis",
                table: "Produto");
        }
    }
}
