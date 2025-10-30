using AutoMapper;
using ComplianceGuardPro.Modules.Usuarios.Models;
using ComplianceGuardPro.Modules.Usuarios.DTOs;

namespace ComplianceGuardPro.Modules.Usuarios.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Mapeos de Usuario
        CreateMap<Usuario, UsuarioDto>()
            .ForMember(dest => dest.NombreRol, opt => opt.MapFrom(src => src.Rol.Nombre));

        CreateMap<CreateUsuarioDto, Usuario>();
        CreateMap<UpdateUsuarioDto, Usuario>();

        // Mapeos de Rol
        CreateMap<Rol, RolDto>();
        CreateMap<CreateRolDto, Rol>();
    }
}