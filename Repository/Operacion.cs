public interface IOperacion
{
    Task<List<OperacionDto>> obtenerOperacionesPorCliente(long clienteId);
    Task crearOperacion(CreateOperacionDto createOperacionDto);
    Task<bool> actualizarOperacion(long id, CreateOperacionDto updateOperacionDto);
    Task<bool> eliminarOperacion(long id);
    Task<OperacionDto?> obtenerOperacion(long id);
}