public interface IPersonaExpuestaPoliticamente
{
    Task<List<PersonaExpuestaPoliticamenteDto>> obtenerPersonasExpuestasPorCliente(long clienteId);
    Task crearPersonaExpuestaPoliticamente(CreatePersonaExpuestaPoliticamenteDto createPersonaDto);
    Task<bool> actualizarPersonaExpuestaPoliticamente(long id, CreatePersonaExpuestaPoliticamenteDto updatePersonaDto);
    Task<bool> eliminarPersonaExpuestaPoliticamente(long id);
    Task<PersonaExpuestaPoliticamenteDto?> obtenerPersonaExpuestaPoliticamente(long id);
}