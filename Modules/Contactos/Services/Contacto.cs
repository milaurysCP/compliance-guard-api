using ComplianceGuardPro.Modules.Contactos.DTOs;

namespace ComplianceGuardPro.Modules.Contactos.Services;

public interface IContacto
{
    Task<List<ContactoDto>> obtenerContactosPorCliente(long clienteId);
    Task crearContacto(CreateContactoDto createContactoDto);
    Task<bool> actualizarContacto(long id, CreateContactoDto updateContactoDto);
    Task<bool> eliminarContacto(long id);
    Task<ContactoDto?> obtenerContacto(long id);
}