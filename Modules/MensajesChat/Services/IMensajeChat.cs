using System.Collections.Generic;
using System.Threading.Tasks;
using ComplianceGuardPro.Modules.MensajesChat.DTOs;

namespace ComplianceGuardPro.Modules.MensajesChat.Services
{
    public interface IMensajeChat
    {
        Task<List<MensajeChatDto>> obtenerMensajes();
        Task<List<MensajeChatDto>> obtenerMensajesPorUsuario(long usuarioId);
        Task crearMensaje(CreateMensajeChatDto createMensajeDto);
        Task<MensajeChatDto?> obtenerMensaje(long id);
    }
}