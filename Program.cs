using ComplianceGuardPro.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Registra el service en el contenedor de dependencias para permitir su inyección en los controladores
builder.Services.AddScoped<Iusuario, UsuarioImpl>();
builder.Services.AddScoped<ICliente, ClienteImpl>();
builder.Services.AddScoped<IDireccion, DireccionImpl>();
builder.Services.AddScoped<IContacto, ContactoImpl>();
builder.Services.AddScoped<IActividadEconomica, ActividadEconomicaImpl>();
builder.Services.AddScoped<IPerfilFinanciero, PerfilFinancieroImpl>();
builder.Services.AddScoped<IOperacion, OperacionImpl>();
builder.Services.AddScoped<ITransaccion, TransaccionImpl>();
builder.Services.AddScoped<IBeneficiarioFinal, BeneficiarioFinalImpl>();
builder.Services.AddScoped<IEvaluacion, EvaluacionImpl>();
builder.Services.AddScoped<IRiesgo, RiesgoImpl>();
builder.Services.AddScoped<IPersonaExpuestaPoliticamente, PersonaExpuestaPoliticamenteImpl>();
builder.Services.AddScoped<IPolitica, PoliticaImpl>();
builder.Services.AddScoped<IIntermediario, IntermediarioImpl>();
builder.Services.AddScoped<ICapacitacion, CapacitacionImpl>();
builder.Services.AddScoped<IReferencia, ReferenciaImpl>();
builder.Services.AddScoped<IResponsable, ResponsableImpl>();
builder.Services.AddScoped<IRol, RolImpl>();
builder.Services.AddScoped<IProgresoCapacitacion, ProgresoCapacitacionImpl>();
builder.Services.AddScoped<IMensajeChat, MensajeChatImpl>();
builder.Services.AddSingleton<PasswordService>();
builder.Services.AddSingleton<JwtService>();


// Agrega los servicios necesarios para habilitar el soporte de controladores en la API
builder.Services.AddControllers();

// Registrar el DbContext
// ==============================
// 🔹 Determinar el origen de la conexión
// ==============================
string connectionString;

var host = Environment.GetEnvironmentVariable("MYSQLHOST");
var port = Environment.GetEnvironmentVariable("MYSQLPORT");
var user = Environment.GetEnvironmentVariable("MYSQLUSER");
var password = Environment.GetEnvironmentVariable("MYSQLPASSWORD");
var database = Environment.GetEnvironmentVariable("MYSQLDATABASE");

if (!string.IsNullOrEmpty(host) &&
    !string.IsNullOrEmpty(user) &&
    !string.IsNullOrEmpty(password) &&
    !string.IsNullOrEmpty(database))
{
    // ✅ Usar las variables de entorno (Railway)
    connectionString = $"server={host};port={port};database={database};user={user};password={password};";
}
else
{
    // ✅ Usar la conexión local del appsettings.json
    connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
        ?? throw new InvalidOperationException("DefaultConnection string not found in configuration");
}

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Configura AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

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

// Habilita autenticación y autorización
app.UseAuthentication();
app.UseAuthorization();

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