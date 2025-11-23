using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ComplianceGuardPro.Modules.MensajesChat.DTOs;
using ComplianceGuardPro.Modules.MensajesChat.Services;
using ComplianceGuardPro.Shared.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComplianceGuardPro.Modules.MensajesChat.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // [Authorize] // Deshabilitado temporalmente
    public class MensajesChatController : ControllerBase
    {
        private readonly IMensajeChat _mensajeChatService;

        public MensajesChatController(IMensajeChat mensajeChatService)
        {
            _mensajeChatService = mensajeChatService;
        }

        // GET: api/mensajechat
        [HttpGet]
        [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
        public async Task<ActionResult<List<MensajeChatDto>>> GetMensajes()
        {
            var mensajes = await _mensajeChatService.obtenerMensajes();
            return Ok(mensajes);
        }

        // GET: api/mensajechat/usuario/{usuarioId}
        [HttpGet("usuario/{usuarioId}")]
        [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
        public async Task<ActionResult<List<MensajeChatDto>>> GetMensajesPorUsuario(long usuarioId)
        {
            var mensajes = await _mensajeChatService.obtenerMensajesPorUsuario(usuarioId);
            return Ok(mensajes);
        }

        // GET: api/mensajechat/{id}
        [HttpGet("{id}")]
        [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
        public async Task<ActionResult<MensajeChatDto>> GetMensaje(long id)
        {
            var mensaje = await _mensajeChatService.obtenerMensaje(id);
            if (mensaje == null)
            {
                return NotFound();
            }
            return Ok(mensaje);
        }

        // POST: api/mensajechat
        [HttpPost]
        [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
        public async Task<ActionResult> CreateMensaje(CreateMensajeChatDto createMensajeDto)
        {
            await _mensajeChatService.crearMensaje(createMensajeDto);
            return CreatedAtAction(nameof(GetMensaje), new { id = 0 }, createMensajeDto);
        }
    }
}
