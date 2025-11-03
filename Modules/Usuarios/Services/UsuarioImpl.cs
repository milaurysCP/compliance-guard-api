

using AutoMapper;
using ComplianceGuardPro.Data;
using ComplianceGuardPro.Modules.Usuarios.DTOs;
using ComplianceGuardPro.Modules.Usuarios.Models;
using ComplianceGuardPro.Shared.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace ComplianceGuardPro.Modules.Usuarios.Services;

public class UsuarioImpl : Iusuario
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    private readonly JwtService _jwtService;

    private readonly PasswordService _passwordService = new();

    public UsuarioImpl(AppDbContext context, IMapper mapper, JwtService jwtService)
    {
        _context = context;
        _mapper = mapper;
        _jwtService = jwtService;
    }

    public async Task<bool> actualizarClave(long id, UpdatePasswordDto updatePasswordDto)
    {
        var usuario = await _context.Usuarios.FindAsync(id);
        if (usuario == null)
        {
            return false;
        }

        usuario.ClaveHash = _passwordService.HashPassword(updatePasswordDto.NuevaClave);

        _context.Usuarios.Update(usuario);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> actualizarUsuario(long id, UpdateUsuarioDto updateUsuarioDto)
    {
        var usuario = await _context.Usuarios.FindAsync(id);
        if (usuario == null)
        {
            return false;
        }

        usuario.Nombre = updateUsuarioDto.Nombre;
        usuario.RolId = updateUsuarioDto.RolId;

        _context.Usuarios.Update(usuario);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<LoginResponseDto?> autenticarUsuario(LoginDto loginDto)
    {
        var usuario = await _context.Usuarios
            .Include(u => u.Rol)
            .FirstOrDefaultAsync(u => u.UsuarioLogin == loginDto.UsuarioLogin && u.EstaActivo);

        if (usuario == null)
        {
            return null; // Usuario no encontrado o inactivo
        }

        // Verificar la contraseña
        if (!_passwordService.VerifyPassword(usuario.ClaveHash, loginDto.Clave))
        {
            return null; // Contraseña incorrecta
        }

        // Generar el DTO del usuario
        var usuarioDto = _mapper.Map<UsuarioDto>(usuario);

        // Generar el token JWT
        var token = _jwtService.GenerateToken(usuarioDto);

        return new LoginResponseDto
        {
            Token = token,
            Usuario = usuarioDto
        };
    }

    public async Task<bool> cambiarEstado(long id, CambiarEstadoDto cambiarEstadoDto)
    {
        var usuario = await _context.Usuarios.FindAsync(id);
        if (usuario == null)
        {
            return false;
        }

        usuario.EstaActivo = cambiarEstadoDto.EstaActivo;

        _context.Usuarios.Update(usuario);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task crearUsuario(CreateUsuarioDto createUsuarioDto)
    {
        var usuario = _mapper.Map<Usuario>(createUsuarioDto);

        usuario.ClaveHash = _passwordService.HashPassword(createUsuarioDto.Clave);
        usuario.EstaActivo = true; // Activar usuario por defecto

        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();

        return;

    }

    public async Task<DetalleUsuarioDto?> obtenerDetalleUsuario(long id)
    {
        var usuario = await _context.Usuarios
            .Include(u => u.Rol)
            .Include(u => u.MensajesChat)
            .FirstOrDefaultAsync(u => u.Id == id);

        if (usuario == null)
        {
            return null;
        }

        return _mapper.Map<DetalleUsuarioDto>(usuario);
    }

    public async Task<List<UsuarioDto>> obtenerUsuarios()
    {
        var usuarios = await _context.Usuarios
            .Include(u => u.Rol)
            .ToListAsync();

        return _mapper.Map<List<UsuarioDto>>(usuarios);
    }

    public async Task<bool> eliminarUsuario(long id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);
        if (usuario == null)
        {
            return false;
        }

        _context.Usuarios.Remove(usuario);
        await _context.SaveChangesAsync();

        return true;
    }
}