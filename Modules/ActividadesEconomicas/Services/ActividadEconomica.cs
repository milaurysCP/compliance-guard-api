using ComplianceGuardPro.Modules.ActividadesEconomicas.DTOs;

namespace ComplianceGuardPro.Modules.ActividadesEconomicas.Services
{
    public interface IActividadEconomica
{
    Task<List<ActividadEconomicaDto>> obtenerActividadesPorCliente(long clienteId);
    Task crearActividadEconomica(CreateActividadEconomicaDto createActividadDto);
    Task<bool> actualizarActividadEconomica(long id, CreateActividadEconomicaDto updateActividadDto);
    Task<bool> eliminarActividadEconomica(long id);
    Task<ActividadEconomicaDto?> obtenerActividadEconomica(long id);
}}
