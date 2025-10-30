using AutoMapper;
using ComplianceGuardPro.Modules.Beneficiarios.Models;
using ComplianceGuardPro.Modules.Beneficiarios.DTOs;

namespace ComplianceGuardPro.Modules.Beneficiarios.Mappings;

public class BeneficiarioMappingProfile : Profile
{
    public BeneficiarioMappingProfile()
    {
        // Mapeos de BeneficiarioFinal
        CreateMap<BeneficiarioFinal, BeneficiarioFinalDto>();
        CreateMap<CreateBeneficiarioFinalDto, BeneficiarioFinal>();
    }
}