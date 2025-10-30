using AutoMapper;
using ComplianceGuardPro.Modules.Referencia.DTOs;
using ComplianceGuardPro.Modules.Referencia.Models;

namespace ComplianceGuardPro.Modules.Referencia.Mappings
{
    public class ReferenciaMappingProfile : Profile
    {
        public ReferenciaMappingProfile()
        {
            CreateMap<Models.Referencia, ReferenciaDto>();
            CreateMap<CreateReferenciaDto, Models.Referencia>();
        }
    }
}