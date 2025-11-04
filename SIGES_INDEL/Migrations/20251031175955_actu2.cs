using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIGES_INDEL.Migrations
{
    /// <inheritdoc />
    public partial class actu2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_TDocentes_DocenteId1",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DocenteId1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DocenteId1",
                table: "AspNetUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DocenteId1",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DocenteId1",
                table: "AspNetUsers",
                column: "DocenteId1",
                unique: true,
                filter: "[DocenteId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_TDocentes_DocenteId1",
                table: "AspNetUsers",
                column: "DocenteId1",
                principalTable: "TDocentes",
                principalColumn: "Id");
        }
    }
}
