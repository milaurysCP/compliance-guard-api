public interface IActividadEconomica
{
    Task<List<ActividadEconomicaDto>> obtenerActividadesPorCliente(long clienteId);
    Task crearActividadEconomica(CreateActividadEconomicaDto createActividadDto, long clienteId);
    Task<bool> actualizarActividadEconomica(long id, CreateActividadEconomicaDto updateActividadDto);
    Task<bool> eliminarActividadEconomica(long id);
    Task<ActividadEconomicaDto?> obtenerActividadEconomica(long id);
}