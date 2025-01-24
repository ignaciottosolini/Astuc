using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EIRL.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CarritoFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Insumos_Carritos_CarritoId",
                table: "Insumos");

            migrationBuilder.DropIndex(
                name: "IX_Insumos_CarritoId",
                table: "Insumos");

            migrationBuilder.DropColumn(
                name: "CarritoId",
                table: "Insumos");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Carritos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "InsumosCarritos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarritoId = table.Column<int>(type: "int", nullable: false),
                    InsumoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsumosCarritos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsumosCarritos_Carritos_CarritoId",
                        column: x => x.CarritoId,
                        principalTable: "Carritos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InsumosCarritos_CarritoId",
                table: "InsumosCarritos",
                column: "CarritoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InsumosCarritos");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Carritos");

            migrationBuilder.AddColumn<int>(
                name: "CarritoId",
                table: "Insumos",
                type: "int",
                nullable: true);

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
    }
}
