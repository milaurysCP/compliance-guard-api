using AutoMapper;
using ComplianceGuardPro.Data;
using ComplianceGuardPro.Modules.Clientes.DTOs;
using ComplianceGuardPro.Modules.Clientes.Models;
using ComplianceGuardPro.Modules.Direcciones.Models;
using ComplianceGuardPro.Modules.Contactos.Models;
using ComplianceGuardPro.Modules.Beneficiarios.Models;
using ComplianceGuardPro.Modules.Intermediarios.Models;
using Microsoft.EntityFrameworkCore;

namespace ComplianceGuardPro.Modules.Clientes.Services;

public class ClienteImpl : ICliente
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public ClienteImpl(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ClienteSummaryDto>> obtenerClientes()
    {
        var clientes = await _context.Clientes
            .Select(c => _mapper.Map<ClienteSummaryDto>(c))
            .ToListAsync();

        return clientes;
    }

    public async Task crearCliente(CreateClienteDto createClienteDto)
    {
        var cliente = _mapper.Map<Cliente>(createClienteDto);

        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync(); // Guardar primero para obtener el ID

        // Crear direcciones asociadas si existen
        if (createClienteDto.Direcciones != null && createClienteDto.Direcciones.Any())
        {
            foreach (var direccionDto in createClienteDto.Direcciones)
            {
                var direccion = _mapper.Map<Direccion>(direccionDto);
                direccion.ClienteId = cliente.Id;
                _context.Direcciones.Add(direccion);
            }
        }

        // Crear contactos asociados si existen
        if (createClienteDto.Contactos != null && createClienteDto.Contactos.Any())
        {
            foreach (var contactoDto in createClienteDto.Contactos)
            {
                var contacto = _mapper.Map<Contacto>(contactoDto);
                contacto.ClienteId = cliente.Id;
                _context.Contactos.Add(contacto);
            }
        }

        await _context.SaveChangesAsync();
    }

    public async Task<bool> actualizarCliente(long id, UpdateClienteDto updateClienteDto)
    {
        var cliente = await _context.Clientes.FindAsync(id);
        if (cliente == null)
        {
            return false;
        }

        _mapper.Map(updateClienteDto, cliente);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<ClienteDetailDto?> obtenerDetalleCliente(long id)
    {
        var cliente = await _context.Clientes
            .Include(c => c.Direcciones)
            .Include(c => c.Contactos)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (cliente == null)
        {
            return null;
        }

        return _mapper.Map<ClienteDetailDto>(cliente);
    }
}