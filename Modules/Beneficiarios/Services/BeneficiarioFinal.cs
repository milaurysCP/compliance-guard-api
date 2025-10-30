using ComplianceGuardPro.Modules.Beneficiarios.DTOs;

namespace ComplianceGuardPro.Modules.Beneficiarios.Services;

public interface IBeneficiarioFinal
{
    Task<List<BeneficiarioFinalDto>> obtenerBeneficiariosPorCliente(long clienteId);
    Task crearBeneficiarioFinal(CreateBeneficiarioFinalDto createBeneficiarioDto);
    Task<bool> actualizarBeneficiarioFinal(long id, CreateBeneficiarioFinalDto updateBeneficiarioDto);
    Task<bool> eliminarBeneficiarioFinal(long id);
    Task<BeneficiarioFinalDto?> obtenerBeneficiarioFinal(long id);
}