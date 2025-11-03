using AutoMapper;
using ComplianceGuardPro.Modules.Direcciones.Models;
using ComplianceGuardPro.Modules.Direcciones.DTOs;

namespace ComplianceGuardPro.Modules.Direcciones.Mappings;

public class DireccionMappingProfile : Profile
{
    public DireccionMappingProfile()
    {
        // Mapeos de Direccion
        CreateMap<Direccion, DireccionDto>()
            .ForMember(dest => dest.Ciudad, opt => opt.MapFrom(src => src.Municipio))
            .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Provincia));

        CreateMap<CreateDireccionDto, Direccion>()
            .ForMember(dest => dest.Municipio, opt => opt.MapFrom(src => src.Ciudad))
            .ForMember(dest => dest.Provincia, opt => opt.MapFrom(src => src.Estado));
    }
}