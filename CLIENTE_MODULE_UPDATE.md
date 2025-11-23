# Cliente Module Update - Documentation

## Overview
El módulo de Cliente ha sido completamente reestructurado para soportar la creación de clientes con un objeto JSON completo que incluye todos los datos relacionados en una sola petición.

## Cambios Realizados

### 1. Nuevos DTOs Creados

Se crearon los siguientes DTOs en `Modules/Clientes/DTOs/ClienteDto.cs`:

- **DatosBasicosDto**: Información básica del cliente
- **DireccionDto**: Dirección del cliente
- **ContactoDto**: Contactos del cliente
- **ActividadEconomicaDto**: Actividad económica
- **SOFinancieroDto**: Sujetos Obligados Financieros (personas relacionadas)
- **PerfilFinancieroDto**: Perfil financiero
- **OperacionesDto**: Operaciones del cliente
- **PagosDto**: Pagos realizados
- **PepsDto**: Persona Expuesta Políticamente
- **ResponsableDto**: Responsable de la transacción
- **ClienteDto**: DTO principal que agrupa todos los anteriores

### 2. Modelos Actualizados

Se actualizaron los siguientes modelos para incluir los nuevos campos:

#### Cliente (`Modules/Clientes/Models/Cliente.cs`)
- Agregados campos: `TipoPersona`, `Siglas`, `FechaCreacion`, `Rnc`, `CasaMatriz`
- Mantenidos campos legacy para compatibilidad

#### ActividadEconomica
- Agregados: `Sector`, `CampoLaboral`, `OrigenFondos`
- Mantenidos campos legacy

#### BeneficiarioFinal (SOFinanciero)
- Agregados: `Tipo`, `Apellidos`, `Identificacion`, `Nacionalidad`

#### PerfilFinanciero
- Agregados: `Ningreso`, `Fuentes`
- Mantenido `NivelIngreso` (legacy)

#### Operacion
- Agregados: `TipoOperacion`, `EndidadFinanciera`, `CodigoOperacion`, `DescripcionOperacion`, `PropositoOperacion`, `Monto`
- Mantenidos campos legacy

#### Pago
- Agregados: `Moneda`, `TipoPago`, `CodigoPago`, `Monto`
- Mantenidos campos legacy

#### PersonaExpuestaPoliticamente
- Agregados: `CargoPeps`, `TipoPeps`, `NombrePeps`, `Decreto`, `InstitucionPeps`
- Mantenidos campos legacy

#### Responsable
- Agregados: `ResponsableTransaccion`, `NombresResposable`, `ApellidosResponsable`, `DireccionResponsable`, `IdentificacionResponsable`
- Mantenidos campos legacy

### 3. Servicios

#### ICliente / ClienteImpl
- Agregado método: `crearClienteCompleto(ClienteDto dto)` 
- Este método maneja la creación de un cliente con todos sus datos relacionados en una sola transacción

#### ICatalogoService / CatalogoServiceImpl (NUEVO)
- Servicio para exponer los catálogos JSON
- Métodos:
  - `ObtenerActividadEconomica()`
  - `ObtenerOperaciones()`
  - `ObtenerPaises()`
  - `ObtenerProvinciasRD()`
  - `ObtenerMunicipiosPorProvincia(string provincia)`
  - `ObtenerPeps()`

### 4. Controladores

#### ClientesController
- Agregado endpoint: `POST /api/clientes/completo` - Acepta `ClienteDto`
- Mantiene endpoint legacy: `POST /api/clientes` - Acepta `CreateClienteDto`

#### CatalogosController (NUEVO)
Nuevos endpoints para catálogos:
- `GET /api/catalogos/actividad-economica`
- `GET /api/catalogos/operaciones`
- `GET /api/catalogos/paises`
- `GET /api/catalogos/provincias?pais=República Dominicana`
- `GET /api/catalogos/municipios?provincia=Santiago`
- `GET /api/catalogos/peps`

### 5. Migración de Base de Datos

Se creó la migración: `UpdateClienteModuleStructure`

**⚠️ IMPORTANTE**: Antes de aplicar la migración, revísela para verificar que no haya pérdida de datos.

Para aplicar la migración:
```bash
dotnet ef database update
```

## Uso

### Crear Cliente Completo

**Endpoint**: `POST /api/clientes/completo`

**Headers**:
```
Authorization: Bearer {token}
Content-Type: application/json
```

**Body**:
```json
{
  "datosBasicos": {
    "nombre": "Empresa ABC S.A.",
    "tipoPersona": "Juridica",
    "siglas": "ABC",
    "documentoIdentidad": "001-1234567-8",
    "fechaCreacion": "2020-01-15",
    "rnc": "131234567",
    "registroMercantil": "RM-2020-123",
    "casaMatriz": "República Dominicana"
  },
  "direccion": {
    "calle": "Av. Winston Churchill",
    "numero": "1234",
    "sector": "Piantini",
    "codigoPostal": "10148",
    "pais": "República Dominicana",
    "provincia": "Distrito Nacional",
    "municipio": "Santo Domingo de Guzmán"
  },
  "contactos": [
    {
      "tipoContacto": "Teléfono",
      "valorContacto": "809-555-1234"
    },
    {
      "tipoContacto": "Email",
      "valorContacto": "info@empresaabc.com"
    }
  ],
  "actividadEconomica": {
    "sector": "Financiero",
    "campoLaboral": "Banca",
    "origenFondos": "Inversiones"
  },
  "sofinanciero": [
    {
      "tipoSOFinanciero": "Accionista",
      "nombreSOFinanciero": "Juan",
      "apellidosSOFinanciero": "Pérez",
      "identificacionSOFinanciero": "001-9876543-2",
      "nacionalidadSOFinanciero": "Dominicana"
    }
  ],
  "perfilFinanciero": [
    {
      "ningreso": "Alto",
      "fuentes": "Inversiones, Negocios"
    }
  ],
  "operaciones": {
    "tipoOperacion": "Préstamo",
    "endidadFinanciera": "Banco XYZ",
    "codigoOperacion": "OP-2024-001",
    "descripcionOperacion": "Préstamo empresarial",
    "propositoOperacion": "Capital de trabajo",
    "monto": 5000000.00
  },
  "pagos": {
    "moneda": "DOP",
    "tipoPago": "Transferencia",
    "codigoPago": "PAG-001",
    "monto": 5000000.00
  },
  "peps": {
    "cargoPeps": "Ministro",
    "tipoPeps": "Nacional",
    "nombrePeps": "Pedro González",
    "decreto": "Decreto 123-20",
    "institucionPeps": "Ministerio de Hacienda"
  },
  "responsable": {
    "responsableTransaccion": "Sí",
    "nombresResposable": "María",
    "apellidosResponsable": "Rodríguez",
    "direccionResponsable": "Calle Principal #45",
    "identificacionResponsable": "001-5555555-5",
    "correo": "maria.rodriguez@empresaabc.com",
    "telefono": "809-555-5678",
    "cargo": "Gerente General"
  }
}
```

### Obtener Catálogos

#### Actividades Económicas
```bash
GET /api/catalogos/actividad-economica
```

#### Operaciones
```bash
GET /api/catalogos/operaciones
```

#### Países
```bash
GET /api/catalogos/paises
```

#### Provincias (República Dominicana)
```bash
GET /api/catalogos/provincias?pais=República Dominicana
```

#### Municipios por Provincia
```bash
GET /api/catalogos/municipios?provincia=Santiago
```

#### PEPs
```bash
GET /api/catalogos/peps
```

## Compatibilidad

Se mantiene compatibilidad con el sistema legacy:
- El endpoint `POST /api/clientes` sigue funcionando con `CreateClienteDto`
- Los campos legacy en los modelos se mantienen para no romper funcionalidad existente

## Notas Importantes

1. **Validación**: Los DTOs no tienen validaciones estrictas. Considere agregar `[Required]` donde sea necesario.

2. **Transacciones**: El método `crearClienteCompleto` usa múltiples `SaveChangesAsync()`. Si necesita que todo sea una transacción atómica, considere usar `IDbContextTransaction`.

3. **Catálogos**: Los catálogos se leen directamente de archivos JSON en el directorio `resource/`. Asegúrese de que estos archivos existan y sean accesibles.

4. **Migración**: Revise la migración antes de aplicarla en producción. Algunos campos cambiaron de tipo (ej: `Monto` de nullable a non-nullable).

5. **Testing**: Pruebe todos los endpoints antes de desplegar a producción.

## Archivos Modificados

- `Modules/Clientes/DTOs/ClienteDto.cs` ✅
- `Modules/Clientes/Models/Cliente.cs` ✅
- `Modules/Clientes/Services/Cliente.cs` ✅
- `Modules/Clientes/Services/ClienteImpl.cs` ✅
- `Modules/Clientes/Controllers/ClientesController.cs` ✅
- `Modules/Clientes/Controllers/CatalogosController.cs` ✅ (NUEVO)
- `Modules/Clientes/Services/ICatalogoService.cs` ✅ (NUEVO)
- `Modules/Clientes/Services/CatalogoServiceImpl.cs` ✅ (NUEVO)
- `Modules/ActividadesEconomicas/Models/ActividadEconomica.cs` ✅
- `Modules/Beneficiarios/Models/BeneficiarioFinal.cs` ✅
- `Modules/PerfilesFinancieros/Models/PerfilFinanciero.cs` ✅
- `Modules/Operaciones/Models/Operacion.cs` ✅
- `Modules/Pagos/Models/Pago.cs` ✅
- `Modules/PersonaExpuestaPoliticamente/Models/PersonaExpuestaPoliticamente.cs` ✅
- `Modules/Responsable/Models/Responsable.cs` ✅
- `Modules/Reportes/Services/ReportesImpl.cs` ✅ (Fix)
- `Program.cs` ✅
- `Migrations/UpdateClienteModuleStructure.cs` ✅ (NUEVO)

## Próximos Pasos

1. Revisar y aplicar la migración de base de datos
2. Probar todos los endpoints con Postman
3. Actualizar la documentación de Postman
4. Agregar validaciones adicionales si es necesario
5. Implementar manejo de errores más robusto
6. Considerar agregar logs para auditoría
