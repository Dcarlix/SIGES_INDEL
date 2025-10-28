using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIGES_INDEL.Migrations
{
    /// <inheritdoc />
    public partial class GenerosAndSeededData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GeneroId",
                table: "TEstudiantes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TGenero",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Generos = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TGenero", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TDiscapacidades",
                columns: new[] { "Id", "Discapacidad" },
                values: new object[] { 1, "No Posee" });

            migrationBuilder.InsertData(
                table: "TEstadoCivil",
                columns: new[] { "Id", "Estado" },
                values: new object[] { 1, "Soltero/a" });

            migrationBuilder.InsertData(
                table: "TEstados",
                columns: new[] { "Id", "Estados" },
                values: new object[] { 1, "Activo" });

            migrationBuilder.InsertData(
                table: "TEtnias",
                columns: new[] { "Id", "Etnias" },
                values: new object[] { 1, "No Aplica" });

            migrationBuilder.InsertData(
                table: "TGenero",
                columns: new[] { "Id", "Generos" },
                values: new object[,]
                {
                    { 1, "Masculino" },
                    { 2, "Femenino" }
                });

            migrationBuilder.InsertData(
                table: "TNacionalidades",
                columns: new[] { "Id", "Nacionalidad" },
                values: new object[] { 1, "Salvadoreño/a" });

            migrationBuilder.InsertData(
                table: "TParentescos",
                columns: new[] { "Id", "Parentescos" },
                values: new object[] { 1, "Representante" });

            migrationBuilder.CreateIndex(
                name: "IX_TEstudiantes_GeneroId",
                table: "TEstudiantes",
                column: "GeneroId");

            migrationBuilder.AddForeignKey(
                name: "FK_TEstudiantes_TGenero_GeneroId",
                table: "TEstudiantes",
                column: "GeneroId",
                principalTable: "TGenero",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TEstudiantes_TGenero_GeneroId",
                table: "TEstudiantes");

            migrationBuilder.DropTable(
                name: "TGenero");

            migrationBuilder.DropIndex(
                name: "IX_TEstudiantes_GeneroId",
                table: "TEstudiantes");

            migrationBuilder.DeleteData(
                table: "TDiscapacidades",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TEstadoCivil",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TEstados",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TEtnias",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TNacionalidades",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TParentescos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "GeneroId",
                table: "TEstudiantes");
        }
    }
}
