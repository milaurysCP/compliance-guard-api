using ComplianceGuardPro.Modules.Clientes.DTOs;

namespace ComplianceGuardPro.Modules.Clientes.Services;

public interface ICliente
{
    Task<List<ClienteSummaryDto>> obtenerClientes();
    Task crearClienteCompleto(ClienteDto clienteDto);
    Task<bool> actualizarClienteCompleto(long id, ClienteDto clienteDto);
    Task<bool> eliminarCliente(long id);
    Task<List<ClienteSummaryDto>> buscarCliente(string filtro);
    Task<ClienteDto?> obtenerClienteCompleto(long id);
    Task<List<ClienteDto>> buscarClienteCompleto(string filtro);
}