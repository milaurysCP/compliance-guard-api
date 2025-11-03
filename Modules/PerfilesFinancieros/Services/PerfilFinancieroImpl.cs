using AutoMapper;
using ComplianceGuardPro.Data;
using ComplianceGuardPro.Modules.PerfilesFinancieros.DTOs;
using ComplianceGuardPro.Modules.PerfilesFinancieros.Models;
using Microsoft.EntityFrameworkCore;

namespace ComplianceGuardPro.Modules.PerfilesFinancieros.Services
{
    public class PerfilFinancieroImpl : IPerfilFinanciero
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public PerfilFinancieroImpl(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<PerfilFinancieroDto>> obtenerPerfilesPorCliente(long clienteId)
    {
        var perfiles = await _context.PerfilesFinancieros
            .Where(p => p.ClienteId == clienteId)
            .Select(p => _mapper.Map<PerfilFinancieroDto>(p))
            .ToListAsync();

        return perfiles;
    }

    public async Task crearPerfilFinanciero(CreatePerfilFinancieroDto createPerfilDto)
    {
        var perfil = _mapper.Map<PerfilFinanciero>(createPerfilDto);
        // ClienteId is now in the DTO

        _context.PerfilesFinancieros.Add(perfil);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> actualizarPerfilFinanciero(long id, CreatePerfilFinancieroDto updatePerfilDto)
    {
        var perfil = await _context.PerfilesFinancieros.FindAsync(id);
        if (perfil == null)
        {
            return false;
        }

        _mapper.Map(updatePerfilDto, perfil);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> eliminarPerfilFinanciero(long id)
    {
        var perfil = await _context.PerfilesFinancieros.FindAsync(id);
        if (perfil == null)
        {
            return false;
        }

        _context.PerfilesFinancieros.Remove(perfil);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<PerfilFinancieroDto?> obtenerPerfilFinanciero(long id)
    {
        var perfil = await _context.PerfilesFinancieros.FindAsync(id);

        if (perfil == null)
        {
            return null;
        }

        return _mapper.Map<PerfilFinancieroDto>(perfil);
    }
}}
