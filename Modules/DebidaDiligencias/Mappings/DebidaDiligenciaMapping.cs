using AutoMapper;
using ComplianceGuardPro.Modules.DebidaDiligencia.DTOs;
using ComplianceGuardPro.Modules.DebidaDiligencia.Models;

namespace ComplianceGuardPro.Modules.DebidaDiligencia.Mappings
{
    public class DebidaDiligenciaMappingProfile : Profile
    {
        public DebidaDiligenciaMappingProfile()
        {
            CreateMap<Models.DebidaDiligencia, DebidaDiligenciaDto>();
            CreateMap<CreateDebidaDiligenciaDto, Models.DebidaDiligencia>();
        }
    }
}