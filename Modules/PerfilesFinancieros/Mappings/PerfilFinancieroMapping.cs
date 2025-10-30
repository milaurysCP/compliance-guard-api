using AutoMapper;
using ComplianceGuardPro.Modules.PerfilesFinancieros.DTOs;
using ComplianceGuardPro.Modules.PerfilesFinancieros.Models;

namespace ComplianceGuardPro.Modules.PerfilesFinancieros.Mappings
{
    public class PerfilFinancieroMappingProfile : Profile
    {
        public PerfilFinancieroMappingProfile()
        {
            CreateMap<PerfilFinanciero, PerfilFinancieroDto>();
            CreateMap<CreatePerfilFinancieroDto, PerfilFinanciero>();
        }
    }
}