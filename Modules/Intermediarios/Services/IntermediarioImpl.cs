using AutoMapper;
using ComplianceGuardPro.Data;
using ComplianceGuardPro.Modules.Intermediarios.DTOs;
using ComplianceGuardPro.Modules.Intermediarios.Models;
using Microsoft.EntityFrameworkCore;

namespace ComplianceGuardPro.Modules.Intermediarios.Services
{
    public class IntermediarioImpl : IIntermediario
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public IntermediarioImpl(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<IntermediarioDto>> obtenerIntermediariosPorCliente(long clienteId)
    {
        var intermediarios = await _context.Intermediarios
            .Where(i => i.ClienteId == clienteId)
            .Select(i => _mapper.Map<IntermediarioDto>(i))
            .ToListAsync();

        return intermediarios;
    }

    public async Task crearIntermediario(CreateIntermediarioDto createIntermediarioDto)
    {
        var intermediario = _mapper.Map<Intermediario>(createIntermediarioDto);

        _context.Intermediarios.Add(intermediario);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> actualizarIntermediario(long id, CreateIntermediarioDto updateIntermediarioDto)
    {
        var intermediario = await _context.Intermediarios.FindAsync(id);
        if (intermediario == null)
        {
            return false;
        }

        _mapper.Map(updateIntermediarioDto, intermediario);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> eliminarIntermediario(long id)
    {
        var intermediario = await _context.Intermediarios.FindAsync(id);
        if (intermediario == null)
        {
            return false;
        }

        _context.Intermediarios.Remove(intermediario);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<IntermediarioDto?> obtenerIntermediario(long id)
    {
        var intermediario = await _context.Intermediarios.FindAsync(id);

        if (intermediario == null)
        {
            return null;
        }

        return _mapper.Map<IntermediarioDto>(intermediario);
    }
}}
