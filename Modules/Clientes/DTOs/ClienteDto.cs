using System.ComponentModel.DataAnnotations;
using ComplianceGuardPro.Modules.Direcciones.DTOs;
using ComplianceGuardPro.Modules.Contactos.DTOs;
using ComplianceGuardPro.Modules.Beneficiarios.DTOs;
using ComplianceGuardPro.Modules.Intermediarios.DTOs;
using ComplianceGuardPro.Modules.ActividadesEconomicas.DTOs;
using ComplianceGuardPro.Modules.PerfilesFinancieros.DTOs;

namespace ComplianceGuardPro.Modules.Clientes.DTOs;

// ============================================
// DTOs ANIDADOS PARA CREAR CLIENTE
// ============================================

public class DatosBasicosDto
{
    public long? Id { get; set; }
    public string? Nombre { get; set; }
    public string? TipoPersona { get; set; }
    public string? Siglas { get; set; }
    public string? DocumentoIdentidad { get; set; }
    public DateTime? FechaCreacion { get; set; }
    public string? Rnc { get; set; }
    public string? RegistroMercantil { get; set; }
    public string? CasaMatriz { get; set; }
}

public class DireccionDto
{
    public long? Id { get; set; }
    public string? Calle { get; set; }
    public string? Numero { get; set; }
    public string? Sector { get; set; }
    public string? CodigoPostal { get; set; }
    public string? Pais { get; set; }
    public string? Provincia { get; set; }
    public string? Municipio { get; set; }
}

public class ContactoDto
{
    public long? Id { get; set; }
    public string? TipoContacto { get; set; }
    public string? ValorContacto { get; set; }
}

public class ActividadEconomicaDto
{
    public long? Id { get; set; }
    public string? Sector { get; set; }
    public string? CampoLaboral { get; set; }
    public string? OrigenFondos { get; set; }
}

public class SOFinancieroDto
{
    public long? Id { get; set; }
    public string? TipoSOFinanciero { get; set; }
    public string? NombreSOFinanciero { get; set; }
    public string? ApellidosSOFinanciero { get; set; }
    public string? IdentificacionSOFinanciero { get; set; }
    public string? NacionalidadSOFinanciero { get; set; }
}

public class PerfilFinancieroDto
{
    public long? Id { get; set; }
    public string? Ningreso { get; set; }
    public string? Fuentes { get; set; }
}

public class OperacionesDto
{
    public long? Id { get; set; }
    public string? TipoOperacion { get; set; }
    public string? EndidadFinanciera { get; set; }
    public string? CodigoOperacion { get; set; }
    public string? DescripcionOperacion { get; set; }
    public string? PropositoOperacion { get; set; }
    public decimal Monto { get; set; }
}

public class PagosDto
{
    public long? Id { get; set; }
    public string? Moneda { get; set; }
    public string? TipoPago { get; set; }
    public string? CodigoPago { get; set; }
    public decimal Monto { get; set; }
}

public class PepsDto
{
    public long? Id { get; set; }
    public string? CargoPeps { get; set; }
    public string? TipoPeps { get; set; }
    public string? NombrePeps { get; set; }
    public string? Decreto { get; set; }
    public string? InstitucionPeps { get; set; }
}

public class ResponsableDto
{
    public long? Id { get; set; }
    public string? ResponsableTransaccion { get; set; }
    public string? NombresResposable { get; set; }
    public string? ApellidosResponsable { get; set; }
    public string? DireccionResponsable { get; set; }
    public string? IdentificacionResponsable { get; set; }
    public string? Correo { get; set; }
    public string? Telefono { get; set; }
    public string? Cargo { get; set; }
}

// ============================================
// DTO PRINCIPAL PARA CREAR CLIENTE
// ============================================

public class ClienteDto
{
    public DatosBasicosDto? DatosBasicos { get; set; }
    public DireccionDto? Direccion { get; set; }
    public List<ContactoDto>? Contactos { get; set; }
    public ActividadEconomicaDto? ActividadEconomica { get; set; }
    public List<SOFinancieroDto>? SOFinanciero { get; set; }
    public List<PerfilFinancieroDto>? PerfilFinanciero { get; set; }
    public OperacionesDto? Operaciones { get; set; }
    public PagosDto? Pagos { get; set; }
    public PepsDto? Peps { get; set; }
    public ResponsableDto? Responsable { get; set; }
}

// ============================================
// DTO RESUMIDO PARA LISTADOS
// ============================================
public class ClienteSummaryDto
{
    public long Id { get; set; }
    public string? TipoPersona { get; set; }
    public string? Nombre { get; set; }
    public string? DocumentoIdentidad { get; set; }
}