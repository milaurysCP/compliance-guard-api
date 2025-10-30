using System.ComponentModel.DataAnnotations;

namespace ComplianceGuardPro.Modules.Usuarios.Models;

public class Rol
    {
        [Key]
        public long Id { get; set; }

        public required string Nombre { get; set; }

        public string? Descripcion { get; set; }

        // Propiedad de navegación: Un rol puede tener muchos usuarios
        public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
