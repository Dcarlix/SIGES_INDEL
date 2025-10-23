using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIGES_INDEL.Migrations
{
    /// <inheritdoc />
    public partial class Academico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TActasAsignadas_TDocentes_DocenteId",
                table: "TActasAsignadas");

            migrationBuilder.DropForeignKey(
                name: "FK_TActasAsignadas_TEstudiantes_EstudianteId",
                table: "TActasAsignadas");

            migrationBuilder.DropForeignKey(
                name: "FK_TDemeritosAsignados_TDocentes_DocenteId",
                table: "TDemeritosAsignados");

            migrationBuilder.DropForeignKey(
                name: "FK_TDemeritosAsignados_TEstudiantes_EstudianteId",
                table: "TDemeritosAsignados");

            migrationBuilder.DropForeignKey(
                name: "FK_TFichasAsignadas_TDocentes_DocenteId",
                table: "TFichasAsignadas");

            migrationBuilder.DropForeignKey(
                name: "FK_TFichasAsignadas_TEstudiantes_EstudianteId",
                table: "TFichasAsignadas");

            migrationBuilder.DropForeignKey(
                name: "FK_TMeritosAsignados_TDocentes_DocenteId",
                table: "TMeritosAsignados");

            migrationBuilder.DropForeignKey(
                name: "FK_TMeritosAsignados_TEstudiantes_EstudianteId",
                table: "TMeritosAsignados");

            migrationBuilder.DropColumn(
                name: "NIE",
                table: "TMeritosAsignados");

            migrationBuilder.DropColumn(
                name: "NIP",
                table: "TMeritosAsignados");

            migrationBuilder.DropColumn(
                name: "NIE",
                table: "TFichasAsignadas");

            migrationBuilder.DropColumn(
                name: "NIP",
                table: "TFichasAsignadas");

            migrationBuilder.DropColumn(
                name: "NIE",
                table: "TDemeritosAsignados");

            migrationBuilder.DropColumn(
                name: "NIP",
                table: "TDemeritosAsignados");

            migrationBuilder.DropColumn(
                name: "NIE",
                table: "TActasAsignadas");

            migrationBuilder.DropColumn(
                name: "NIP",
                table: "TActasAsignadas");

            migrationBuilder.AlterColumn<int>(
                name: "EstudianteId",
                table: "TMeritosAsignados",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DocenteId",
                table: "TMeritosAsignados",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EstudianteId",
                table: "TFichasAsignadas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DocenteId",
                table: "TFichasAsignadas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EstudianteId",
                table: "TDemeritosAsignados",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DocenteId",
                table: "TDemeritosAsignados",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EstudianteId",
                table: "TActasAsignadas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DocenteId",
                table: "TActasAsignadas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TActasAsignadas_TDocentes_DocenteId",
                table: "TActasAsignadas",
                column: "DocenteId",
                principalTable: "TDocentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TActasAsignadas_TEstudiantes_EstudianteId",
                table: "TActasAsignadas",
                column: "EstudianteId",
                principalTable: "TEstudiantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TDemeritosAsignados_TDocentes_DocenteId",
                table: "TDemeritosAsignados",
                column: "DocenteId",
                principalTable: "TDocentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TDemeritosAsignados_TEstudiantes_EstudianteId",
                table: "TDemeritosAsignados",
                column: "EstudianteId",
                principalTable: "TEstudiantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TFichasAsignadas_TDocentes_DocenteId",
                table: "TFichasAsignadas",
                column: "DocenteId",
                principalTable: "TDocentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TFichasAsignadas_TEstudiantes_EstudianteId",
                table: "TFichasAsignadas",
                column: "EstudianteId",
                principalTable: "TEstudiantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TMeritosAsignados_TDocentes_DocenteId",
                table: "TMeritosAsignados",
                column: "DocenteId",
                principalTable: "TDocentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TMeritosAsignados_TEstudiantes_EstudianteId",
                table: "TMeritosAsignados",
                column: "EstudianteId",
                principalTable: "TEstudiantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TActasAsignadas_TDocentes_DocenteId",
                table: "TActasAsignadas");

            migrationBuilder.DropForeignKey(
                name: "FK_TActasAsignadas_TEstudiantes_EstudianteId",
                table: "TActasAsignadas");

            migrationBuilder.DropForeignKey(
                name: "FK_TDemeritosAsignados_TDocentes_DocenteId",
                table: "TDemeritosAsignados");

            migrationBuilder.DropForeignKey(
                name: "FK_TDemeritosAsignados_TEstudiantes_EstudianteId",
                table: "TDemeritosAsignados");

            migrationBuilder.DropForeignKey(
                name: "FK_TFichasAsignadas_TDocentes_DocenteId",
                table: "TFichasAsignadas");

            migrationBuilder.DropForeignKey(
                name: "FK_TFichasAsignadas_TEstudiantes_EstudianteId",
                table: "TFichasAsignadas");

            migrationBuilder.DropForeignKey(
                name: "FK_TMeritosAsignados_TDocentes_DocenteId",
                table: "TMeritosAsignados");

            migrationBuilder.DropForeignKey(
                name: "FK_TMeritosAsignados_TEstudiantes_EstudianteId",
                table: "TMeritosAsignados");

            migrationBuilder.AlterColumn<int>(
                name: "EstudianteId",
                table: "TMeritosAsignados",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DocenteId",
                table: "TMeritosAsignados",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "NIE",
                table: "TMeritosAsignados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NIP",
                table: "TMeritosAsignados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "EstudianteId",
                table: "TFichasAsignadas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DocenteId",
                table: "TFichasAsignadas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "NIE",
                table: "TFichasAsignadas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NIP",
                table: "TFichasAsignadas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "EstudianteId",
                table: "TDemeritosAsignados",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DocenteId",
                table: "TDemeritosAsignados",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "NIE",
                table: "TDemeritosAsignados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NIP",
                table: "TDemeritosAsignados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "EstudianteId",
                table: "TActasAsignadas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DocenteId",
                table: "TActasAsignadas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "NIE",
                table: "TActasAsignadas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NIP",
                table: "TActasAsignadas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_TActasAsignadas_TDocentes_DocenteId",
                table: "TActasAsignadas",
                column: "DocenteId",
                principalTable: "TDocentes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TActasAsignadas_TEstudiantes_EstudianteId",
                table: "TActasAsignadas",
                column: "EstudianteId",
                principalTable: "TEstudiantes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TDemeritosAsignados_TDocentes_DocenteId",
                table: "TDemeritosAsignados",
                column: "DocenteId",
                principalTable: "TDocentes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TDemeritosAsignados_TEstudiantes_EstudianteId",
                table: "TDemeritosAsignados",
                column: "EstudianteId",
                principalTable: "TEstudiantes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TFichasAsignadas_TDocentes_DocenteId",
                table: "TFichasAsignadas",
                column: "DocenteId",
                principalTable: "TDocentes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TFichasAsignadas_TEstudiantes_EstudianteId",
                table: "TFichasAsignadas",
                column: "EstudianteId",
                principalTable: "TEstudiantes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TMeritosAsignados_TDocentes_DocenteId",
                table: "TMeritosAsignados",
                column: "DocenteId",
                principalTable: "TDocentes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TMeritosAsignados_TEstudiantes_EstudianteId",
                table: "TMeritosAsignados",
                column: "EstudianteId",
                principalTable: "TEstudiantes",
                principalColumn: "Id");
        }
    }
}
