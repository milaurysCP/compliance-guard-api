# Módulo Cliente

## Descripción
Gestión completa de clientes del sistema de compliance, incluyendo información básica, direcciones, contactos, actividades económicas, beneficiarios finales, perfil financiero, operaciones, pagos, PEPs y responsables.

## Endpoints

### 1. GET /api/Clientes
**Obtener lista resumida de clientes**

**Response (200 OK):**
```json
[
  {
    "id": 1,
    "tipoPersona": "JURIDICA",
    "nombre": "Juan Pérez Comercial",
    "documentoIdentidad": "40212345678"
  }
]
```

### 2. GET /api/Clientes/buscar?filtro={valor}
**Buscar clientes por cédula, nombre o RNC**

**Parámetros de consulta:**
- `filtro` (string, requerido): Texto a buscar (puede ser cédula, pasaporte, nombre o RNC)

**Ejemplos:**
- `GET /api/Clientes/buscar?filtro=40212345678` (buscar por cédula)
- `GET /api/Clientes/buscar?filtro=Juan` (buscar por nombre)
- `GET /api/Clientes/buscar?filtro=131456789` (buscar por RNC)

**Response (200 OK):**
```json
[
  {
    "datosBasicos": {
      "id": 1,
      "nombre": "Juan Pérez Comercial",
      "tipoPersona": "JURIDICA",
      "siglas": "JPC",
      "documentoIdentidad": "40212345678",
      "fechaCreacion": "2020-05-10",
      "rnc": "131456789",
      "registroMercantil": "RM-2024-12345",
      "casaMatriz": "Santo Domingo"
    },
    "direccion": {
      "id": 5,
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
        "id": 10,
        "tipoContacto": "TELÉFONO",
        "valorContacto": "8095551234"
      },
      {
        "id": 11,
        "tipoContacto": "EMAIL",
        "valorContacto": "contacto@empresa.com"
      }
    ],
    "actividadEconomica": {
      "id": 3,
      "sector": "3100",
      "campoLaboral": "Distribución de alimentos",
      "origenFondos": "Ventas comerciales"
    },
    "sofinanciero": [
      {
        "id": 7,
        "tipoSOFinanciero": "ACCIONISTA",
        "nombreSOFinanciero": "María",
        "apellidosSOFinanciero": "Gómez López",
        "identificacionSOFinanciero": "00114578963",
        "nacionalidadSOFinanciero": "Dominicana"
      }
    ],
    "perfilFinanciero": [
      {
        "id": 2,
        "ningreso": "150000",
        "fuentes": "Ingresos comerciales"
      }
    ],
    "operaciones": {
      "id": 8,
      "tipoOperacion": "Préstamos Personales",
      "endidadFinanciera": "Banco Popular",
      "codigoOperacion": "OP-001",
      "descripcionOperacion": "Solicitud de préstamo personal",
      "propositoOperacion": "Capital de trabajo",
      "monto": 250000
    },
    "pagos": {
      "id": 12,
      "moneda": "DOP",
      "tipoPago": "Transferencia",
      "codigoPago": "PAY-001",
      "monto": 250000
    },
    "peps": {
      "id": 4,
      "cargoPeps": "Senador",
      "tipoPeps": "PEP NACIONAL",
      "nombrePeps": "Carlos Martínez",
      "decreto": "DEC-2021-504",
      "institucionPeps": "Congreso Nacional"
    },
    "responsable": {
      "id": 6,
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
]
```

**Response (400 Bad Request):**
```json
{
  "message": "El filtro de búsqueda es requerido"
}
```

### 3. GET /api/Clientes/{id}
**Obtener detalle completo de un cliente**

**Parámetros de ruta:**
- `id` (long): ID del cliente

**Response (200 OK):**
Retorna la misma estructura completa que el endpoint de búsqueda (ver ejemplo anterior), pero para un solo cliente.

**Response (404 Not Found):**
```json
{
  "message": "Cliente no encontrado"
}
```

### 4. POST /api/Clientes
**Crear nuevo cliente completo**

**Request Body:**
```json
{
  "datosBasicos": {
    "nombre": "Juan Pérez Comercial",
    "tipoPersona": "JURIDICA",
    "siglas": "JPC",
    "documentoIdentidad": "40212345678",
    "fechaCreacion": "2020-05-10",
    "rnc": "131456789",
    "registroMercantil": "RM-2024-12345",
    "casaMatriz": "Santo Domingo"
  },
  "direccion": {
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
      "tipoContacto": "TELÉFONO",
      "valorContacto": "8095551234"
    },
    {
      "tipoContacto": "EMAIL",
      "valorContacto": "contacto@empresa.com"
    }
  ],
  "actividadEconomica": {
    "sector": "3100",
    "campoLaboral": "Distribución de alimentos",
    "origenFondos": "Ventas comerciales"
  },
  "sofinanciero": [
    {
      "tipoSOFinanciero": "ACCIONISTA",
      "nombreSOFinanciero": "María",
      "apellidosSOFinanciero": "Gómez López",
      "identificacionSOFinanciero": "00114578963",
      "nacionalidadSOFinanciero": "Dominicana"
    }
  ],
  "perfilFinanciero": [
    {
      "ningreso": "150000",
      "fuentes": "Ingresos comerciales"
    }
  ],
  "operaciones": {
    "tipoOperacion": "Préstamos Personales",
    "endidadFinanciera": "Banco Popular",
    "codigoOperacion": "OP-001",
    "descripcionOperacion": "Solicitud de préstamo personal",
    "propositoOperacion": "Capital de trabajo",
    "monto": 250000
  },
  "pagos": {
    "moneda": "DOP",
    "tipoPago": "Transferencia",
    "codigoPago": "PAY-001",
    "monto": 250000
  },
  "peps": {
    "cargoPeps": "Senador",
    "tipoPeps": "PEP NACIONAL",
    "nombrePeps": "Carlos Martínez",
    "decreto": "DEC-2021-504",
    "institucionPeps": "Congreso Nacional"
  },
  "responsable": {
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
```

**Response (200 OK):**
```json
{
  "message": "Cliente creado exitosamente"
}
```

**Response (400 Bad Request - Falta provincia en RD):**
```json
{
  "message": "La provincia es requerida para direcciones en República Dominicana."
}
```

**Response (400 Bad Request - Falta municipio en RD):**
```json
{
  "message": "El municipio es requerido para direcciones en República Dominicana."
}
```

**Response (400 Bad Request - Provincia enviada para país extranjero):**
```json
{
  "message": "No se debe enviar provincia para direcciones fuera de República Dominicana (país: Estados Unidos)."
}
```

**Response (400 Bad Request - Municipio enviado para país extranjero):**
```json
{
  "message": "No se debe enviar municipio para direcciones fuera de República Dominicana (país: Estados Unidos)."
}
```

**Response (409 Conflict - Documento duplicado):**
```json
{
  "message": "Ya existe un cliente con el documento de identidad '40212345678'"
}
```

**Response (409 Conflict - RNC duplicado):**
```json
{
  "message": "Ya existe un cliente con el RNC '131456789'"
}
```

### 5. PUT /api/Clientes/{id}
**Actualizar cliente completo**

**Parámetros de ruta:**
- `id` (long): ID del cliente

**Request Body:**
```json
{
  "datosBasicos": {
    "nombre": "Juan Pérez Comercial",
    "tipoPersona": "JURIDICA",
    "siglas": "JPC",
    "documentoIdentidad": "40212345678",
    "fechaCreacion": "2020-05-10",
    "rnc": "131456789",
    "registroMercantil": "RM-2024-12345",
    "casaMatriz": "Santo Domingo"
  },
  "direccion": {
    "calle": "Av. Independencia",
    "numero": "125",
    "sector": "Gazcue",
    "codigoPostal": "10101",
    "pais": "República Dominicana",
    "provincia": "Santo Domingo",
    "municipio": "Santo Domingo Este"
  }
}
```

**Response (200 OK):**
```json
{
  "message": "Cliente actualizado correctamente"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Cliente no encontrado"
}
```

**Response (400 Bad Request - Falta provincia en RD):**
```json
{
  "message": "La provincia es requerida para direcciones en República Dominicana."
}
```

**Response (400 Bad Request - Falta municipio en RD):**
```json
{
  "message": "El municipio es requerido para direcciones en República Dominicana."
}
```

**Response (400 Bad Request - Provincia enviada para país extranjero):**
```json
{
  "message": "No se debe enviar provincia para direcciones fuera de República Dominicana (país: Estados Unidos)."
}
```

**Response (400 Bad Request - Municipio enviado para país extranjero):**
```json
{
  "message": "No se debe enviar municipio para direcciones fuera de República Dominicana (país: Estados Unidos)."
}
```

**Response (409 Conflict - Documento duplicado):**
```json
{
  "message": "Ya existe otro cliente con el documento de identidad '40212345678'"
}
```

**Response (409 Conflict - RNC duplicado):**
```json
{
  "message": "Ya existe otro cliente con el RNC '131456789'"
}
```

### 6. DELETE /api/Clientes/{id}
**Eliminar cliente y todas sus entidades relacionadas**

**Parámetros de ruta:**
- `id` (long): ID del cliente

**Comportamiento:**
Elimina en cascada todas las entidades relacionadas con el cliente:
- Direcciones
- Contactos
- Beneficiarios finales
- Actividades económicas
- Perfiles financieros
- Operaciones
- Transacciones
- Personas expuestas políticamente (PEPs)
- Responsables
- Referencias
- Intermediarios
- Evaluaciones

**Response (200 OK):**
```json
{
  "message": "Cliente eliminado exitosamente"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Cliente no encontrado"
}
```

## Endpoints de Catálogos

### 7. GET /api/Catalogos/actividad-economica
**Obtener catálogo de actividades económicas**

**Response (200 OK):**
Retorna el contenido del archivo `resource/actividad.json`

### 8. GET /api/Catalogos/operaciones
**Obtener catálogo de tipos de operaciones**

**Response (200 OK):**
Retorna el contenido del archivo `resource/operaciones.json`

### 9. GET /api/Catalogos/paises
**Obtener lista de países disponibles**

**Response (200 OK):**
Retorna la lista de países desde `resource/paises.json`

**Ejemplo:**
```json
[
  "República Dominicana",
  "Estados Unidos",
  "España",
  "..."
]
```

### 10. GET /api/Catalogos/provincias?pais={pais}
**Obtener provincias filtradas por país**

**Parámetros de consulta:**
- `pais` (string, opcional): Nombre del país. Si se omite o es "República Dominicana", retorna las provincias de RD. Para cualquier otro país retorna lista vacía.

**Ejemplos:**
- `GET /api/Catalogos/provincias` (retorna provincias de RD)
- `GET /api/Catalogos/provincias?pais=República Dominicana` (retorna provincias de RD)
- `GET /api/Catalogos/provincias?pais=Estados Unidos` (retorna lista vacía)

**Response (200 OK):**
```json
[
  {
    "provincia": "Santo Domingo",
    "municipios": [...]
  },
  {
    "provincia": "Santiago",
    "municipios": [...]
  }
]
```

### 11. GET /api/Catalogos/municipios?provincia={provincia}
**Obtener municipios de una provincia específica**

**Parámetros de consulta:**
- `provincia` (string, requerido): Nombre de la provincia

**Ejemplos:**
- `GET /api/Catalogos/municipios?provincia=Santo Domingo`
- `GET /api/Catalogos/municipios?provincia=Santiago`

**Response (200 OK):**
```json
[
  "Santo Domingo Este",
  "Santo Domingo Norte",
  "Santo Domingo Oeste",
  "Boca Chica",
  "Los Alcarrizos"
]
```

**Response (400 Bad Request):**
```json
{
  "message": "Provincia es requerida"
}
```

### 12. GET /api/Catalogos/peps
**Obtener catálogo de personas expuestas políticamente**

**Response (200 OK):**
Retorna el contenido del archivo `resource/peps.json`

## DTOs

### ClienteDto (Completo)
DTO principal que contiene toda la información del cliente con IDs incluidos en las respuestas.

```typescript
{
  datosBasicos: {
    id?: number,              // Solo en respuestas
    nombre?: string,
    tipoPersona?: string,     // "JURIDICA" | "NATURAL"
    siglas?: string,
    documentoIdentidad?: string,
    fechaCreacion?: date,
    rnc?: string,
    registroMercantil?: string,
    casaMatriz?: string
  },
  direccion?: {
    id?: number,              // Solo en respuestas
    calle?: string,
    numero?: string,
    sector?: string,
    codigoPostal?: string,
    pais?: string,            // Cualquier país válido
    provincia?: string,       // REQUERIDO solo si pais = "República Dominicana", PROHIBIDO para otros países
    municipio?: string        // REQUERIDO solo si pais = "República Dominicana", PROHIBIDO para otros países
  },
  contactos?: [
    {
      id?: number,            // Solo en respuestas
      tipoContacto?: string,  // "TELÉFONO" | "EMAIL" | "MÓVIL"
      valorContacto?: string
    }
  ],
  actividadEconomica?: {
    id?: number,              // Solo en respuestas
    sector?: string,          // Código del catálogo de actividades
    campoLaboral?: string,
    origenFondos?: string
  },
  sofinanciero?: [            // Beneficiarios / Personas relacionadas
    {
      id?: number,            // Solo en respuestas
      tipoSOFinanciero?: string,
      nombreSOFinanciero?: string,
      apellidosSOFinanciero?: string,
      identificacionSOFinanciero?: string,
      nacionalidadSOFinanciero?: string
    }
  ],
  perfilFinanciero?: [
    {
      id?: number,            // Solo en respuestas
      ningreso?: string,
      fuentes?: string
    }
  ],
  operaciones?: {
    id?: number,              // Solo en respuestas
    tipoOperacion?: string,
    endidadFinanciera?: string,
    codigoOperacion?: string,
    descripcionOperacion?: string,
    propositoOperacion?: string,
    monto: number
  },
  pagos?: {
    id?: number,              // Solo en respuestas
    moneda?: string,          // "DOP" | "USD" | "EUR"
    tipoPago?: string,
    codigoPago?: string,
    monto: number
  },
  peps?: {                    // Persona Expuesta Políticamente
    id?: number,              // Solo en respuestas
    cargoPeps?: string,
    tipoPeps?: string,
    nombrePeps?: string,
    decreto?: string,
    institucionPeps?: string
  },
  responsable?: {
    id?: number,              // Solo en respuestas
    responsableTransaccion?: string,
    nombresResposable?: string,
    apellidosResponsable?: string,
    direccionResponsable?: string,
    identificacionResponsable?: string,
    correo?: string,
    telefono?: string,
    cargo?: string
  }
}
```

### ClienteSummaryDto
DTO ligero para listados.

```json
{
  "id": "long",
  "tipoPersona": "string",
  "nombre": "string",
  "documentoIdentidad": "string"
}
```

## Notas Importantes

1. **Unicidad de Campos**:
   - `documentoIdentidad` (cédula/pasaporte) es único en el sistema
   - `rnc` es único en el sistema
   - Intentar crear un cliente con un documento o RNC duplicado retornará un error 409 (Conflict)

2. **Validación de Dirección**: 
   - El campo `pais` acepta cualquier país válido
   - **Si país = "República Dominicana"**: Los campos `provincia` y `municipio` son REQUERIDOS
   - **Si país ≠ "República Dominicana"**: Los campos `provincia` y `municipio` NO deben enviarse (deben estar vacíos o null). Si se envían, se retornará un error 400

3. **Campo `id`**: Todos los sub-objetos incluyen un campo `id` opcional que:
   - NO debe enviarse al crear un cliente (POST)
   - Se retorna automáticamente en las respuestas (GET)
   - Permite identificar registros específicos para actualizaciones futuras

4. **Búsqueda**: El endpoint `/buscar` acepta búsquedas parciales y es case-insensitive

5. **Catálogos**: Use los endpoints de `/api/Catalogos` para obtener valores válidos:
   - `/api/Catalogos/actividad-economica` - Sectores de actividad económica
   - `/api/Catalogos/operaciones` - Tipos de operaciones
   - `/api/Catalogos/paises` - Lista de países (solo República Dominicana)
   - `/api/Catalogos/provincias?pais=República Dominicana` - Provincias de RD
   - `/api/Catalogos/municipios?provincia={nombre}` - Municipios por provincia
   - `/api/Catalogos/peps` - Cargos PEP

6. **Flujo recomendado para direcciones**:
   - Obtener países: `GET /api/Catalogos/paises`
   - Obtener provincias: `GET /api/Catalogos/provincias?pais=República Dominicana`
   - Obtener municipios: `GET /api/Catalogos/municipios?provincia=Santo Domingo`

7. **Campos opcionales**: Todos los campos en `ClienteDto` son opcionales excepto cuando se especifica lo contrario en la lógica de negocio
