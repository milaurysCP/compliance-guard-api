using AutoMapper;
using ComplianceGuardPro.Modules.Clientes.Models;
using ComplianceGuardPro.Modules.Clientes.DTOs;

namespace ComplianceGuardPro.Modules.Clientes.Mappings;

public class ClienteMappingProfile : Profile
{
    public ClienteMappingProfile()
    {
        // Mapeo de Cliente
        CreateMap<Cliente, ClienteSummaryDto>();
    }
}