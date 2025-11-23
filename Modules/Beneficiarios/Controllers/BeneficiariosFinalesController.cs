using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ComplianceGuardPro.Modules.Beneficiarios.DTOs;
using ComplianceGuardPro.Modules.Beneficiarios.Services;

namespace ComplianceGuardPro.Modules.Beneficiarios.Controllers;

[Route("api/[controller]")]
[ApiController]
    // [Authorize] // Deshabilitado temporalmente
public class BeneficiariosFinalesController : ControllerBase
{
    private readonly IBeneficiarioFinal _beneficiarioService;

    public BeneficiariosFinalesController(IBeneficiarioFinal beneficiarioService)
    {
        _beneficiarioService = beneficiarioService;
    }

    [HttpGet("cliente/{clienteId}")]
    public async Task<IActionResult> ObtenerBeneficiariosPorCliente(long clienteId)
    {
        var beneficiarios = await _beneficiarioService.obtenerBeneficiariosPorCliente(clienteId);
        return Ok(beneficiarios);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerBeneficiarioFinal(long id)
    {
        var beneficiario = await _beneficiarioService.obtenerBeneficiarioFinal(id);
        if (beneficiario == null)
        {
            return NotFound(new { message = "Beneficiario final no encontrado" });
        }
        return Ok(beneficiario);
    }

    [HttpPost]
    public async Task<IActionResult> CrearBeneficiarioFinal([FromBody] CreateBeneficiarioFinalDto crearBeneficiarioDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _beneficiarioService.crearBeneficiarioFinal(crearBeneficiarioDto);
        return Ok(new { message = "Beneficiario final creado exitosamente" });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> ActualizarBeneficiarioFinal(long id, [FromBody] CreateBeneficiarioFinalDto actualizarBeneficiarioDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var resultado = await _beneficiarioService.actualizarBeneficiarioFinal(id, actualizarBeneficiarioDto);
        if (!resultado)
        {
            return NotFound(new { message = "Beneficiario final no encontrado" });
        }

        return Ok(new { message = "Beneficiario final actualizado exitosamente" });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> EliminarBeneficiarioFinal(long id)
    {
        var resultado = await _beneficiarioService.eliminarBeneficiarioFinal(id);
        if (!resultado)
        {
            return NotFound(new { message = "Beneficiario final no encontrado" });
        }

        return Ok(new { message = "Beneficiario final eliminado exitosamente" });
    }
}
