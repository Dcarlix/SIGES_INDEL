using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIGES_INDEL.Migrations
{
    /// <inheritdoc />
    public partial class DocenteGradoUnoUno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TDocentes_GradosId",
                table: "TDocentes");

            migrationBuilder.CreateIndex(
                name: "IX_TDocentes_GradosId",
                table: "TDocentes",
                column: "GradosId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TDocentes_GradosId",
                table: "TDocentes");

            migrationBuilder.CreateIndex(
                name: "IX_TDocentes_GradosId",
                table: "TDocentes",
                column: "GradosId");
        }
    }
}
