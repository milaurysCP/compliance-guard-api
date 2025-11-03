# 🧭 Instalación y Configuración del Proyecto

## 🧩 Instalar Paquetes Necesarios

Ejecuta este comando para agregar **AutoMapper**:

```bash
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
```

Libreria para generar pdf
```bash 
dotnet add package DinkToPdf
```

Libreria para generar excel
```bash 
dotnet add package EPPlus
```



Si aún no tienes instalado **Entity Framework Core** para MySQL, agrega también:

```bash
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Pomelo.EntityFrameworkCore.MySql
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design
```

💡 Estos paquetes permiten crear, aplicar y administrar migraciones con EF Core en MySQL.

## 🔐 Configurar la Base de Datos

Antes de trabajar con la base de datos, asegúrate de que MySQL esté corriendo correctamente en Docker:

```bash
docker compose up -d
```

Luego, valida que el contenedor esté activo:

```bash
docker ps
```

El usuario `root` ya está configurado en el `docker-compose.yml` con la contraseña definida.

### Conexión al Servidor

En tu archivo `appsettings.json`, define la conexión así:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Port=3306;Database=ComplianceGuard_DB;User=root;Password=YourStrong@Passw0rd;"
}
```

⚠️ Importante: Si cambiaste la contraseña en Docker, actualízala aquí también.

## ⚙️ Migraciones con Entity Framework Core

Asegúrate de estar en el proyecto donde se encuentra el `DbContext` (por ejemplo, la carpeta `API` o `Infrastructure`).

1. Crear la primera migración:

   ```bash
   dotnet ef migrations add InitialCreate
   ```

2. Aplicar las migraciones a la base de datos:

   ```bash
   dotnet ef database update

   dotnet ef database drop 

   ```

3. Ver lista de migraciones aplicadas:

   ```bash
   dotnet ef migrations list
   ```

4. Eliminar una migración (si aún no se ha aplicado):

   ```bash
   dotnet ef migrations remove
   ```

## 🚀 Levantar la API

Ejecuta el proyecto normalmente:

```bash
dotnet run
```

O si tienes múltiples proyectos en la solución:

```bash
dotnet run --project ComplianceGuardPro.API
```

Por defecto, la API quedará disponible en:

- 🌐 HTTP: http://localhost:5000
- 🔒 HTTPS: https://localhost:5001

## 🧰 Comandos Útiles

- Crear una nueva migración: `dotnet ef migrations add NombreMigracion`
- Aplicar todas las migraciones pendientes: `dotnet ef database update`
- Eliminar la última migración: `dotnet ef migrations remove`
- Ejecutar la API: `dotnet run`
- Compilar la solución: `dotnet build`
- Restaurar dependencias: `dotnet restore`

## ✅ Recomendación Final

- Mantén sincronizado el MYSQL_ROOT_PASSWORD del `docker-compose.yml` con tu `appsettings.json`.
- Si deseas acceder al MySQL desde **MySQL Workbench** o **phpMyAdmin**, usa las mismas credenciales:
  - Server: localhost
  - Port: 3306
  - User: root
  - Password: YourStrong@Passw0rd
  - Database: ComplianceGuard_DB



