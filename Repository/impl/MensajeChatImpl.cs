using AutoMapper;
using ComplianceGuardPro.Data;
using Microsoft.EntityFrameworkCore;

public class MensajeChatImpl : IMensajeChat
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public MensajeChatImpl(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<MensajeChatDto>> obtenerMensajesPorUsuario(long usuarioId)
    {
        var mensajes = await _context.MensajesChat
            .Where(m => m.UsuarioId == usuarioId)
            .OrderByDescending(m => m.FechaEnvio)
            .Select(m => _mapper.Map<MensajeChatDto>(m))
            .ToListAsync();

        return mensajes;
    }

    public async Task<List<MensajeChatDto>> obtenerMensajesRecientes(int limite = 50)
    {
        var mensajes = await _context.MensajesChat
            .OrderByDescending(m => m.FechaEnvio)
            .Take(limite)
            .Select(m => _mapper.Map<MensajeChatDto>(m))
            .ToListAsync();

        return mensajes;
    }

    public async Task crearMensajeChat(CreateMensajeChatDto createMensajeChatDto)
    {
        var mensaje = _mapper.Map<MensajeChat>(createMensajeChatDto);
        mensaje.FechaEnvio = DateTime.Now;

        _context.MensajesChat.Add(mensaje);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> eliminarMensajeChat(long id)
    {
        var mensaje = await _context.MensajesChat.FindAsync(id);
        if (mensaje == null)
        {
            return false;
        }

        _context.MensajesChat.Remove(mensaje);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<MensajeChatDto?> obtenerMensajeChat(long id)
    {
        var mensaje = await _context.MensajesChat.FindAsync(id);

        if (mensaje == null)
        {
            return null;
        }

        return _mapper.Map<MensajeChatDto>(mensaje);
    }
}