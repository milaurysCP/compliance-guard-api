public interface IResponsable
{
    Task<List<ResponsableDto>> obtenerResponsablesPorCliente(long clienteId);
    Task crearResponsable(CreateResponsableDto createResponsableDto);
    Task<bool> actualizarResponsable(long id, CreateResponsableDto updateResponsableDto);
    Task<bool> eliminarResponsable(long id);
    Task<ResponsableDto?> obtenerResponsable(long id);
}