using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EIRL.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class editDecimalPrecioTotalPedidoInsumo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PrecioUnidad",
                table: "InsumosPedidos",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PrecioUnidad",
                table: "InsumosPedidos",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
