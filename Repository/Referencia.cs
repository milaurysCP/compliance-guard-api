public interface IReferencia
{
    Task<List<ReferenciaDto>> obtenerReferenciasPorCliente(long clienteId);
    Task crearReferencia(CreateReferenciaDto createReferenciaDto);
    Task<bool> actualizarReferencia(long id, CreateReferenciaDto updateReferenciaDto);
    Task<bool> eliminarReferencia(long id);
    Task<ReferenciaDto?> obtenerReferencia(long id);
}