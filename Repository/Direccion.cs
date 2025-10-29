public interface IDireccion
{
    Task<List<DireccionDto>> obtenerDireccionesPorCliente(long clienteId);
    Task crearDireccion(CreateDireccionDto createDireccionDto, long clienteId);
    Task<bool> actualizarDireccion(long id, CreateDireccionDto updateDireccionDto);
    Task<bool> eliminarDireccion(long id);
    Task<DireccionDto?> obtenerDireccion(long id);
}