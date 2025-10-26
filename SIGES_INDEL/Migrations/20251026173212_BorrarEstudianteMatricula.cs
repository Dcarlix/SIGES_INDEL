using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIGES_INDEL.Migrations
{
    /// <inheritdoc />
    public partial class BorrarEstudianteMatricula : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TMatriculas_TEstudiantes_EstudianteId",
                table: "TMatriculas");

            migrationBuilder.AddForeignKey(
                name: "FK_TMatriculas_TEstudiantes_EstudianteId",
                table: "TMatriculas",
                column: "EstudianteId",
                principalTable: "TEstudiantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TMatriculas_TEstudiantes_EstudianteId",
                table: "TMatriculas");

            migrationBuilder.AddForeignKey(
                name: "FK_TMatriculas_TEstudiantes_EstudianteId",
                table: "TMatriculas",
                column: "EstudianteId",
                principalTable: "TEstudiantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
