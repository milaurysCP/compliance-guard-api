using AutoMapper;
using ComplianceGuardPro.Modules.Evaluaciones.DTOs;
using ComplianceGuardPro.Modules.Evaluaciones.Models;

namespace ComplianceGuardPro.Modules.Evaluaciones.Mappings
{
    public class EvaluacionMappingProfile : Profile
    {
        public EvaluacionMappingProfile()
        {
            CreateMap<Evaluacion, EvaluacionDto>()
                .ForMember(dest => dest.RiesgoNombre, opt => opt.MapFrom(src => src.Riesgo.Nombre))
                .ForMember(dest => dest.ClienteNombre, opt => opt.MapFrom(src => src.Cliente.Nombre));

            CreateMap<CreateEvaluacionDto, Evaluacion>();
        }
    }
}