using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EIRL.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addCategoriaInsumo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Insumos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Insumos");
        }
    }
}
