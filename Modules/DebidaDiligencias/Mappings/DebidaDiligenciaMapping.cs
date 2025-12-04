using AutoMapper;
using ComplianceGuardPro.Modules.DebidaDiligencia.DTOs;
using ComplianceGuardPro.Modules.DebidaDiligencia.Models;
using ComplianceGuardPro.Modules.Clientes.Models;
using ComplianceGuardPro.Modules.Clientes.DTOs;
using ComplianceGuardPro.Modules.Direcciones.Models;
using ComplianceGuardPro.Modules.Contactos.Models;
using ComplianceGuardPro.Modules.ActividadesEconomicas.Models;
using ComplianceGuardPro.Modules.PerfilesFinancieros.Models;
using ComplianceGuardPro.Modules.Operaciones.Models;
using ComplianceGuardPro.Modules.Beneficiarios.Models;
using ComplianceGuardPro.Modules.Pagos.Models;
using PepModel = ComplianceGuardPro.Modules.PersonaExpuestaPoliticamente.Models.PersonaExpuestaPoliticamente;
using ResponsableModel = ComplianceGuardPro.Modules.Responsable.Models.Responsable;

namespace ComplianceGuardPro.Modules.DebidaDiligencia.Mappings
{
    public class DebidaDiligenciaMappingProfile : Profile
    {
        public DebidaDiligenciaMappingProfile()
        {
            CreateMap<Models.DebidaDiligencia, DebidaDiligenciaDto>()
                .ForMember(dest => dest.Cliente, opt => opt.MapFrom(src => src.Cliente));
            
            CreateMap<CreateDebidaDiligenciaDto, Models.DebidaDiligencia>();
            
            // Mapeo de Cliente a ClienteDto con todas sus relaciones
            CreateMap<Cliente, ClienteDto>()
                .ForMember(dest => dest.DatosBasicos, opt => opt.MapFrom(src => new DatosBasicosDto
                {
                    Id = src.Id,
                    Nombre = src.Nombre,
                    TipoPersona = src.TipoPersona,
                    Siglas = src.Siglas,
                    DocumentoIdentidad = src.DocumentoIdentidad,
                    FechaCreacion = src.FechaCreacion,
                    Rnc = src.Rnc,
                    RegistroMercantil = src.RegistroMercantil,
                    CasaMatriz = src.CasaMatriz
                }))
                .ForMember(dest => dest.Direccion, opt => opt.MapFrom(src => src.Direcciones.FirstOrDefault()))
                .ForMember(dest => dest.Contactos, opt => opt.MapFrom(src => src.Contactos))
                .ForMember(dest => dest.ActividadEconomica, opt => opt.MapFrom(src => src.ActividadesEconomicas.FirstOrDefault()))
                .ForMember(dest => dest.SOFinanciero, opt => opt.MapFrom(src => src.BeneficiariosFinales))
                .ForMember(dest => dest.PerfilFinanciero, opt => opt.MapFrom(src => src.PerfilesFinancieros))
                .ForMember(dest => dest.Operaciones, opt => opt.MapFrom(src => src.Operaciones.FirstOrDefault()))
                .ForMember(dest => dest.Pagos, opt => opt.MapFrom(src => 
                    src.Operaciones.FirstOrDefault() != null && src.Operaciones.FirstOrDefault()!.Pagos.Any() 
                        ? src.Operaciones.FirstOrDefault()!.Pagos.FirstOrDefault() 
                        : null))
                .ForMember(dest => dest.Peps, opt => opt.MapFrom(src => src.PersonasExpuestasPoliticamente.FirstOrDefault()))
                .ForMember(dest => dest.Responsable, opt => opt.MapFrom(src => src.Responsables.FirstOrDefault()));
            
            // Mapeos de entidades relacionadas
            CreateMap<Direccion, DireccionDto>();
            CreateMap<Contacto, ContactoDto>();
            CreateMap<ActividadEconomica, ActividadEconomicaDto>();
            CreateMap<PerfilFinanciero, PerfilFinancieroDto>();
            CreateMap<Operacion, OperacionesDto>();
            CreateMap<PepModel, PepsDto>();
            CreateMap<ResponsableModel, ResponsableDto>();
            CreateMap<BeneficiarioFinal, SOFinancieroDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.TipoSOFinanciero, opt => opt.MapFrom(src => src.Tipo))
                .ForMember(dest => dest.NombreSOFinanciero, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.ApellidosSOFinanciero, opt => opt.MapFrom(src => src.Apellidos))
                .ForMember(dest => dest.IdentificacionSOFinanciero, opt => opt.MapFrom(src => src.Identificacion))
                .ForMember(dest => dest.NacionalidadSOFinanciero, opt => opt.MapFrom(src => src.Nacionalidad));
            
            CreateMap<Pago, PagosDto>();
        }
    }
}