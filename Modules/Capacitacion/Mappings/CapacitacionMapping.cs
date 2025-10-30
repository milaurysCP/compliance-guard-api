using AutoMapper;
using ComplianceGuardPro.Modules.Capacitacion.DTOs;
using ComplianceGuardPro.Modules.Capacitacion.Models;

namespace ComplianceGuardPro.Modules.Capacitacion.Mappings
{
    public class CapacitacionMappingProfile : Profile
    {
        public CapacitacionMappingProfile()
        {
            CreateMap<Models.Capacitacion, CapacitacionDto>();
            CreateMap<CreateCapacitacionDto, Models.Capacitacion>();
        }
    }
}