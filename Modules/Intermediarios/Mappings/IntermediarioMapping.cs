using AutoMapper;
using ComplianceGuardPro.Modules.Intermediarios.DTOs;
using ComplianceGuardPro.Modules.Intermediarios.Models;

namespace ComplianceGuardPro.Modules.Intermediarios.Mappings
{
    public class IntermediarioMappingProfile : Profile
    {
        public IntermediarioMappingProfile()
        {
            CreateMap<Intermediario, IntermediarioDto>();
            CreateMap<CreateIntermediarioDto, Intermediario>();
        }
    }
}