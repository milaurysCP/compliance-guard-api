using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ComplianceGuardPro.Shared.Authorization;

/// <summary>
/// Atributo de autorización basado en roles
/// Valida que el usuario tenga uno de los roles permitidos para acceder a la ruta
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
public class RoleAuthorizeAttribute : Attribute, IAuthorizationFilter
{
    private readonly string[] _allowedRoles;

    /// <summary>
    /// Constructor que acepta los roles permitidos
    /// </summary>
    /// <param name="roles">Array de roles permitidos (OFICIAL_CUMPLIMIENTO, ANALISTA, TECNICO, OFICIAL_SUPLENTE)</param>
    public RoleAuthorizeAttribute(params string[] roles)
    {
        _allowedRoles = roles;
    }

    /// <summary>
    /// Método que se ejecuta antes de procesar la petición
    /// Valida si el usuario tiene un rol permitido
    /// </summary>
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        // Verificar si el usuario está autenticado
        var user = context.HttpContext.User;

        if (!user.Identity?.IsAuthenticated ?? true)
        {
            context.Result = new UnauthorizedObjectResult(new 
            { 
                message = "Usuario no autenticado",
                error = "UNAUTHORIZED"
            });
            return;
        }

        // Obtener el rol del claim del JWT
        var userRole = user.FindFirst(System.Security.Claims.ClaimTypes.Role)?.Value;

        if (string.IsNullOrEmpty(userRole))
        {
            context.Result = new UnauthorizedObjectResult(new 
            { 
                message = "No se encontró el rol del usuario en el token",
                error = "MISSING_ROLE"
            });
            return;
        }

        // Validar si el rol del usuario está en la lista de roles permitidos
        if (!_allowedRoles.Contains(userRole, StringComparer.OrdinalIgnoreCase))
        {
            context.Result = new ObjectResult(new 
            { 
                message = $"No tiene permisos suficientes. Se requiere uno de los siguientes roles: {string.Join(", ", _allowedRoles)}",
                error = "FORBIDDEN",
                userRole = userRole,
                requiredRoles = _allowedRoles
            })
            {
                StatusCode = 403
            };
            return;
        }

        // Usuario autorizado, continuar con la petición
    }
}
