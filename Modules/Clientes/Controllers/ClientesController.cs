using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ComplianceGuardPro.Modules.Clientes.DTOs;
using ComplianceGuardPro.Modules.Clientes.Services;

namespace ComplianceGuardPro.Modules.Clientes.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ClientesController : ControllerBase
{
    private readonly ICliente _clienteService;

    public ClientesController(ICliente clienteService)
    {
        _clienteService = clienteService;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerClientes()
    {
        var clientes = await _clienteService.obtenerClientes();
        return Ok(clientes);
    }

    [HttpPost]
    public async Task<IActionResult> CrearCliente([FromBody] CreateClienteDto crearClienteDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _clienteService.crearCliente(crearClienteDto);
        return Ok(new { message = "Cliente creado exitosamente" });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> ActualizarCliente(long id, [FromBody] UpdateClienteDto actualizarClienteDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var resultado = await _clienteService.actualizarCliente(id, actualizarClienteDto);
        if (!resultado)
        {
            return NotFound(new { message = "Cliente no encontrado" });
        }

        return Ok(new { message = "Cliente actualizado exitosamente" });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> EliminarCliente(long id)
    {
        var resultado = await _clienteService.eliminarCliente(id);
        if (!resultado)
        {
            return NotFound(new { message = "Cliente no encontrado" });
        }

        return Ok(new { message = "Cliente eliminado exitosamente" });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerDetalleCliente(long id)
    {
        var cliente = await _clienteService.obtenerDetalleCliente(id);
        if (cliente == null)
        {
            return NotFound(new { message = "Cliente no encontrado" });
        }
        return Ok(cliente);
    }

    [HttpGet("{id}/detalle")]
    public async Task<IActionResult> ObtenerClienteConDetalle(long id)
    {
        var cliente = await _clienteService.obtenerDetalleCliente(id);
        if (cliente == null)
        {
            return NotFound(new { message = "Cliente no encontrado" });
        }
        return Ok(cliente);
    }
}