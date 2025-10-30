using AutoMapper;
using ComplianceGuardPro.Modules.Riesgos.DTOs;
using ComplianceGuardPro.Modules.Riesgos.Models;

namespace ComplianceGuardPro.Modules.Riesgos.Mappings
{
    public class RiesgoMappingProfile : Profile
    {
        public RiesgoMappingProfile()
        {
            CreateMap<Riesgo, RiesgoDto>()
                .ForMember(dest => dest.CantidadEvaluaciones, opt => opt.MapFrom(src => src.Evaluaciones.Count));

            CreateMap<CreateRiesgoDto, Riesgo>();
        }
    }
}