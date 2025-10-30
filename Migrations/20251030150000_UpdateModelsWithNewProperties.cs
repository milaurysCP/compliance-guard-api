using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComplianceGuardPro.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModelsWithNewProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Agregar nuevas columnas a la tabla Clientes
            migrationBuilder.AddColumn<bool>(
                name: "EstaActivo",
                table: "Clientes",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Clientes",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                defaultValue: "Activo");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRegistro",
                table: "Clientes",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2025, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified));

            // Agregar nuevas columnas a la tabla Riesgos
            migrationBuilder.AddColumn<long>(
                name: "ClienteId",
                table: "Riesgos",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Riesgos",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                defaultValue: "Activo");

            migrationBuilder.AddColumn<string>(
                name: "Nivel",
                table: "Riesgos",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                defaultValue: "Medio");

            // Agregar nuevas columnas a la tabla DebidaDiligencias
            migrationBuilder.AddColumn<string>(
                name: "Conclusion",
                table: "DebidaDiligencias",
                type: "varchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ResponsableId",
                table: "DebidaDiligencias",
                type: "bigint",
                nullable: true);

            // Crear tabla Documentos
            migrationBuilder.CreateTable(
                name: "Documentos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Tipo = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    RutaArchivo = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    Descripcion = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true),
                    Verificado = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    FechaSubida = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2025, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    DebidaDiligenciaId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documentos_DebidaDiligencias_DebidaDiligenciaId",
                        column: x => x.DebidaDiligenciaId,
                        principalTable: "DebidaDiligencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            // Crear índices
            migrationBuilder.CreateIndex(
                name: "IX_Riesgos_ClienteId",
                table: "Riesgos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_DebidaDiligencias_ResponsableId",
                table: "DebidaDiligencias",
                column: "ResponsableId");

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_DebidaDiligenciaId",
                table: "Documentos",
                column: "DebidaDiligenciaId");

            // Agregar foreign keys
            migrationBuilder.AddForeignKey(
                name: "FK_Riesgos_Clientes_ClienteId",
                table: "Riesgos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DebidaDiligencias_Responsables_ResponsableId",
                table: "DebidaDiligencias",
                column: "ResponsableId",
                principalTable: "Responsables",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Eliminar foreign keys
            migrationBuilder.DropForeignKey(
                name: "FK_Riesgos_Clientes_ClienteId",
                table: "Riesgos");

            migrationBuilder.DropForeignKey(
                name: "FK_DebidaDiligencias_Responsables_ResponsableId",
                table: "DebidaDiligencias");

            // Eliminar índices
            migrationBuilder.DropIndex(
                name: "IX_Riesgos_ClienteId",
                table: "Riesgos");

            migrationBuilder.DropIndex(
                name: "IX_DebidaDiligencias_ResponsableId",
                table: "DebidaDiligencias");

            migrationBuilder.DropIndex(
                name: "IX_Documentos_DebidaDiligenciaId",
                table: "Documentos");

            // Eliminar tabla Documentos
            migrationBuilder.DropTable(
                name: "Documentos");

            // Eliminar columnas agregadas
            migrationBuilder.DropColumn(
                name: "EstaActivo",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "FechaRegistro",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Riesgos");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Riesgos");

            migrationBuilder.DropColumn(
                name: "Nivel",
                table: "Riesgos");

            migrationBuilder.DropColumn(
                name: "Conclusion",
                table: "DebidaDiligencias");

            migrationBuilder.DropColumn(
                name: "ResponsableId",
                table: "DebidaDiligencias");
        }
    }
}