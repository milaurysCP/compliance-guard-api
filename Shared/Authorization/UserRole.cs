namespace ComplianceGuardPro.Shared.Authorization;

/// <summary>
/// Define los roles de usuario en el sistema
/// </summary>
public enum UserRole
{
    /// <summary>
    /// Oficial de Cumplimiento - Todos los permisos incluyendo eliminación
    /// </summary>
    OFICIAL_CUMPLIMIENTO,
    
    /// <summary>
    /// Analista - Puede leer, crear y actualizar (no puede eliminar)
    /// </summary>
    ANALISTA,
    
    /// <summary>
    /// Técnico - Puede leer, crear y actualizar (no puede eliminar)
    /// </summary>
    TECNICO,
    
    /// <summary>
    /// Oficial Suplente - Puede leer, crear y actualizar (no puede eliminar)
    /// </summary>
    OFICIAL_SUPLENTE
}
