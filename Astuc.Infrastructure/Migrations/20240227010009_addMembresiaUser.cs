using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EIRL.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addMembresiaUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MembresiaId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MembresiaId",
                table: "AspNetUsers",
                column: "MembresiaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Membresias_MembresiaId",
                table: "AspNetUsers",
                column: "MembresiaId",
                principalTable: "Membresias",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Membresias_MembresiaId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MembresiaId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MembresiaId",
                table: "AspNetUsers");
        }
    }
}
