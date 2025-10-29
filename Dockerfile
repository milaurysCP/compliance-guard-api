# ==========================
# Etapa 1: Build
# ==========================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar archivos del proyecto y restaurar dependencias
COPY ComplianceGuardPro.csproj ./
RUN dotnet restore

# Copiar el resto del código y compilar en modo Release
COPY . .
RUN dotnet publish -c Release -o /app/publish

# ==========================
# Etapa 2: Runtime
# ==========================
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

# Configuración del servidor web
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

# Iniciar la aplicación
ENTRYPOINT ["dotnet", "ComplianceGuardPro.dll"]
