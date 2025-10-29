using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIGES_INDEL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGrados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TDocentes_TGrados_GradosId",
                table: "TDocentes");

            migrationBuilder.DropIndex(
                name: "IX_TDocentes_GradosId",
                table: "TDocentes");

            migrationBuilder.AlterColumn<int>(
                name: "GradosId",
                table: "TDocentes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_TDocentes_GradosId",
                table: "TDocentes",
                column: "GradosId",
                unique: true,
                filter: "[GradosId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_TDocentes_TGrados_GradosId",
                table: "TDocentes",
                column: "GradosId",
                principalTable: "TGrados",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TDocentes_TGrados_GradosId",
                table: "TDocentes");

            migrationBuilder.DropIndex(
                name: "IX_TDocentes_GradosId",
                table: "TDocentes");

            migrationBuilder.AlterColumn<int>(
                name: "GradosId",
                table: "TDocentes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TDocentes_GradosId",
                table: "TDocentes",
                column: "GradosId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TDocentes_TGrados_GradosId",
                table: "TDocentes",
                column: "GradosId",
                principalTable: "TGrados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
