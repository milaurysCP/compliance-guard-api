using System.Text.Json;

namespace ComplianceGuardPro.Modules.Clientes.Services;

public class CatalogoServiceImpl : ICatalogoService
{
    private readonly string _resourcePath;

    public CatalogoServiceImpl(IWebHostEnvironment env)
    {
        _resourcePath = Path.Combine(env.ContentRootPath, "resource");
    }

    public object ObtenerActividadEconomica()
    {
        var filePath = Path.Combine(_resourcePath, "actividad.json");
        var jsonContent = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<object>(jsonContent) ?? new object();
    }

    public object ObtenerOperaciones()
    {
        var filePath = Path.Combine(_resourcePath, "operaciones.json");
        var jsonContent = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<object>(jsonContent) ?? new object();
    }

    public List<string> ObtenerPaises()
    {
        var filePath = Path.Combine(_resourcePath, "paises.json");
        var jsonContent = File.ReadAllText(filePath);
        var data = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonContent);
        
        if (data != null && data.ContainsKey("paises"))
        {
            var paisesJson = data["paises"].ToString();
            return JsonSerializer.Deserialize<List<string>>(paisesJson!) ?? new List<string>();
        }
        
        return new List<string>();
    }

    public object ObtenerProvinciasRD()
    {
        var filePath = Path.Combine(_resourcePath, "paises.json");
        var jsonContent = File.ReadAllText(filePath);
        var data = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(jsonContent);
        
        if (data != null && data.ContainsKey("provinciasRD"))
        {
            return data["provinciasRD"];
        }
        
        return new List<object>();
    }

    public List<object> ObtenerMunicipiosPorProvincia(string provincia)
    {
        var filePath = Path.Combine(_resourcePath, "paises.json");
        var jsonContent = File.ReadAllText(filePath);
        
        using var document = JsonDocument.Parse(jsonContent);
        var root = document.RootElement;
        
        if (root.TryGetProperty("provinciasRD", out var provinciasRD))
        {
            foreach (var prov in provinciasRD.EnumerateArray())
            {
                if (prov.TryGetProperty("provincia", out var provinciaElement) &&
                    provinciaElement.GetString() == provincia)
                {
                    if (prov.TryGetProperty("municipios", out var municipios))
                    {
                        var municipiosList = new List<object>();
                        foreach (var municipio in municipios.EnumerateArray())
                        {
                            var municipioObj = JsonSerializer.Deserialize<object>(municipio.GetRawText());
                            if (municipioObj != null)
                            {
                                municipiosList.Add(municipioObj);
                            }
                        }
                        return municipiosList;
                    }
                }
            }
        }
        
        return new List<object>();
    }

    public object ObtenerPeps()
    {
        var filePath = Path.Combine(_resourcePath, "peps.json");
        var jsonContent = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<object>(jsonContent) ?? new object();
    }
}
