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
using ComplianceGuardPro.Modules.Capacitacion.Models;
using ComplianceGuardPro.Modules.Documentos.Models;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ComplianceGuardPro.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Constructor sin parámetros para Design-time (EF Migrations)
        public AppDbContext() : base(CreateDesignTimeOptions())
        { }

        private static DbContextOptions<AppDbContext> CreateDesignTimeOptions()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return optionsBuilder.Options;
        }

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
        // public DbSet<ComplianceGuardPro.Modules.ProgresoCapacitacion.Models.ProgresoCapacitacion> ProgresoCapacitaciones { get; set; }
        public DbSet<ComplianceGuardPro.Modules.Referencia.Models.Referencia> Referencias { get; set; }
        public DbSet<Responsable> Responsables { get; set; }
        public DbSet<Riesgo> Riesgos { get; set; }
        public DbSet<Mitigacion> Mitigaciones { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Transaccion> Transacciones { get; set; }
        public DbSet<DebidaDiligencia> DebidaDiligencias { get; set; }
        public DbSet<Documento> Documentos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar tipos decimales para SQL Server
            modelBuilder.Entity<ComplianceGuardPro.Modules.Mitigacion.Models.Mitigacion>()
                .Property(e => e.Eficacia)
                .HasPrecision(5, 2);

            // modelBuilder.Entity<ComplianceGuardPro.Modules.ProgresoCapacitacion.Models.ProgresoCapacitacion>()
            //     .Property(e => e.ProgresoPorcentaje)
            //     .HasPrecision(5, 2);

            // Configurar índices únicos para Cliente
            modelBuilder.Entity<Cliente>()
                .HasIndex(c => c.DocumentoIdentidad)
                .IsUnique()
                .HasFilter("[DocumentoIdentidad] IS NOT NULL");

            modelBuilder.Entity<Cliente>()
                .HasIndex(c => c.Rnc)
                .IsUnique()
                .HasFilter("[Rnc] IS NOT NULL");

            // Los datos iniciales se crearán mediante un endpoint o script separado
            // para evitar problemas con el hash de contraseñas
        }


       
    }
}