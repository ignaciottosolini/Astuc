using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EIRL.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addCarrito : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarritoId",
                table: "Insumos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Carritos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carritos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Insumos_CarritoId",
                table: "Insumos",
                column: "CarritoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Insumos_Carritos_CarritoId",
                table: "Insumos",
                column: "CarritoId",
                principalTable: "Carritos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Insumos_Carritos_CarritoId",
                table: "Insumos");

            migrationBuilder.DropTable(
                name: "Carritos");

            migrationBuilder.DropIndex(
                name: "IX_Insumos_CarritoId",
                table: "Insumos");

            migrationBuilder.DropColumn(
                name: "CarritoId",
                table: "Insumos");
        }
    }
}
