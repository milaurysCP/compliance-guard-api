using AutoMapper;
using ComplianceGuardPro.Modules.Mitigacion.DTOs;

namespace ComplianceGuardPro.Modules.Mitigacion.Mappings
{
    public class MitigacionMappingProfile : Profile
    {
        public MitigacionMappingProfile()
        {
            CreateMap<Models.Mitigacion, MitigacionDto>()
                .ForMember(dest => dest.RiesgoNombre, opt => opt.MapFrom(src => src.Riesgo.Nombre))
                .ForMember(dest => dest.ClienteId, opt => opt.MapFrom(src => src.Riesgo.DebidaDiligencia.ClienteId));

            CreateMap<CreateMitigacionDto, Models.Mitigacion>();
        }
    }
}