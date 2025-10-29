public interface IRiesgo
{
    Task<List<RiesgoDto>> obtenerRiesgos();
    Task crearRiesgo(CreateRiesgoDto createRiesgoDto);
    Task<bool> actualizarRiesgo(long id, CreateRiesgoDto updateRiesgoDto);
    Task<bool> eliminarRiesgo(long id);
    Task<RiesgoDto?> obtenerRiesgo(long id);
}