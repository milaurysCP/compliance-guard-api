namespace ComplianceGuardPro.Modules.Clientes.Services;

public interface ICatalogoService
{
    object ObtenerActividadEconomica();
    object ObtenerOperaciones();
    List<string> ObtenerPaises();
    object ObtenerProvinciasRD();
    List<object> ObtenerMunicipiosPorProvincia(string provincia);
    object ObtenerPeps();
}
