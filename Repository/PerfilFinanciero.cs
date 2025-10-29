public interface IPerfilFinanciero
{
    Task<List<PerfilFinancieroDto>> obtenerPerfilesPorCliente(long clienteId);
    Task crearPerfilFinanciero(CreatePerfilFinancieroDto createPerfilDto, long clienteId);
    Task<bool> actualizarPerfilFinanciero(long id, CreatePerfilFinancieroDto updatePerfilDto);
    Task<bool> eliminarPerfilFinanciero(long id);
    Task<PerfilFinancieroDto?> obtenerPerfilFinanciero(long id);
}