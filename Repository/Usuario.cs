public interface Iusuario
{
    Task<List<UsuarioDto>> obtenerUsuarios();
    Task crearUsuario(CreateUsuarioDto createUsuarioDto);
    Task<bool> actualizarUsuario(long id, UpdateUsuarioDto updateUsuarioDto);
    Task<bool> actualizarClave(long id, UpdatePasswordDto updatePasswordDto);
    Task<bool> cambiarEstado(long id, CambiarEstadoDto cambiarEstadoDto);
    Task<LoginResponseDto?> autenticarUsuario(LoginDto loginDto);
    Task<DetalleUsuarioDto?> obtenerDetalleUsuario(long id);

}