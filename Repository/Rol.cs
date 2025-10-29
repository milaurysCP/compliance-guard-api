public interface IRol
{
    Task<List<RolDto>> obtenerRoles();
    Task crearRol(CreateRolDto createRolDto);
    Task<bool> actualizarRol(long id, CreateRolDto updateRolDto);
    Task<bool> eliminarRol(long id);
    Task<RolDto?> obtenerRol(long id);
}