using AutoMapper;
using ComplianceGuardPro.Modules.MensajesChat.DTOs;
using ComplianceGuardPro.Modules.MensajesChat.Models;

namespace ComplianceGuardPro.Modules.MensajesChat.Mappings
{
    public class MensajeChatMappingProfile : Profile
    {
        public MensajeChatMappingProfile()
        {
            CreateMap<MensajeChat, MensajeChatDto>()
                .ForMember(dest => dest.UsuarioNombre, opt => opt.MapFrom(src => src.Usuario.Nombre));

            CreateMap<CreateMensajeChatDto, MensajeChat>();
        }
    }
}