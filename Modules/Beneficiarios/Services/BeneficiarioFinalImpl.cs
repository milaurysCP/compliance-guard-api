using AutoMapper;
using ComplianceGuardPro.Data;
using ComplianceGuardPro.Modules.Beneficiarios.DTOs;
using ComplianceGuardPro.Modules.Beneficiarios.Models;
using Microsoft.EntityFrameworkCore;

namespace ComplianceGuardPro.Modules.Beneficiarios.Services;

public class BeneficiarioFinalImpl : IBeneficiarioFinal
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public BeneficiarioFinalImpl(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<BeneficiarioFinalDto>> obtenerBeneficiariosPorCliente(long clienteId)
    {
        var beneficiarios = await _context.BeneficiariosFinales
            .Where(b => b.ClienteId == clienteId)
            .Select(b => _mapper.Map<BeneficiarioFinalDto>(b))
            .ToListAsync();

        return beneficiarios;
    }

    public async Task crearBeneficiarioFinal(CreateBeneficiarioFinalDto createBeneficiarioDto)
    {
        var beneficiario = _mapper.Map<BeneficiarioFinal>(createBeneficiarioDto);

        _context.BeneficiariosFinales.Add(beneficiario);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> actualizarBeneficiarioFinal(long id, CreateBeneficiarioFinalDto updateBeneficiarioDto)
    {
        var beneficiario = await _context.BeneficiariosFinales.FindAsync(id);
        if (beneficiario == null)
        {
            return false;
        }

        _mapper.Map(updateBeneficiarioDto, beneficiario);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> eliminarBeneficiarioFinal(long id)
    {
        var beneficiario = await _context.BeneficiariosFinales.FindAsync(id);
        if (beneficiario == null)
        {
            return false;
        }

        _context.BeneficiariosFinales.Remove(beneficiario);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<BeneficiarioFinalDto?> obtenerBeneficiarioFinal(long id)
    {
        var beneficiario = await _context.BeneficiariosFinales.FindAsync(id);

        if (beneficiario == null)
        {
            return null;
        }

        return _mapper.Map<BeneficiarioFinalDto>(beneficiario);
    }
}