using AutoMapper;
using ComplianceGuardPro.Modules.Politica.DTOs;
using ComplianceGuardPro.Modules.Politica.Models;

namespace ComplianceGuardPro.Modules.Politica.Mappings
{
    public class PoliticaMappingProfile : Profile
    {
        public PoliticaMappingProfile()
        {
            CreateMap<Models.Politica, PoliticaDto>();
            CreateMap<CreatePoliticaDto, Models.Politica>();
        }
    }
}