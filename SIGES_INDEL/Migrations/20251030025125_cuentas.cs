using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIGES_INDEL.Migrations
{
    /// <inheritdoc />
    public partial class cuentas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_TDocentes_DocenteId",
                table: "AspNetUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_TDocentes_DocenteId",
                table: "AspNetUsers",
                column: "DocenteId",
                principalTable: "TDocentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_TDocentes_DocenteId",
                table: "AspNetUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_TDocentes_DocenteId",
                table: "AspNetUsers",
                column: "DocenteId",
                principalTable: "TDocentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
