using ComplianceGuardPro.Modules.PerfilesFinancieros.DTOs;

namespace ComplianceGuardPro.Modules.PerfilesFinancieros.Services
{
    public interface IPerfilFinanciero
{
    Task<List<PerfilFinancieroDto>> obtenerPerfilesPorCliente(long clienteId);
    Task crearPerfilFinanciero(CreatePerfilFinancieroDto createPerfilDto);
    Task<bool> actualizarPerfilFinanciero(long id, CreatePerfilFinancieroDto updatePerfilDto);
    Task<bool> eliminarPerfilFinanciero(long id);
    Task<PerfilFinancieroDto?> obtenerPerfilFinanciero(long id);
}}
