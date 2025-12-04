using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComplianceGuardPro.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Capacitaciones",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    DuracionHoras = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Instructor = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Capacitaciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    TipoPersona = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Siglas = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DocumentoIdentidad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Rnc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RegistroMercantil = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CasaMatriz = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Politicas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Politicas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActividadesEconomicas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sector = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CampoLaboral = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OrigenFondos = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Proveedor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PrincipalCliente = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Proyecto = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Inscripciones = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ClienteId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActividadesEconomicas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActividadesEconomicas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BeneficiariosFinales",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Identificacion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Nacionalidad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ClienteId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeneficiariosFinales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BeneficiariosFinales_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contactos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Valor = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ClienteId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contactos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contactos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DebidaDiligencias",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SujetoNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SujetoIdentificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SujetoListas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SujetoOtraInformacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoPersona = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Jurisdiccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RiesgoProducto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SectorEconomico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CampoLaboral = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrigenesRecurso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NivelIngreso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fuente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoPago = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoMoneda = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoPeps = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CargoPeps = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstitucionPeps = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Consulta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelacionTerceros = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Actividad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Canal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    PuntajeRiesgo = table.Column<int>(type: "int", nullable: false),
                    NivelRiesgo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoDiligencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClienteId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DebidaDiligencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DebidaDiligencias_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Direcciones",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Calle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Sector = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Municipio = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Provincia = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Pais = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CodigoPostal = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ClienteId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direcciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Direcciones_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Intermediarios",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ClienteId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intermediarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Intermediarios_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Operaciones",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoOperacion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EndidadFinanciera = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CodigoOperacion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DescripcionOperacion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PropositoOperacion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClienteId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operaciones_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PerfilesFinancieros",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ningreso = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Fuentes = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NivelIngreso = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Fuente = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ClienteId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfilesFinancieros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PerfilesFinancieros_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonasExpuestasPoliticamente",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CargoPeps = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    TipoPeps = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NombrePeps = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Decreto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    InstitucionPeps = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Cargo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Ordenanza = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Institucion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ClienteId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonasExpuestasPoliticamente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonasExpuestasPoliticamente_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Referencias",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Recomendacion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ClienteId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Referencias_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Responsables",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResponsableTransaccion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NombresResposable = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ApellidosResponsable = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DireccionResponsable = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IdentificacionResponsable = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Cargo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DocumentoIdentificacion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ClienteId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Responsables_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transacciones",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    InstitucionFinanciera = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PropositoProducto = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FormaDeposito = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FormaExpectativa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ClienteId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transacciones_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioLogin = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ClaveHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Token = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    RolId = table.Column<long>(type: "bigint", nullable: false),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_RolId",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documentos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RutaArchivo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Verificado = table.Column<bool>(type: "bit", nullable: false),
                    FechaSubida = table.Column<DateTime>(type: "datetime2", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Riesgos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Frecuencia = table.Column<int>(type: "int", nullable: true),
                    Nivel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Impacto = table.Column<int>(type: "int", nullable: true),
                    DebidaDiligenciaId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Riesgos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Riesgos_DebidaDiligencias_DebidaDiligenciaId",
                        column: x => x.DebidaDiligenciaId,
                        principalTable: "DebidaDiligencias",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Moneda = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TipoPago = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CodigoPago = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperacionId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagos_Operaciones_OperacionId",
                        column: x => x.OperacionId,
                        principalTable: "Operaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MensajesChat",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false),
                    Mensaje = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FechaEnvio = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MensajesChat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MensajesChat_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Evaluaciones",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RiesgoId = table.Column<long>(type: "bigint", nullable: false),
                    ClienteId = table.Column<long>(type: "bigint", nullable: false),
                    Puntaje = table.Column<int>(type: "int", nullable: true),
                    FechaEvaluacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioEvaluador = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evaluaciones_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Evaluaciones_Riesgos_RiesgoId",
                        column: x => x.RiesgoId,
                        principalTable: "Riesgos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mitigaciones",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RiesgoId = table.Column<long>(type: "bigint", nullable: false),
                    Accion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Responsable = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaCierre = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Eficacia = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mitigaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mitigaciones_Riesgos_RiesgoId",
                        column: x => x.RiesgoId,
                        principalTable: "Riesgos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActividadesEconomicas_ClienteId",
                table: "ActividadesEconomicas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_BeneficiariosFinales_ClienteId",
                table: "BeneficiariosFinales",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_DocumentoIdentidad",
                table: "Clientes",
                column: "DocumentoIdentidad",
                unique: true,
                filter: "[DocumentoIdentidad] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Rnc",
                table: "Clientes",
                column: "Rnc",
                unique: true,
                filter: "[Rnc] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Contactos_ClienteId",
                table: "Contactos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_DebidaDiligencias_ClienteId",
                table: "DebidaDiligencias",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Direcciones_ClienteId",
                table: "Direcciones",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_DebidaDiligenciaId",
                table: "Documentos",
                column: "DebidaDiligenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluaciones_ClienteId",
                table: "Evaluaciones",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluaciones_RiesgoId",
                table: "Evaluaciones",
                column: "RiesgoId");

            migrationBuilder.CreateIndex(
                name: "IX_Intermediarios_ClienteId",
                table: "Intermediarios",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_MensajesChat_UsuarioId",
                table: "MensajesChat",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Mitigaciones_RiesgoId",
                table: "Mitigaciones",
                column: "RiesgoId");

            migrationBuilder.CreateIndex(
                name: "IX_Operaciones_ClienteId",
                table: "Operaciones",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_OperacionId",
                table: "Pagos",
                column: "OperacionId");

            migrationBuilder.CreateIndex(
                name: "IX_PerfilesFinancieros_ClienteId",
                table: "PerfilesFinancieros",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonasExpuestasPoliticamente_ClienteId",
                table: "PersonasExpuestasPoliticamente",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Referencias_ClienteId",
                table: "Referencias",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Responsables_ClienteId",
                table: "Responsables",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Riesgos_DebidaDiligenciaId",
                table: "Riesgos",
                column: "DebidaDiligenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_ClienteId",
                table: "Transacciones",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolId",
                table: "Usuarios",
                column: "RolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActividadesEconomicas");

            migrationBuilder.DropTable(
                name: "BeneficiariosFinales");

            migrationBuilder.DropTable(
                name: "Capacitaciones");

            migrationBuilder.DropTable(
                name: "Contactos");

            migrationBuilder.DropTable(
                name: "Direcciones");

            migrationBuilder.DropTable(
                name: "Documentos");

            migrationBuilder.DropTable(
                name: "Evaluaciones");

            migrationBuilder.DropTable(
                name: "Intermediarios");

            migrationBuilder.DropTable(
                name: "MensajesChat");

            migrationBuilder.DropTable(
                name: "Mitigaciones");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "PerfilesFinancieros");

            migrationBuilder.DropTable(
                name: "PersonasExpuestasPoliticamente");

            migrationBuilder.DropTable(
                name: "Politicas");

            migrationBuilder.DropTable(
                name: "Referencias");

            migrationBuilder.DropTable(
                name: "Responsables");

            migrationBuilder.DropTable(
                name: "Transacciones");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Riesgos");

            migrationBuilder.DropTable(
                name: "Operaciones");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "DebidaDiligencias");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
