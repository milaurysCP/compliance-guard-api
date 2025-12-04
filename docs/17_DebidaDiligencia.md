# Módulo DebidaDiligencia

## Descripción
Gestión de procesos de debida diligencia para clientes, incluyendo riesgos y documentos asociados.

## Endpoints

### 1. GET /api/DebidaDiligencia
**Obtener lista de debidas diligencias**

**Response (200 OK):**
```json
[
  {
        "id": 2,
        "sujetoNombre": "Juan Pérez Comercial",
        "sujetoIdentificacion": "40212345678",
        "sujetoListas": "No aparece en listas restrictivas",
        "sujetoOtraInformacion": "Cliente con actividad comercial estable",
        "tipoPersona": "JURIDICA",
        "jurisdiccion": "República Dominicana",
        "riesgoProducto": "MEDIO",
        "sectorEconomico": "3100",
        "campoLaboral": "Distribución de alimentos",
        "origenesRecurso": "Ventas comerciales",
        "nivelIngreso": "150000",
        "fuente": "Ingresos comerciales",
        "tipoPago": "Transferencia",
        "tipoMoneda": "DOP",
        "tipoPeps": "PEP NACIONAL",
        "cargoPeps": "Senador",
        "institucionPeps": "Congreso Nacional",
        "consulta": "Sin alertas previas",
        "relacionTerceros": "No aplica",
        "actividad": "Solicitud de préstamo personal",
        "pais": "República Dominicana",
        "canal": "Presencial",
        "observaciones": "Cliente con documentación completa y sin antecedentes negativos.",
        "puntajeRiesgo": 60,
        "nivelRiesgo": "MEDIO",
        "tipoDiligencia": "AMPLIADA",
        "fechaRegistro": "2025-12-04T04:08:19.4836652",
        "clienteId": 1
    }
]
```

### 2. GET /api/DebidaDiligencia/{id}
**Obtener debida diligencia específica**

**Parámetros de ruta:**
- `id` (long): ID de la debida diligencia

**Response (200 OK):**
```json
{
    "id": 2,
    "sujetoNombre": "Juan Pérez Comercial",
    "sujetoIdentificacion": "40212345678",
    "sujetoListas": "No aparece en listas restrictivas",
    "sujetoOtraInformacion": "Cliente con actividad comercial estable",
    "tipoPersona": "JURIDICA",
    "jurisdiccion": "República Dominicana",
    "riesgoProducto": "MEDIO",
    "sectorEconomico": "3100",
    "campoLaboral": "Distribución de alimentos",
    "origenesRecurso": "Ventas comerciales",
    "nivelIngreso": "150000",
    "fuente": "Ingresos comerciales",
    "tipoPago": "Transferencia",
    "tipoMoneda": "DOP",
    "tipoPeps": "PEP NACIONAL",
    "cargoPeps": "Senador",
    "institucionPeps": "Congreso Nacional",
    "consulta": "Sin alertas previas",
    "relacionTerceros": "No aplica",
    "actividad": "Solicitud de préstamo personal",
    "pais": "República Dominicana",
    "canal": "Presencial",
    "observaciones": "Cliente con documentación completa y sin antecedentes negativos.",
    "puntajeRiesgo": 60,
    "nivelRiesgo": "MEDIO",
    "tipoDiligencia": "AMPLIADA",
    "fechaRegistro": "2025-12-04T04:08:19.4836652",
    "clienteId": 1,
    "cliente": {
        "datosBasicos": {
            "id": 1,
            "nombre": "Juan Pérez Comercial",
            "tipoPersona": "JURIDICA",
            "siglas": "JPC",
            "documentoIdentidad": "40212345678",
            "fechaCreacion": "2020-05-10T00:00:00",
            "rnc": "131456789",
            "registroMercantil": "RM-2024-12345",
            "casaMatriz": "Santo Domingo"
        },
        "direccion": {
            "id": 1,
            "calle": "Av. Independencia",
            "numero": "125",
            "sector": "Gazcue",
            "codigoPostal": "10101",
            "pais": "República Dominicana",
            "provincia": "Santo Domingo",
            "municipio": "Santo Domingo Este"
        },
        "contactos": [
            {
                "id": 1,
                "tipoContacto": null,
                "valorContacto": null
            },
            {
                "id": 2,
                "tipoContacto": null,
                "valorContacto": null
            }
        ],
        "actividadEconomica": {
            "id": 1,
            "sector": "3100",
            "campoLaboral": "Distribución de alimentos",
            "origenFondos": "Ventas comerciales"
        },
        "soFinanciero": [
            {
                "id": 1,
                "tipoSOFinanciero": "ACCIONISTA",
                "nombreSOFinanciero": "María",
                "apellidosSOFinanciero": "Gómez López",
                "identificacionSOFinanciero": "00114578963",
                "nacionalidadSOFinanciero": "Dominicana"
            }
        ],
        "perfilFinanciero": [
            {
                "id": 1,
                "ningreso": "150000",
                "fuentes": "Ingresos comerciales"
            }
        ],
        "operaciones": {
            "id": 1,
            "tipoOperacion": "Préstamos Personales",
            "endidadFinanciera": "Banco Popular",
            "codigoOperacion": "OP-001",
            "descripcionOperacion": "Solicitud de préstamo personal",
            "propositoOperacion": "Capital de trabajo",
            "monto": 250000.00
        },
        "pagos": {
            "id": 1,
            "moneda": "DOP",
            "tipoPago": "Transferencia",
            "codigoPago": "PAY-001",
            "monto": 250000.00
        },
        "peps": {
            "id": 1,
            "cargoPeps": "Senador",
            "tipoPeps": "PEP NACIONAL",
            "nombrePeps": "Carlos Martínez",
            "decreto": "DEC-2021-504",
            "institucionPeps": "Congreso Nacional"
        },
        "responsable": {
            "id": 1,
            "responsableTransaccion": "Empleado interno",
            "nombresResposable": "Luis Alberto",
            "apellidosResponsable": "Ramírez",
            "direccionResponsable": "Av. Winston Churchill, Santo Domingo",
            "identificacionResponsable": "22345678901",
            "correo": "lramirez@empresa.com",
            "telefono": "8095557890",
            "cargo": "Oficial de Cumplimiento"
        }
    }
}
```

**Response (404 Not Found):**
```json
{
  "message": "Debida diligencia no encontrada"
}
```

### 3. POST /api/DebidaDiligencia
**Crear nueva debida diligencia**

**Request Body:**
```json
{
  "SujetoNombre": "Juan Pérez Comercial",
  "SujetoIdentificacion": "40212345678",
  "SujetoListas": "No aparece en listas restrictivas",
  "SujetoOtraInformacion": "Cliente con actividad comercial estable",
  "TipoPersona": "JURIDICA",
  "Jurisdiccion": "República Dominicana",
  "RiesgoProducto": "MEDIO",
  "SectorEconomico": "3100",
  "CampoLaboral": "Distribución de alimentos",
  "OrigenesRecurso": "Ventas comerciales",
  "NivelIngreso": "150000",
  "Fuente": "Ingresos comerciales",
  "TipoPago": "Transferencia",
  "TipoMoneda": "DOP",
  "TipoPeps": "PEP NACIONAL",
  "CargoPeps": "Senador",
  "InstitucionPeps": "Congreso Nacional",
  "Consulta": "Sin alertas previas",
  "RelacionTerceros": "No aplica",
  "Actividad": "Solicitud de préstamo personal",
  "Pais": "República Dominicana",
  "Canal": "Presencial",
  "Observaciones": "Cliente con documentación completa y sin antecedentes negativos.",
  "PuntajeRiesgo": 60,
  "NivelRiesgo": "MEDIO",
  "TipoDiligencia": "AMPLIADA",
  "ClienteId": 1
}
```

**Response (200 OK):**
```json
{
  "message": "Debida diligencia creada exitosamente"
}
```

### 4. PUT /api/DebidaDiligencia/{id}
**Actualizar debida diligencia**

**Parámetros de ruta:**
- `id` (long): ID de la debida diligencia

**Request Body:**
```json
{
  "SujetoNombre": "Juan Pérez Comercial",
  "SujetoIdentificacion": "40212345678",
  "SujetoListas": "No aparece en listas restrictivas",
  "SujetoOtraInformacion": "Cliente con actividad comercial estable",
  "TipoPersona": "JURIDICA",
  "Jurisdiccion": "República Dominicana",
  "RiesgoProducto": "MEDIO",
  "SectorEconomico": "3100",
  "CampoLaboral": "Distribución de alimentos",
  "OrigenesRecurso": "Ventas comerciales",
  "NivelIngreso": "150000",
  "Fuente": "Ingresos comerciales",
  "TipoPago": "Transferencia",
  "TipoMoneda": "DOP",
  "TipoPeps": "PEP NACIONAL",
  "CargoPeps": "Senador",
  "InstitucionPeps": "Congreso Nacional",
  "Consulta": "Sin alertas previas",
  "RelacionTerceros": "No aplica",
  "Actividad": "Solicitud de préstamo personal",
  "Pais": "República Dominicana",
  "Canal": "Presencial",
  "Observaciones": "Cliente con documentación completa y sin antecedentes negativos.",
  "PuntajeRiesgo": 60,
  "NivelRiesgo": "MEDIO",
  "TipoDiligencia": "AMPLIADA",
  "ClienteId": 1
}
```

**Response (200 OK):**
```json
{
  "message": "Debida diligencia actualizada exitosamente"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Debida diligencia no encontrada"
}
```

### 5. DELETE /api/DebidaDiligencia/{id}
**Eliminar debida diligencia**

**Parámetros de ruta:**
- `id` (long): ID de la debida diligencia

**Response (200 OK):**
```json
{
  "message": "Debida diligencia eliminada exitosamente"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Debida diligencia no encontrada"
}
```

