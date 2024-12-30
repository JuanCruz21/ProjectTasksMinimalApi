using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectTasks1.Migrations
{
    /// <inheritdoc />
    public partial class ColumnPesoCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Peso",
                table: "Tarea");

            migrationBuilder.AddColumn<int>(
                name: "Peso",
                table: "Categoria",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Peso",
                table: "Categoria");

            migrationBuilder.AddColumn<int>(
                name: "Peso",
                table: "Tarea",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
