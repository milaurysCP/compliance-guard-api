using AutoMapper;
using ComplianceGuardPro.Modules.Responsable.DTOs;
using ComplianceGuardPro.Modules.Responsable.Models;

namespace ComplianceGuardPro.Modules.Responsable.Mappings
{
    public class ResponsableMappingProfile : Profile
    {
        public ResponsableMappingProfile()
        {
            CreateMap<Models.Responsable, ResponsableDto>();
            CreateMap<CreateResponsableDto, Models.Responsable>();
        }
    }
}