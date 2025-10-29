public interface ITransaccion
{
    Task<List<TransaccionDto>> obtenerTransaccionesPorCliente(long clienteId);
    Task crearTransaccion(CreateTransaccionDto createTransaccionDto);
    Task<bool> actualizarTransaccion(long id, CreateTransaccionDto updateTransaccionDto);
    Task<bool> eliminarTransaccion(long id);
    Task<TransaccionDto?> obtenerTransaccion(long id);
}