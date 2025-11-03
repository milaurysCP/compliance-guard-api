using Microsoft.AspNetCore.Mvc;
using ComplianceGuardPro.Data;
using ComplianceGuardPro.Modules.Usuarios.Models;
using ComplianceGuardPro.Shared.Services;
using Microsoft.EntityFrameworkCore;

namespace ComplianceGuardPro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InitController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly PasswordService _passwordService;

        public InitController(AppDbContext context, PasswordService passwordService)
        {
            _context = context;
            _passwordService = passwordService;
        }

        [HttpGet("status")]
        public async Task<IActionResult> GetDatabaseStatus()
        {
            var stats = new
            {
                roles = await _context.Roles.CountAsync(),
                usuarios = await _context.Usuarios.CountAsync(),
                politicas = await _context.Politicas.CountAsync(),
                capacitaciones = await _context.Capacitaciones.CountAsync(),
                clientes = await _context.Clientes.CountAsync(),
                actividadesEconomicas = await _context.ActividadesEconomicas.CountAsync(),
                direcciones = await _context.Direcciones.CountAsync(),
                contactos = await _context.Contactos.CountAsync(),
                beneficiarios = await _context.BeneficiariosFinales.CountAsync(),
                perfilesFinancieros = await _context.PerfilesFinancieros.CountAsync(),
                riesgos = await _context.Riesgos.CountAsync(),
                operaciones = await _context.Operaciones.CountAsync(),
                transacciones = await _context.Transacciones.CountAsync(),
                evaluaciones = await _context.Evaluaciones.CountAsync()
            };

            var totalRecords = stats.roles + stats.usuarios + stats.politicas + stats.capacitaciones + 
                             stats.clientes + stats.actividadesEconomicas + stats.direcciones + 
                             stats.contactos + stats.beneficiarios + stats.perfilesFinancieros + 
                             stats.riesgos + stats.operaciones + stats.transacciones + stats.evaluaciones;

            return Ok(new {
                message = "Estado completo de la base de datos",
                data = stats,
                hasData = totalRecords > 0,
                totalRecords = totalRecords,
                instructions = new
                {
                    seedData = "Para cargar datos completos, ejecuta el archivo 'seed_data.sql' en SQL Server Management Studio",
                    cleanData = "Para limpiar la base de datos, ejecuta el archivo 'clean_database.sql'",
                    sqlFiles = new[] { "seed_data.sql", "clean_database.sql" }
                }
            });
        }

        [HttpPost("create-admin")]
        public async Task<IActionResult> CreateAdminUser()
        {
            try
            {
                // Verificar si ya existe un admin
                if (await _context.Usuarios.AnyAsync(u => u.UsuarioLogin == "admin"))
                {
                    return BadRequest(new { message = "El usuario admin ya existe" });
                }

                // Crear rol admin si no existe
                var adminRole = await _context.Roles.FirstOrDefaultAsync(r => r.Nombre == "ADMIN");
                if (adminRole == null)
                {
                    adminRole = new Rol { Nombre = "ADMIN", Descripcion = "Administrador del sistema" };
                    _context.Roles.Add(adminRole);
                    await _context.SaveChangesAsync();
                }

                // Crear usuario admin
                var admin = new Usuario
                {
                    UsuarioLogin = "admin",
                    Nombre = "Administrador Principal",
                    ClaveHash = _passwordService.HashPassword("12345678"),
                    RolId = adminRole.Id,
                    EstaActivo = true
                };

                _context.Usuarios.Add(admin);
                await _context.SaveChangesAsync();

                return Ok(new { 
                    message = "Usuario administrador creado exitosamente",
                    username = "admin",
                    password = "12345678",
                    note = "Cambia la contraseña después del primer login"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { 
                    message = "Error al crear usuario administrador", 
                    error = ex.Message 
                });
            }
        }

        [HttpGet("connection-test")]
        public async Task<IActionResult> TestConnection()
        {
            try
            {
                await _context.Database.CanConnectAsync();
                
                var dbInfo = new
                {
                    connectionSuccess = true,
                    databaseName = _context.Database.GetDbConnection().Database,
                    serverVersion = _context.Database.GetDbConnection().ServerVersion,
                    connectionString = _context.Database.GetConnectionString()?.Substring(0, Math.Min(50, _context.Database.GetConnectionString()?.Length ?? 0)) + "..."
                };

                return Ok(new { 
                    message = "Conexión a base de datos exitosa",
                    database = dbInfo
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { 
                    message = "Error de conexión a la base de datos", 
                    error = ex.Message 
                });
            }
        }
    }
}