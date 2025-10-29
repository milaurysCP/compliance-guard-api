public interface IEvaluacion
{
    Task<List<EvaluacionDto>> obtenerEvaluacionesPorCliente(long clienteId);
    Task<List<EvaluacionDto>> obtenerEvaluacionesPorRiesgo(long riesgoId);
    Task crearEvaluacion(CreateEvaluacionDto createEvaluacionDto);
    Task<bool> actualizarEvaluacion(long id, CreateEvaluacionDto updateEvaluacionDto);
    Task<bool> eliminarEvaluacion(long id);
    Task<EvaluacionDto?> obtenerEvaluacion(long id);
}