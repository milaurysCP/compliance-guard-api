using System.ComponentModel.DataAnnotations;

public class Cliente
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public required string TipoCliente { get; set; } // Persona / Empresa

        [Required]
        [StringLength(200)]
        public required string Nombre { get; set; }

        [StringLength(255)]
        public string? Url { get; set; }

        [StringLength(50)]
        public string? DocumentoIdentidad { get; set; }

        [StringLength(100)]
        public string? RegistroComercial { get; set; }

        public DateTime? FechaNacimiento { get; set; }

        // Propiedades de navegación para todas las tablas relacionadas
        public virtual ICollection<BeneficiarioFinal> BeneficiariosFinales { get; set; } = new List<BeneficiarioFinal>();
        public virtual ICollection<Intermediario> Intermediarios { get; set; } = new List<Intermediario>();
        public virtual ICollection<Direccion> Direcciones { get; set; } = new List<Direccion>();
        public virtual ICollection<Contacto> Contactos { get; set; } = new List<Contacto>();
        public virtual ICollection<ActividadEconomica> ActividadesEconomicas { get; set; } = new List<ActividadEconomica>();
        public virtual ICollection<PerfilFinanciero> PerfilesFinancieros { get; set; } = new List<PerfilFinanciero>();
        public virtual ICollection<Operacion> Operaciones { get; set; } = new List<Operacion>();
        public virtual ICollection<Transaccion> Transacciones { get; set; } = new List<Transaccion>();
        public virtual ICollection<Referencia> Referencias { get; set; } = new List<Referencia>();
        public virtual ICollection<PersonaExpuestaPoliticamente> PersonasExpuestasPoliticamente { get; set; } = new List<PersonaExpuestaPoliticamente>();
        public virtual ICollection<Responsable> Responsables { get; set; } = new List<Responsable>();
        public virtual ICollection<Evaluacion> Evaluaciones { get; set; } = new List<Evaluacion>();
    }