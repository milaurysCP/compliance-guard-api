using AutoMapper;
using ComplianceGuardPro.Modules.ActividadesEconomicas.DTOs;
using ComplianceGuardPro.Modules.ActividadesEconomicas.Models;

namespace ComplianceGuardPro.Modules.ActividadesEconomicas.Mappings
{
    public class ActividadEconomicaMappingProfile : Profile
    {
        public ActividadEconomicaMappingProfile()
        {
            CreateMap<ActividadEconomica, ActividadEconomicaDto>();
            CreateMap<CreateActividadEconomicaDto, ActividadEconomica>();
        }
    }
}