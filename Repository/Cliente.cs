public interface ICliente
{
    Task<List<ClienteSummaryDto>> obtenerClientes();
    Task crearCliente(CreateClienteDto createClienteDto);
    Task<bool> actualizarCliente(long id, UpdateClienteDto updateClienteDto);
    Task<ClienteDetailDto?> obtenerDetalleCliente(long id);
}