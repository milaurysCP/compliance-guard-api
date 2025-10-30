using Microsoft.EntityFrameworkCore;
using ComplianceGuardPro.Modules.Usuarios.Models;
using ComplianceGuardPro.Modules.Clientes.Models;
using ComplianceGuardPro.Modules.Direcciones.Models;
using ComplianceGuardPro.Modules.Contactos.Models;
using ComplianceGuardPro.Modules.Beneficiarios.Models;
using ComplianceGuardPro.Modules.Intermediarios.Models;
using ComplianceGuardPro.Modules.ActividadesEconomicas.Models;
using ComplianceGuardPro.Modules.PerfilesFinancieros.Models;
using ComplianceGuardPro.Modules.Operaciones.Models;
using ComplianceGuardPro.Modules.Pagos.Models;
using ComplianceGuardPro.Modules.Transacciones.Models;
using ComplianceGuardPro.Modules.DebidaDiligencia.Models;
using ComplianceGuardPro.Modules.Riesgos.Models;
using ComplianceGuardPro.Modules.Mitigacion.Models;
using ComplianceGuardPro.Modules.Evaluaciones.Models;
using ComplianceGuardPro.Modules.MensajesChat.Models;
using ComplianceGuardPro.Modules.Referencia.Models;
using ComplianceGuardPro.Modules.PersonaExpuestaPoliticamente.Models;
using ComplianceGuardPro.Modules.Responsable.Models;
using ComplianceGuardPro.Modules.Politica.Models;
using ComplianceGuardPro.Modules.ProgresoCapacitacion.Models;
using ComplianceGuardPro.Modules.Capacitacion.Models;

namespace ComplianceGuardPro.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Aquí se agregan las entidades que se van a mapear a la base de datos
        // Ejemplo de entidades adicionales:
        public DbSet<ActividadEconomica> ActividadesEconomicas { get; set; }
        public DbSet<BeneficiarioFinal> BeneficiariosFinales { get; set; }
        public DbSet<ComplianceGuardPro.Modules.Capacitacion.Models.Capacitacion> Capacitaciones { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Contacto> Contactos { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<Evaluacion> Evaluaciones { get; set; }
        public DbSet<Intermediario> Intermediarios { get; set; }
        public DbSet<MensajeChat> MensajesChat { get; set; }
        public DbSet<Operacion> Operaciones { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<PerfilFinanciero> PerfilesFinancieros { get; set; }
        public DbSet<PersonaExpuestaPoliticamente> PersonasExpuestasPoliticamente { get; set; }
        public DbSet<Politica> Politicas { get; set; }
        public DbSet<ProgresoCapacitacion> ProgresoCapacitaciones { get; set; }
        public DbSet<Referencia> Referencias { get; set; }
        public DbSet<Responsable> Responsables { get; set; }
        public DbSet<Riesgo> Riesgos { get; set; }
        public DbSet<Mitigacion> Mitigaciones { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Transaccion> Transacciones { get; set; }
        public DbSet<DebidaDiligencia> DebidaDiligencias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Crear instancia del servicio de contraseñas para hashear
            var passwordService = new PasswordService();

            // Datos iniciales para roles
            modelBuilder.Entity<Rol>().HasData(
                new Rol
                {
                    Id = 1,
                    Nombre = "ADMIN",
                    Descripcion = "Administrador"
                }
            );

            // Datos iniciales para usuarios
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = 1,
                    UsuarioLogin = "admin",
                    ClaveHash = passwordService.HashPassword("12345678"),
                    RolId = 1,
                    EstaActivo = true
                },
                new Usuario
                {
                    Id = 2,
                    UsuarioLogin = "empleado1",
                    ClaveHash = passwordService.HashPassword("12345678"),
                    RolId = 1,
                    EstaActivo = true
                },
                new Usuario
                {
                    Id = 3,
                    UsuarioLogin = "usuario2",
                    ClaveHash = passwordService.HashPassword("Usuario456!"),
                    RolId = 1,
                    EstaActivo = true
                }
            );

            // Ejemplo de configuración personalizada:
            // Esto lo unico que hace es cambiar el nombre de la tabla en la base de datos
            // modelBuilder.Entity<Customer>().ToTable("Customers");
        }


       
    }
}