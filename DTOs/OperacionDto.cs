using System.ComponentModel.DataAnnotations;

public class OperacionDto
    {
        public long Id { get; set; }
        public string? Tipo { get; set; }
        public string? Codigo { get; set; }
        public long ClienteId { get; set; }
        public ICollection<PagoDto> Pagos { get; set; } = new List<PagoDto>();
    }

    public class CreateOperacionDto
    {
        [Required]
        public long ClienteId { get; set; }
        
        [Required]
        [StringLength(100)]
        public required string Tipo { get; set; }

        [StringLength(50)]
        public string? Codigo { get; set; }
        
        // Crear pagos junto con la operación
        public List<CreatePagoDto>? Pagos { get; set; }
    }


