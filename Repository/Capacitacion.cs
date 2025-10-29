public interface ICapacitacion
{
    Task<List<CapacitacionDto>> obtenerCapacitaciones();
    Task crearCapacitacion(CreateCapacitacionDto createCapacitacionDto);
    Task<bool> actualizarCapacitacion(long id, CreateCapacitacionDto updateCapacitacionDto);
    Task<bool> eliminarCapacitacion(long id);
    Task<CapacitacionDto?> obtenerCapacitacion(long id);
}