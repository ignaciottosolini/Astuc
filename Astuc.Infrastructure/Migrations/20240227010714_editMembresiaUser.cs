using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EIRL.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class editMembresiaUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Membresias_MembresiaId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "MembresiaId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Membresias_MembresiaId",
                table: "AspNetUsers",
                column: "MembresiaId",
                principalTable: "Membresias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Membresias_MembresiaId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "MembresiaId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Membresias_MembresiaId",
                table: "AspNetUsers",
                column: "MembresiaId",
                principalTable: "Membresias",
                principalColumn: "Id");
        }
    }
}
