using System.Collections.Generic;
using System.Threading.Tasks;
using ComplianceGuardPro.Modules.Evaluaciones.DTOs;

namespace ComplianceGuardPro.Modules.Evaluaciones.Services
{
    public interface IEvaluacion
    {
        Task<List<EvaluacionDto>> obtenerEvaluacionesPorCliente(long clienteId);
        Task crearEvaluacion(CreateEvaluacionDto createEvaluacionDto);
        Task<bool> actualizarEvaluacion(long id, CreateEvaluacionDto updateEvaluacionDto);
        Task<bool> eliminarEvaluacion(long id);
        Task<EvaluacionDto?> obtenerEvaluacion(long id);
    }
}