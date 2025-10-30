using ComplianceGuardPro.Modules.Pagos.DTOs;

namespace ComplianceGuardPro.Modules.Pagos.Services
{
    public interface IPago
    {
        Task<List<PagoDto>> obtenerPagosPorOperacion(long operacionId);
        Task crearPago(CreatePagoDto createPagoDto);
        Task<bool> actualizarPago(long id, CreatePagoDto updatePagoDto);
        Task<bool> eliminarPago(long id);
        Task<PagoDto?> obtenerPago(long id);
    }
}