using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ComplianceGuardPro.Modules.Transacciones.DTOs;
using ComplianceGuardPro.Modules.Transacciones.Services;

namespace ComplianceGuardPro.Modules.Transacciones.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TransaccionController : ControllerBase
    {
        private readonly ITransaccion _transaccionService;

        public TransaccionController(ITransaccion transaccionService)
        {
            _transaccionService = transaccionService;
        }

    [HttpGet("cliente/{clienteId}")]
    public async Task<IActionResult> ObtenerTransaccionesPorCliente(long clienteId)
    {
        var transacciones = await _transaccionService.obtenerTransaccionesPorCliente(clienteId);
        return Ok(transacciones);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerTransaccion(long id)
    {
        var transaccion = await _transaccionService.obtenerTransaccion(id);
        if (transaccion == null)
        {
            return NotFound(new { message = "Transacción no encontrada" });
        }
        return Ok(transaccion);
    }

    [HttpPost]
    public async Task<IActionResult> CrearTransaccion([FromBody] CreateTransaccionDto crearTransaccionDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _transaccionService.crearTransaccion(crearTransaccionDto);
        return Ok(new { message = "Transacción creada exitosamente" });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> ActualizarTransaccion(long id, [FromBody] CreateTransaccionDto actualizarTransaccionDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var resultado = await _transaccionService.actualizarTransaccion(id, actualizarTransaccionDto);
        if (!resultado)
        {
            return NotFound(new { message = "Transacción no encontrada" });
        }

        return Ok(new { message = "Transacción actualizada exitosamente" });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> EliminarTransaccion(long id)
    {
        var resultado = await _transaccionService.eliminarTransaccion(id);
        if (!resultado)
        {
            return NotFound(new { message = "Transacción no encontrada" });
        }

        return Ok(new { message = "Transacción eliminada exitosamente" });
    }
}
}