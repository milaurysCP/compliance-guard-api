using AutoMapper;
using ComplianceGuardPro.Modules.Contactos.Models;
using ComplianceGuardPro.Modules.Contactos.DTOs;

namespace ComplianceGuardPro.Modules.Contactos.Mappings;

public class ContactoMappingProfile : Profile
{
    public ContactoMappingProfile()
    {
        // Mapeos de Contacto
        CreateMap<Contacto, ContactoDto>();
        CreateMap<CreateContactoDto, Contacto>();
    }
}