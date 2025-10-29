using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class MensajeChatController : ControllerBase
{
    private readonly IMensajeChat _mensajeChatService;

    public MensajeChatController(IMensajeChat mensajeChatService)
    {
        _mensajeChatService = mensajeChatService;
    }

    [HttpGet("usuario/{usuarioId}")]
    public async Task<IActionResult> ObtenerMensajesPorUsuario(long usuarioId)
    {
        try
        {
            var mensajes = await _mensajeChatService.obtenerMensajesPorUsuario(usuarioId);
            return Ok(mensajes);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
        }
    }

    [HttpGet("recientes")]
    public async Task<IActionResult> ObtenerMensajesRecientes([FromQuery] int limite = 50)
    {
        try
        {
            var mensajes = await _mensajeChatService.obtenerMensajesRecientes(limite);
            return Ok(mensajes);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerMensajeChat(long id)
    {
        try
        {
            var mensaje = await _mensajeChatService.obtenerMensajeChat(id);
            if (mensaje == null)
            {
                return NotFound(new { message = "Mensaje no encontrado" });
            }
            return Ok(mensaje);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> CrearMensajeChat([FromBody] CreateMensajeChatDto createMensajeChatDto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _mensajeChatService.crearMensajeChat(createMensajeChatDto);
            return CreatedAtAction(nameof(ObtenerMensajeChat), new { id = 0 }, createMensajeChatDto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> EliminarMensajeChat(long id)
    {
        try
        {
            var result = await _mensajeChatService.eliminarMensajeChat(id);
            if (!result)
            {
                return NotFound(new { message = "Mensaje no encontrado" });
            }

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
        }
    }
}