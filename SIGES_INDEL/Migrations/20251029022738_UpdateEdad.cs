using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIGES_INDEL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEdad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Edad",
                table: "TEstudiantes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Edad",
                table: "TEstudiantes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
