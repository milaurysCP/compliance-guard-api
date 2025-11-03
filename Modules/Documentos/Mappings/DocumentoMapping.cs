using AutoMapper;
using ComplianceGuardPro.Modules.Documentos.DTOs;

namespace ComplianceGuardPro.Modules.Documentos.Mappings
{
    public class DocumentoMappingProfile : Profile
    {
        public DocumentoMappingProfile()
        {
            CreateMap<Models.Documento, DocumentoDto>()
                .ForMember(dest => dest.ClienteId, opt => opt.MapFrom(src => src.DebidaDiligencia.ClienteId));

            CreateMap<CreateDocumentoDto, Models.Documento>();
        }
    }
}