using AutoMapper;
using ComplianceGuardPro.Data;
using ComplianceGuardPro.Modules.MensajesChat.DTOs;
using ComplianceGuardPro.Modules.MensajesChat.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplianceGuardPro.Modules.MensajesChat.Services
{
    public class MensajeChatImpl : IMensajeChat
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public MensajeChatImpl(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<MensajeChatDto>> obtenerMensajes()
        {
            var mensajes = await _context.MensajesChat
                .Include(m => m.Usuario)
                .OrderByDescending(m => m.FechaEnvio)
                .Take(50) // Limitar a los 50 mensajes más recientes
                .Select(m => new MensajeChatDto
                {
                    Id = m.Id,
                    UsuarioId = m.UsuarioId,
                    Mensaje = m.Mensaje,
                    FechaEnvio = m.FechaEnvio,
                    UsuarioNombre = m.Usuario.Nombre
                })
                .ToListAsync();

            return mensajes;
        }

        public async Task<List<MensajeChatDto>> obtenerMensajesPorUsuario(long usuarioId)
        {
            var mensajes = await _context.MensajesChat
                .Include(m => m.Usuario)
                .Where(m => m.UsuarioId == usuarioId)
                .OrderByDescending(m => m.FechaEnvio)
                .Select(m => new MensajeChatDto
                {
                    Id = m.Id,
                    UsuarioId = m.UsuarioId,
                    Mensaje = m.Mensaje,
                    FechaEnvio = m.FechaEnvio,
                    UsuarioNombre = m.Usuario.Nombre
                })
                .ToListAsync();

            return mensajes;
        }

        public async Task crearMensaje(CreateMensajeChatDto createMensajeDto)
        {
            var mensaje = _mapper.Map<MensajeChat>(createMensajeDto);
            _context.MensajesChat.Add(mensaje);
            await _context.SaveChangesAsync();
        }

        public async Task<MensajeChatDto?> obtenerMensaje(long id)
        {
            var mensaje = await _context.MensajesChat
                .Include(m => m.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (mensaje == null)
            {
                return null;
            }

            return new MensajeChatDto
            {
                Id = mensaje.Id,
                UsuarioId = mensaje.UsuarioId,
                Mensaje = mensaje.Mensaje,
                FechaEnvio = mensaje.FechaEnvio,
                UsuarioNombre = mensaje.Usuario.Nombre
            };
        }
    }
}