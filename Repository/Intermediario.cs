public interface IIntermediario
{
    Task<List<IntermediarioDto>> obtenerIntermediariosPorCliente(long clienteId);
    Task crearIntermediario(CreateIntermediarioDto createIntermediarioDto);
    Task<bool> actualizarIntermediario(long id, CreateIntermediarioDto updateIntermediarioDto);
    Task<bool> eliminarIntermediario(long id);
    Task<IntermediarioDto?> obtenerIntermediario(long id);
}