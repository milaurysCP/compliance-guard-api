using AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Mapeos de Usuario
        CreateMap<Usuario, UsuarioDto>()
            .ForMember(dest => dest.NombreRol, opt => opt.MapFrom(src => src.Rol.Nombre));

        CreateMap<CreateUsuarioDto, Usuario>();
        CreateMap<UpdateUsuarioDto, Usuario>();

        // Mapeos de Cliente
        CreateMap<Cliente, ClienteSummaryDto>();
        CreateMap<Cliente, ClienteDetailDto>();
        CreateMap<CreateClienteDto, Cliente>();
        CreateMap<UpdateClienteDto, Cliente>();

        // Mapeos de Direccion
        CreateMap<Direccion, DireccionDto>();
        CreateMap<CreateDireccionDto, Direccion>();

        // Mapeos de Contacto
        CreateMap<Contacto, ContactoDto>();
        CreateMap<CreateContactoDto, Contacto>();

        // Mapeos de ActividadEconomica
        CreateMap<ActividadEconomica, ActividadEconomicaDto>();
        CreateMap<CreateActividadEconomicaDto, ActividadEconomica>();

        // Mapeos de PerfilFinanciero
        CreateMap<PerfilFinanciero, PerfilFinancieroDto>();
        CreateMap<CreatePerfilFinancieroDto, PerfilFinanciero>();

        // Mapeos de Pago
        CreateMap<Pago, PagoDto>();
        CreateMap<CreatePagoDto, Pago>();

        // Mapeos de Operacion
        CreateMap<Operacion, OperacionDto>();
        CreateMap<CreateOperacionDto, Operacion>();

        // Mapeos de Transaccion
        CreateMap<Transaccion, TransaccionDto>();
        CreateMap<CreateTransaccionDto, Transaccion>();

        // Mapeos de BeneficiarioFinal
        CreateMap<BeneficiarioFinal, BeneficiarioFinalDto>();
        CreateMap<CreateBeneficiarioFinalDto, BeneficiarioFinal>();

        // Mapeos de Evaluacion
        CreateMap<Evaluacion, EvaluacionDto>();
        CreateMap<CreateEvaluacionDto, Evaluacion>();

        // Mapeos de Riesgo
        CreateMap<Riesgo, RiesgoDto>();
        CreateMap<CreateRiesgoDto, Riesgo>();

        // Mapeos de PersonaExpuestaPoliticamente
        CreateMap<PersonaExpuestaPoliticamente, PersonaExpuestaPoliticamenteDto>();
        CreateMap<CreatePersonaExpuestaPoliticamenteDto, PersonaExpuestaPoliticamente>();

        // Mapeos de Politica
        CreateMap<Politica, PoliticaDto>();
        CreateMap<CreatePoliticaDto, Politica>();

        // Mapeos de Intermediario
        CreateMap<Intermediario, IntermediarioDto>();
        CreateMap<CreateIntermediarioDto, Intermediario>();

        // Mapeos de Capacitacion
        CreateMap<Capacitacion, CapacitacionDto>();
        CreateMap<CreateCapacitacionDto, Capacitacion>();

        // Mapeos de Referencia
        CreateMap<Referencia, ReferenciaDto>();
        CreateMap<CreateReferenciaDto, Referencia>();

        // Mapeos de Responsable
        CreateMap<Responsable, ResponsableDto>();
        CreateMap<CreateResponsableDto, Responsable>();

        // Mapeos de Rol
        CreateMap<Rol, RolDto>();
        CreateMap<CreateRolDto, Rol>();

        // Mapeos de ProgresoCapacitacion
        CreateMap<ProgresoCapacitacion, ProgresoCapacitacionDto>();
        CreateMap<CreateProgresoCapacitacionDto, ProgresoCapacitacion>();

        // Mapeos de MensajeChat
        CreateMap<MensajeChat, MensajeChatDto>();
        CreateMap<CreateMensajeChatDto, MensajeChat>();
    }
}