using System.ComponentModel.DataAnnotations;

public class Politica
    {
        [Key]
        public long Id { get; set; }

        [StringLength(200)]
        public string? Nombre { get; set; }

        [StringLength(255)]
        public string? Descripcion { get; set; }

        public DateTime FechaCreacion { get; set; }
    }