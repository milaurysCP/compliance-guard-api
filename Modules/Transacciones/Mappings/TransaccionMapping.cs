using AutoMapper;
using ComplianceGuardPro.Modules.Transacciones.DTOs;
using ComplianceGuardPro.Modules.Transacciones.Models;

namespace ComplianceGuardPro.Modules.Transacciones.Mappings
{
    public class TransaccionMappingProfile : Profile
    {
        public TransaccionMappingProfile()
        {
            CreateMap<Transaccion, TransaccionDto>();
            CreateMap<CreateTransaccionDto, Transaccion>();
        }
    }
}