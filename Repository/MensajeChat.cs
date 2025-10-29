public interface IMensajeChat
{
    Task<List<MensajeChatDto>> obtenerMensajesPorUsuario(long usuarioId);
    Task<List<MensajeChatDto>> obtenerMensajesRecientes(int limite = 50);
    Task crearMensajeChat(CreateMensajeChatDto createMensajeChatDto);
    Task<bool> eliminarMensajeChat(long id);
    Task<MensajeChatDto?> obtenerMensajeChat(long id);
}