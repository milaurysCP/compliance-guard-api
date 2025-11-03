using AutoMapper;
using ComplianceGuardPro.Data;
using ComplianceGuardPro.Modules.ActividadesEconomicas.DTOs;
using ComplianceGuardPro.Modules.ActividadesEconomicas.Models;
using Microsoft.EntityFrameworkCore;

namespace ComplianceGuardPro.Modules.ActividadesEconomicas.Services
{
    public class ActividadEconomicaImpl : IActividadEconomica
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public ActividadEconomicaImpl(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ActividadEconomicaDto>> obtenerActividadesPorCliente(long clienteId)
    {
        var actividades = await _context.ActividadesEconomicas
            .Where(a => a.ClienteId == clienteId)
            .Select(a => _mapper.Map<ActividadEconomicaDto>(a))
            .ToListAsync();

        return actividades;
    }

    public async Task crearActividadEconomica(CreateActividadEconomicaDto createActividadDto)
    {
        var actividad = _mapper.Map<ActividadEconomica>(createActividadDto);
        // ClienteId is now in the DTO

        _context.ActividadesEconomicas.Add(actividad);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> actualizarActividadEconomica(long id, CreateActividadEconomicaDto updateActividadDto)
    {
        var actividad = await _context.ActividadesEconomicas.FindAsync(id);
        if (actividad == null)
        {
            return false;
        }

        _mapper.Map(updateActividadDto, actividad);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> eliminarActividadEconomica(long id)
    {
        var actividad = await _context.ActividadesEconomicas.FindAsync(id);
        if (actividad == null)
        {
            return false;
        }

        _context.ActividadesEconomicas.Remove(actividad);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<ActividadEconomicaDto?> obtenerActividadEconomica(long id)
    {
        var actividad = await _context.ActividadesEconomicas.FindAsync(id);

        if (actividad == null)
        {
            return null;
        }

        return _mapper.Map<ActividadEconomicaDto>(actividad);
    }
}}
