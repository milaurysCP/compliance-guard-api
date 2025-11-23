namespace ComplianceGuardPro.Shared.Authorization;

/// <summary>
/// Constantes con los nombres de los roles del sistema
/// </summary>
public static class Roles
{
    /// <summary>
    /// Oficial de Cumplimiento - Todos los permisos incluyendo eliminación
    /// </summary>
    public const string OFICIAL_CUMPLIMIENTO = "OFICIAL_CUMPLIMIENTO";
    
    /// <summary>
    /// Analista - Puede leer, crear y actualizar (no puede eliminar)
    /// </summary>
    public const string ANALISTA = "ANALISTA";
    
    /// <summary>
    /// Técnico - Puede leer, crear y actualizar (no puede eliminar)
    /// </summary>
    public const string TECNICO = "TECNICO";
    
    /// <summary>
    /// Oficial Suplente - Puede leer, crear y actualizar (no puede eliminar)
    /// </summary>
    public const string OFICIAL_SUPLENTE = "OFICIAL_SUPLENTE";
    
    /// <summary>
    /// Todos los roles que pueden realizar operaciones CRUD excepto DELETE
    /// </summary>
    public static readonly string[] TodosLosRoles = new[]
    {
        OFICIAL_CUMPLIMIENTO,
        ANALISTA,
        TECNICO,
        OFICIAL_SUPLENTE
    };
    
    /// <summary>
    /// Solo el Oficial de Cumplimiento puede eliminar
    /// </summary>
    public static readonly string[] SoloOficialCumplimiento = new[]
    {
        OFICIAL_CUMPLIMIENTO
    };
}
