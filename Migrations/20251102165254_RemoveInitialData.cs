using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ComplianceGuardPro.Migrations
{
    /// <inheritdoc />
    public partial class RemoveInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Descripcion", "Nombre" },
                values: new object[] { 1L, "Administrador", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "ClaveHash", "EstaActivo", "Nombre", "RolId", "Token", "UsuarioLogin" },
                values: new object[,]
                {
                    { 1L, "$2a$11$9lTG7sFHE8pDbqL.Ur4YrOYrYt7E5rD8eDJ7gU1K9U5oVo0LqH5uO", true, null, 1L, null, "admin" },
                    { 2L, "$2a$11$9lTG7sFHE8pDbqL.Ur4YrOYrYt7E5rD8eDJ7gU1K9U5oVo0LqH5uO", true, null, 1L, null, "empleado1" },
                    { 3L, "$2a$11$7D8eFhE8pDbqL.Ur4YrOYrYt7E5rD8eDJ7gU1K9U5oVo0LqH5uO", true, null, 1L, null, "usuario2" }
                });
        }
    }
}
