using AutoMapper;
using ComplianceGuardPro.Modules.ProgresoCapacitacion.DTOs;
using ComplianceGuardPro.Modules.ProgresoCapacitacion.Models;

namespace ComplianceGuardPro.Modules.ProgresoCapacitacion.Mappings
{
    public class ProgresoCapacitacionMappingProfile : Profile
    {
        public ProgresoCapacitacionMappingProfile()
        {
            CreateMap<Models.ProgresoCapacitacion, ProgresoCapacitacionDto>();
            CreateMap<CreateProgresoCapacitacionDto, Models.ProgresoCapacitacion>();
        }
    }
}