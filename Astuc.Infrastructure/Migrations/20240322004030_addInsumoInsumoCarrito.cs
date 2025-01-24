using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EIRL.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addInsumoInsumoCarrito : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_InsumosCarritos_InsumoId",
                table: "InsumosCarritos",
                column: "InsumoId");

            migrationBuilder.AddForeignKey(
                name: "FK_InsumosCarritos_Insumos_InsumoId",
                table: "InsumosCarritos",
                column: "InsumoId",
                principalTable: "Insumos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InsumosCarritos_Insumos_InsumoId",
                table: "InsumosCarritos");

            migrationBuilder.DropIndex(
                name: "IX_InsumosCarritos_InsumoId",
                table: "InsumosCarritos");
        }
    }
}
