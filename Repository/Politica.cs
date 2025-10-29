public interface IPolitica
{
    Task<List<PoliticaDto>> obtenerPoliticas();
    Task crearPolitica(CreatePoliticaDto createPoliticaDto);
    Task<bool> actualizarPolitica(long id, CreatePoliticaDto updatePoliticaDto);
    Task<bool> eliminarPolitica(long id);
    Task<PoliticaDto?> obtenerPolitica(long id);
}