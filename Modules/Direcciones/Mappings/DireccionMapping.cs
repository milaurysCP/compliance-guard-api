using AutoMapper;
using ComplianceGuardPro.Modules.Direcciones.Models;
using ComplianceGuardPro.Modules.Direcciones.DTOs;

namespace ComplianceGuardPro.Modules.Direcciones.Mappings;

public class DireccionMappingProfile : Profile
{
    public DireccionMappingProfile()
    {
        // Mapeos de Direccion
        CreateMap<Direccion, DireccionDto>();
        CreateMap<CreateDireccionDto, Direccion>();
    }
}