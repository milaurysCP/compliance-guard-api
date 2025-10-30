using AutoMapper;
using ComplianceGuardPro.Modules.Operaciones.DTOs;
using ComplianceGuardPro.Modules.Operaciones.Models;

namespace ComplianceGuardPro.Modules.Operaciones.Mappings
{
    public class OperacionMappingProfile : Profile
    {
        public OperacionMappingProfile()
        {
            CreateMap<Operacion, OperacionDto>();
            CreateMap<CreateOperacionDto, Operacion>();
        }
    }
}