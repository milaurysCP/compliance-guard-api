using AutoMapper;
using ComplianceGuardPro.Data;
using Microsoft.EntityFrameworkCore;

public class ContactoImpl : IContacto
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public ContactoImpl(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ContactoDto>> obtenerContactosPorCliente(long clienteId)
    {
        var contactos = await _context.Contactos
            .Where(c => c.ClienteId == clienteId)
            .Select(c => _mapper.Map<ContactoDto>(c))
            .ToListAsync();

        return contactos;
    }

    public async Task crearContacto(CreateContactoDto createContactoDto, long clienteId)
    {
        var contacto = _mapper.Map<Contacto>(createContactoDto);
        contacto.ClienteId = clienteId;

        _context.Contactos.Add(contacto);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> actualizarContacto(long id, CreateContactoDto updateContactoDto)
    {
        var contacto = await _context.Contactos.FindAsync(id);
        if (contacto == null)
        {
            return false;
        }

        _mapper.Map(updateContactoDto, contacto);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> eliminarContacto(long id)
    {
        var contacto = await _context.Contactos.FindAsync(id);
        if (contacto == null)
        {
            return false;
        }

        _context.Contactos.Remove(contacto);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<ContactoDto?> obtenerContacto(long id)
    {
        var contacto = await _context.Contactos.FindAsync(id);

        if (contacto == null)
        {
            return null;
        }

        return _mapper.Map<ContactoDto>(contacto);
    }
}