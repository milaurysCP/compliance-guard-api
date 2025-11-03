using AutoMapper;
using ComplianceGuardPro.Modules.Pagos.DTOs;
using ComplianceGuardPro.Modules.Pagos.Models;

namespace ComplianceGuardPro.Modules.Pagos.Mappings
{
    public class PagoMappingProfile : Profile
    {
        public PagoMappingProfile()
        {
            CreateMap<Pago, PagoDto>()
                .ForMember(dest => dest.ClienteId, opt => opt.MapFrom(src => src.Operacion.ClienteId));

            CreateMap<CreatePagoDto, Pago>();
        }
    }
}