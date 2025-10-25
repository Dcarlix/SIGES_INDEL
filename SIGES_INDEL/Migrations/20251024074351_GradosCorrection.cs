using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIGES_INDEL.Migrations
{
    /// <inheritdoc />
    public partial class GradosCorrection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TMatriculas_TGrados_GradosId",
                table: "TMatriculas");

            migrationBuilder.DropColumn(
                name: "GradoId",
                table: "TMatriculas");

            migrationBuilder.AlterColumn<int>(
                name: "GradosId",
                table: "TMatriculas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TMatriculas_TGrados_GradosId",
                table: "TMatriculas",
                column: "GradosId",
                principalTable: "TGrados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TMatriculas_TGrados_GradosId",
                table: "TMatriculas");

            migrationBuilder.AlterColumn<int>(
                name: "GradosId",
                table: "TMatriculas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "GradoId",
                table: "TMatriculas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_TMatriculas_TGrados_GradosId",
                table: "TMatriculas",
                column: "GradosId",
                principalTable: "TGrados",
                principalColumn: "Id");
        }
    }
}
