

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

    public Task<bool> actualizarClave(long id, UpdatePasswordDto updatePasswordDto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> actualizarUsuario(long id, UpdateUsuarioDto updateUsuarioDto)
    {
        throw new NotImplementedException();
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

    public Task<bool> cambiarEstado(long id, CambiarEstadoDto cambiarEstadoDto)
    {
        throw new NotImplementedException();
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

    public Task<DetalleUsuarioDto?> obtenerDetalleUsuario(long id)
    {
        throw new NotImplementedException();
    }

    public Task<List<UsuarioDto>> obtenerUsuarios()
    {
        throw new NotImplementedException();
    }
}