using AutoMapper;
using ComplianceGuardPro.Modules.Pagos.DTOs;
using ComplianceGuardPro.Modules.Pagos.Models;

namespace ComplianceGuardPro.Modules.Pagos.Mappings
{
    public class PagoMappingProfile : Profile
    {
        public PagoMappingProfile()
        {
            CreateMap<Pago, PagoDto>();
            CreateMap<CreatePagoDto, Pago>();
        }
    }
}