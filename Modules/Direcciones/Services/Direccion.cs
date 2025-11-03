using ComplianceGuardPro.Modules.Direcciones.DTOs;

namespace ComplianceGuardPro.Modules.Direcciones.Services;

public interface IDireccion
{
    Task<List<DireccionDto>> obtenerDireccionesPorCliente(long clienteId);
    Task crearDireccion(CreateDireccionDto createDireccionDto);
    Task<bool> actualizarDireccion(long id, CreateDireccionDto updateDireccionDto);
    Task<bool> eliminarDireccion(long id);
    Task<DireccionDto?> obtenerDireccion(long id);
}