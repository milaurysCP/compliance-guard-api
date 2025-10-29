using AutoMapper;
using ComplianceGuardPro.Data;
using Microsoft.EntityFrameworkCore;

public class RolImpl : IRol
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public RolImpl(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<RolDto>> obtenerRoles()
    {
        var roles = await _context.Roles
            .Select(r => _mapper.Map<RolDto>(r))
            .ToListAsync();

        return roles;
    }

    public async Task crearRol(CreateRolDto createRolDto)
    {
        var rol = _mapper.Map<Rol>(createRolDto);

        _context.Roles.Add(rol);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> actualizarRol(long id, CreateRolDto updateRolDto)
    {
        var rol = await _context.Roles.FindAsync(id);
        if (rol == null)
        {
            return false;
        }

        _mapper.Map(updateRolDto, rol);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> eliminarRol(long id)
    {
        var rol = await _context.Roles.FindAsync(id);
        if (rol == null)
        {
            return false;
        }

        _context.Roles.Remove(rol);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<RolDto?> obtenerRol(long id)
    {
        var rol = await _context.Roles.FindAsync(id);

        if (rol == null)
        {
            return null;
        }

        return _mapper.Map<RolDto>(rol);
    }
}