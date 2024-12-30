using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projectTasks1.Migrations
{
    /// <inheritdoc />
    public partial class Dataintables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("bdb76bbc-7604-422c-9717-e735eb233290"), "Logistica", "Tecnologia", 2 },
                    { new Guid("ff2e1696-e1c6-43c7-a789-152dcc93deef"), "Administracion", "Tecnologia", 1 },
                    { new Guid("ffaca5fa-db0c-4acc-8300-dda804df4177"), "Desarrollo", "Tecnologia", 1 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[,]
                {
                    { new Guid("0df62d8a-30be-450a-aee8-556361fcf51f"), new Guid("ff2e1696-e1c6-43c7-a789-152dcc93deef"), "Desarrollo de paginas web para la empresa", new DateTime(2024, 12, 28, 2, 57, 50, 262, DateTimeKind.Utc).AddTicks(1270), 2, "Desarrollo de paginas web" },
                    { new Guid("2ec0f884-d423-4f7c-ab22-88ac8f61882d"), new Guid("bdb76bbc-7604-422c-9717-e735eb233290"), "Desarrollo de aplicaciones para la empresa", new DateTime(2024, 12, 28, 2, 57, 50, 262, DateTimeKind.Utc).AddTicks(1270), 0, "Desarrollo de aplicaciones" },
                    { new Guid("a30569a5-ab8f-4d17-8b46-013eca1d77c2"), new Guid("ffaca5fa-db0c-4acc-8300-dda804df4177"), "Desarrollo de software para la empresa", new DateTime(2024, 12, 28, 2, 57, 50, 262, DateTimeKind.Utc).AddTicks(1270), 1, "Desarrollo de software" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("0df62d8a-30be-450a-aee8-556361fcf51f"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("2ec0f884-d423-4f7c-ab22-88ac8f61882d"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("a30569a5-ab8f-4d17-8b46-013eca1d77c2"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("bdb76bbc-7604-422c-9717-e735eb233290"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("ff2e1696-e1c6-43c7-a789-152dcc93deef"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("ffaca5fa-db0c-4acc-8300-dda804df4177"));

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
