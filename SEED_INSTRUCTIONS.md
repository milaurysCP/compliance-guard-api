# Carga de Datos Iniciales - ComplianceGuard Pro

## Opción Recomendada: Script SQL Básico

El método más eficiente y seguro para cargar los datos iniciales es utilizando el script SQL básico.

### 📄 Archivos SQL Disponibles

1. **`seed_basic.sql`** - ✅ Script básico y funcional con datos esenciales (RECOMENDADO)
2. **`seed_data.sql`** - Script completo (puede tener errores de columnas)
3. **`clean_database.sql`** - Script para limpiar toda la base de datos

### 🚀 Instrucciones de Uso

#### Cargar Datos Básicos (RECOMENDADO)

1. **Conectar a SQL Server:**
   ```bash
   # Asegúrate de que el contenedor Docker esté corriendo
   docker-compose up -d
   ```

2. **Ejecutar el script básico en SQL Server Management Studio (SSMS):**
   - Conectar a: `localhost,1433`
   - Usuario: `sa`
   - Contraseña: `YourStrong@Passw0rd`
   - Abrir archivo: `seed_basic.sql`
   - Ejecutar script (F5)

3. **O ejecutar desde línea de comandos:**
   ```bash
   sqlcmd -S localhost,1433 -U sa -P "YourStrong@Passw0rd" -i seed_basic.sql
   ```

#### Limpiar Base de Datos

Para eliminar todos los datos:
```bash
sqlcmd -S localhost,1433 -U sa -P "YourStrong@Passw0rd" -i clean_database.sql
```

### 📊 Datos Incluidos en el Script Básico

El script `seed_basic.sql` incluye datos validados para:

#### 🔐 Usuarios y Roles (4 usuarios, 4 roles)
- **admin** / 12345678 - Administrador
- **compliance1** / 12345678 - Compliance Officer
- **analista1** / 12345678 - Analista
- **auditor1** / 12345678 - Auditor

#### 📋 Políticas (2 políticas)
- Prevención de Lavado de Activos
- Conocimiento del Cliente (KYC)

#### 🎓 Capacitaciones (0 capacitaciones)
- El módulo de capacitaciones está disponible pero sin datos de seed

#### 👥 Clientes (5 clientes)
- 2 Personas naturales
- 3 Personas jurídicas
- Con estructura actualizada según modelo vigente

#### 🏢 Datos Relacionados Validados
- **Direcciones** (5 registros) - con columnas correctas según modelo actual
- **Contactos** (10 registros) - información de contacto
- **Actividades Económicas** (5 registros) - sectores económicos
- **Beneficiarios Finales** (5 registros) - estructura corporativa
- **Perfiles Financieros** (5 registros) - información financiera
- **Riesgos** (5 registros con diferentes niveles)
- **Operaciones** (5 operaciones básicas)
- **Transacciones** (5 transacciones)
- **Evaluaciones** (5 evaluaciones de compliance)

## Opción Alternativa: API Endpoints

### 🌐 Endpoints Disponibles

#### Verificar Estado de la Base de Datos
```
GET http://localhost:5271/api/init/status
```

#### Crear Solo Usuario Admin
```
POST http://localhost:5271/api/init/create-admin
```

#### Verificar Conexión
```
GET http://localhost:5271/api/init/connection-test
```

### 🧪 Ejemplo de Uso con curl

```bash
# Verificar estado
curl -X GET http://localhost:5271/api/init/status

# Crear admin si no existe
curl -X POST http://localhost:5271/api/init/create-admin

# Probar conexión
curl -X GET http://localhost:5271/api/init/connection-test
```

## 🔍 Verificación Post-Carga

Después de ejecutar el script, puedes verificar que todo funcionó correctamente:

```bash
# Verificar estado via API
curl -X GET http://localhost:5271/api/init/status

# O directamente en SQL
sqlcmd -S localhost,1433 -U sa -P "YourStrong@Passw0rd" -Q "USE ComplianceGuard_DB; SELECT 'Clientes' as Tabla, COUNT(*) as Total FROM Clientes"
```

## 🎯 Datos de Prueba Realistas

Los datos incluidos están diseñados para ser realistas y útiles para pruebas:

- **Perfiles de riesgo variados** (Bajo, Medio, Alto)
- **Transacciones sospechosas** marcadas apropiadamente
- **Relaciones entre entidades** completamente configuradas
- **Fechas coherentes** y progresivas
- **Montos realistas** en DOP y USD
- **Estados consistentes** para el flujo de trabajo

## ⚡ Ventajas del Script SQL Básico

1. **Compatibilidad**: Usa solo columnas que existen en los modelos
2. **Rapidez**: Carga todos los datos en segundos
3. **Consistencia**: Datos relacionales correctamente vinculados
4. **Realismo**: Datos que reflejan casos de uso reales
5. **Facilidad**: Un solo comando para cargar todo
6. **Limpieza**: Script de limpieza incluido
7. **Sin errores**: Validado contra los modelos actuales

## 🔧 Troubleshooting

Si tienes problemas:

1. **Verificar que Docker esté corriendo:**
   ```bash
   docker ps
   ```

2. **Verificar conectividad:**
   ```bash
   telnet localhost 1433
   ```

3. **Revisar logs de SQL Server:**
   ```bash
   docker logs compliance-guard-api-sqlserver-1
   ```

4. **Verificar API:**
   ```bash
   curl -X GET http://localhost:5271/api/init/connection-test
   ```