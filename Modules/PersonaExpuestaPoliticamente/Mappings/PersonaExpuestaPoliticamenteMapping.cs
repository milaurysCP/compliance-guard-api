using AutoMapper;
using ComplianceGuardPro.Modules.PersonaExpuestaPoliticamente.DTOs;
using ComplianceGuardPro.Modules.PersonaExpuestaPoliticamente.Models;

namespace ComplianceGuardPro.Modules.PersonaExpuestaPoliticamente.Mappings
{
    public class PersonaExpuestaPoliticamenteMappingProfile : Profile
    {
        public PersonaExpuestaPoliticamenteMappingProfile()
        {
            CreateMap<Models.PersonaExpuestaPoliticamente, PersonaExpuestaPoliticamenteDto>();
            CreateMap<CreatePersonaExpuestaPoliticamenteDto, Models.PersonaExpuestaPoliticamente>();
        }
    }
}