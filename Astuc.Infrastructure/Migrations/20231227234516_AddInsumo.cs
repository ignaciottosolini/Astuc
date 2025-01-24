using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EIRL.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddInsumo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.CreateTable(
                name: "Insumos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Costo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrecioVenta = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insumos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Insumos");

            migrationBuilder.CreateTable(
                name: "Gastos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CostoCombustible = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CostoViaje = table.Column<int>(type: "int", nullable: false),
                    Ganancias = table.Column<int>(type: "int", nullable: false),
                    Gastos = table.Column<int>(type: "int", nullable: false),
                    Llantas = table.Column<int>(type: "int", nullable: false),
                    Mantenimiento = table.Column<int>(type: "int", nullable: false),
                    Otros = table.Column<int>(type: "int", nullable: false),
                    Unidad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gastos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Viajes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Autorizacion = table.Column<bool>(type: "bit", nullable: false),
                    Chofer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CostoViaje = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaLlegada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LugarDestino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LugarSalida = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroPlaca = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viajes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Combustibles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CantidadGalones = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CostoPorGalon = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CostoTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Factura = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KmFinal = table.Column<int>(type: "int", nullable: false),
                    KmInicial = table.Column<int>(type: "int", nullable: false),
                    Recorrido = table.Column<int>(type: "int", nullable: false),
                    Rendimiento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TipoCombustible = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vehiculo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ViajeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combustibles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Combustibles_Viajes_ViajeId",
                        column: x => x.ViajeId,
                        principalTable: "Viajes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pasajeros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DNI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Empresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ViajeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pasajeros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pasajeros_Viajes_ViajeId",
                        column: x => x.ViajeId,
                        principalTable: "Viajes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Combustibles_ViajeId",
                table: "Combustibles",
                column: "ViajeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pasajeros_ViajeId",
                table: "Pasajeros",
                column: "ViajeId");
        }
    }
}
