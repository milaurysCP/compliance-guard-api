public interface IProgresoCapacitacion
{
    Task<List<ProgresoCapacitacionDto>> obtenerProgresoPorUsuario(long usuarioId);
    Task<List<ProgresoCapacitacionDto>> obtenerProgresoPorCapacitacion(long capacitacionId);
    Task crearProgresoCapacitacion(CreateProgresoCapacitacionDto createProgresoCapacitacionDto);
    Task<bool> actualizarProgresoCapacitacion(long id, CreateProgresoCapacitacionDto updateProgresoCapacitacionDto);
    Task<bool> eliminarProgresoCapacitacion(long id);
    Task<ProgresoCapacitacionDto?> obtenerProgresoCapacitacion(long id);
}