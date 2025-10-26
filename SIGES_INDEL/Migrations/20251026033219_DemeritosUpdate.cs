using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIGES_INDEL.Migrations
{
    /// <inheritdoc />
    public partial class DemeritosUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TDemeritosAsignados_TDemertios_DemeritosId",
                table: "TDemeritosAsignados");

            migrationBuilder.DropColumn(
                name: "DemeritoId",
                table: "TDemeritosAsignados");

            migrationBuilder.AlterColumn<int>(
                name: "DemeritosId",
                table: "TDemeritosAsignados",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TDemeritosAsignados_TDemertios_DemeritosId",
                table: "TDemeritosAsignados",
                column: "DemeritosId",
                principalTable: "TDemertios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TDemeritosAsignados_TDemertios_DemeritosId",
                table: "TDemeritosAsignados");

            migrationBuilder.AlterColumn<int>(
                name: "DemeritosId",
                table: "TDemeritosAsignados",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DemeritoId",
                table: "TDemeritosAsignados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_TDemeritosAsignados_TDemertios_DemeritosId",
                table: "TDemeritosAsignados",
                column: "DemeritosId",
                principalTable: "TDemertios",
                principalColumn: "Id");
        }
    }
}
