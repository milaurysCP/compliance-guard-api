using ComplianceGuardPro.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ComplianceGuardPro.Modules.Usuarios.Services;
using ComplianceGuardPro.Modules.Usuarios.Mappings;
using ComplianceGuardPro.Modules.Clientes.Services;
using ComplianceGuardPro.Modules.Clientes.Mappings;
using ComplianceGuardPro.Modules.Direcciones.Services;
using ComplianceGuardPro.Modules.Direcciones.Mappings;
using ComplianceGuardPro.Modules.Contactos.Services;
using ComplianceGuardPro.Modules.Contactos.Mappings;
using ComplianceGuardPro.Modules.Beneficiarios.Services;
using ComplianceGuardPro.Modules.Beneficiarios.Mappings;
using ComplianceGuardPro.Modules.Intermediarios.Services;
using ComplianceGuardPro.Modules.Intermediarios.Mappings;
using ComplianceGuardPro.Modules.ActividadesEconomicas.Services;
using ComplianceGuardPro.Modules.ActividadesEconomicas.Mappings;
using ComplianceGuardPro.Modules.PerfilesFinancieros.Services;
using ComplianceGuardPro.Modules.PerfilesFinancieros.Mappings;
using ComplianceGuardPro.Modules.Operaciones.Services;
using ComplianceGuardPro.Modules.Operaciones.Mappings;
using ComplianceGuardPro.Modules.Pagos.Services;
using ComplianceGuardPro.Modules.Pagos.Mappings;
using ComplianceGuardPro.Modules.Transacciones.Services;
using ComplianceGuardPro.Modules.Transacciones.Mappings;
using ComplianceGuardPro.Modules.DebidaDiligencia.Services;
using ComplianceGuardPro.Modules.DebidaDiligencia.Mappings;
using ComplianceGuardPro.Modules.Riesgos.Services;
using ComplianceGuardPro.Modules.Riesgos.Mappings;
using ComplianceGuardPro.Modules.Mitigacion.Services;
using ComplianceGuardPro.Modules.Mitigacion.Mappings;
using ComplianceGuardPro.Modules.Evaluaciones.Services;
using ComplianceGuardPro.Modules.Evaluaciones.Mappings;
using ComplianceGuardPro.Shared.Services;
using ComplianceGuardPro.Modules.MensajesChat.Mappings;
using ComplianceGuardPro.Modules.Referencia.Services;
using ComplianceGuardPro.Modules.Referencia.Mappings;
using ComplianceGuardPro.Modules.PersonaExpuestaPoliticamente.Services;
using ComplianceGuardPro.Modules.PersonaExpuestaPoliticamente.Mappings;
using ComplianceGuardPro.Modules.Responsable.Services;
using ComplianceGuardPro.Modules.Responsable.Mappings;
using ComplianceGuardPro.Modules.Politica.Services;
using ComplianceGuardPro.Modules.Politica.Mappings;
// using ComplianceGuardPro.Modules.ProgresoCapacitacion.Services;
// using ComplianceGuardPro.Modules.ProgresoCapacitacion.Mappings;
using ComplianceGuardPro.Modules.Capacitacion.Services;
using ComplianceGuardPro.Modules.Capacitacion.Mappings;
using ComplianceGuardPro.Modules.Reportes.Services;
using ComplianceGuardPro.Modules.Reportes.Mappings;
using ComplianceGuardPro.Modules.Documentos.Services;
using ComplianceGuardPro.Modules.Documentos.Mappings;
using ComplianceGuardPro.Modules.FAQ.Services;

var builder = WebApplication.CreateBuilder(args);

// Registra el service en el contenedor de dependencias para permitir su inyección en los controladores
builder.Services.AddScoped<Iusuario, UsuarioImpl>();
builder.Services.AddScoped<ICliente, ClienteImpl>();
builder.Services.AddScoped<ICatalogoService, CatalogoServiceImpl>();
builder.Services.AddScoped<IDireccion, DireccionImpl>();
builder.Services.AddScoped<IContacto, ContactoImpl>();
builder.Services.AddScoped<IActividadEconomica, ActividadEconomicaImpl>();
builder.Services.AddScoped<IPerfilFinanciero, PerfilFinancieroImpl>();
builder.Services.AddScoped<IOperacion, OperacionImpl>();
builder.Services.AddScoped<IOperacion, OperacionImpl>();
builder.Services.AddScoped<IPago, PagoImpl>();
builder.Services.AddScoped<ITransaccion, TransaccionImpl>();
builder.Services.AddScoped<IDebidaDiligencia, DebidaDiligenciaImpl>();
builder.Services.AddScoped<IBeneficiarioFinal, BeneficiarioFinalImpl>();
builder.Services.AddScoped<IIntermediario, IntermediarioImpl>();
builder.Services.AddScoped<IEvaluacion, EvaluacionImpl>();
builder.Services.AddScoped<IRiesgo, RiesgoImpl>();
builder.Services.AddScoped<IMitigacion, MitigacionImpl>();
builder.Services.AddScoped<IEvaluacion, EvaluacionImpl>();
builder.Services.AddScoped<IPersonaExpuestaPoliticamente, PersonaExpuestaPoliticamenteImpl>();
builder.Services.AddScoped<IPolitica, PoliticaImpl>();
builder.Services.AddScoped<IIntermediario, IntermediarioImpl>();
builder.Services.AddScoped<IActividadEconomica, ActividadEconomicaImpl>();
builder.Services.AddScoped<IReferencia, ReferenciaImpl>();
builder.Services.AddScoped<IResponsable, ResponsableImpl>();
builder.Services.AddScoped<IRol, RolImpl>();
// builder.Services.AddScoped<IProgresoCapacitacion, ProgresoCapacitacionImpl>();
builder.Services.AddScoped<ICapacitacion, CapacitacionImpl>();
builder.Services.AddScoped<ComplianceGuardPro.Modules.MensajesChat.Services.IMensajeChat, ComplianceGuardPro.Modules.MensajesChat.Services.MensajeChatImpl>();
builder.Services.AddScoped<IReportes, ReportesImpl>();
builder.Services.AddScoped<IDocumento, DocumentoImpl>();
builder.Services.AddScoped<IFaqService, FaqServiceImpl>();
builder.Services.AddSingleton<PasswordService>();
builder.Services.AddSingleton<JwtService>();


// Agrega los servicios necesarios para habilitar el soporte de controladores en la API
builder.Services.AddControllers();

// Registrar el DbContext
// ==============================
// 🔹 Configuración para SQL Server
// ==============================
string connectionString;

// Usar la conexión local del appsettings.json
connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
    ?? throw new InvalidOperationException("DefaultConnection string not found in configuration");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// Configura AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile), typeof(ClienteMappingProfile), typeof(DireccionMappingProfile), typeof(ContactoMappingProfile), typeof(BeneficiarioMappingProfile), typeof(IntermediarioMappingProfile), typeof(ActividadEconomicaMappingProfile), typeof(PerfilFinancieroMappingProfile), typeof(OperacionMappingProfile), typeof(PagoMappingProfile), typeof(TransaccionMappingProfile), typeof(DebidaDiligenciaMappingProfile), typeof(RiesgoMappingProfile), typeof(MitigacionMappingProfile), typeof(EvaluacionMappingProfile), typeof(MensajeChatMappingProfile), typeof(ReferenciaMappingProfile), typeof(PersonaExpuestaPoliticamenteMappingProfile), typeof(ResponsableMappingProfile), typeof(PoliticaMappingProfile), /* typeof(ProgresoCapacitacionMappingProfile), */ typeof(CapacitacionMappingProfile), typeof(ReportesMappingProfile), typeof(DocumentoMappingProfile));

// Configura JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var jwtSettings = builder.Configuration.GetSection("Jwt");
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]!))
        };
    });

// Configura CORS para permitir solicitudes desde cualquier origen, método y encabezado
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});



builder.Services.AddOpenApi();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Habilita CORS globalmente para aceptar solicitudes de cualquier origen antes de mapear los controladores
app.UseCors("AllowAll");

// Habilita autenticación y autorización - COMENTADO TEMPORALMENTE PARA ENDPOINTS PÚBLICOS
// app.UseAuthentication();
// app.UseAuthorization();

// Habilita el mapeo de rutas para los controladores de la API
app.MapControllers();

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}