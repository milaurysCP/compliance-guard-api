using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ComplianceGuardPro.Modules.Clientes.DTOs;
using ComplianceGuardPro.Modules.Clientes.Services;
using ComplianceGuardPro.Shared.Authorization;

namespace ComplianceGuardPro.Modules.Clientes.Controllers;

[ApiController]
[Route("api/[controller]")]
    // [Authorize] // Deshabilitado temporalmente
public class ClientesController : ControllerBase
{
    private readonly ICliente _clienteService;

    public ClientesController(ICliente clienteService)
    {
        _clienteService = clienteService;
    }

    [HttpGet]
    [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
    public async Task<IActionResult> ObtenerClientes()
    {
        var clientes = await _clienteService.obtenerClientes();
        return Ok(clientes);
    }

    [HttpGet("buscar")]
    [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
    public async Task<IActionResult> BuscarCliente([FromQuery] string filtro)
    {
        if (string.IsNullOrWhiteSpace(filtro))
        {
            return BadRequest(new { message = "El filtro de búsqueda es requerido" });
        }

        var clientes = await _clienteService.buscarClienteCompleto(filtro);
        return Ok(clientes);
    }

    [HttpPost]
    [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
    public async Task<IActionResult> CrearCliente([FromBody] ClienteDto clienteDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await _clienteService.crearClienteCompleto(clienteDto);
            return Ok(new { message = "Cliente creado exitosamente" });
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { message = ex.Message });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("{id}")]
    [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
    public async Task<IActionResult> ActualizarCliente(long id, [FromBody] ClienteDto clienteDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var resultado = await _clienteService.actualizarClienteCompleto(id, clienteDto);
            if (!resultado)
            {
                return NotFound(new { message = "Cliente no encontrado" });
            }

            return Ok(new { message = "Cliente actualizado correctamente" });
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { message = ex.Message });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO)]
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
    [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
    public async Task<IActionResult> ObtenerDetalleCliente(long id)
    {
        var cliente = await _clienteService.obtenerClienteCompleto(id);
        if (cliente == null)
        {
            return NotFound(new { message = "Cliente no encontrado" });
        }
        return Ok(cliente);
    }
}
