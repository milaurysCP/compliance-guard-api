# API Endpoints Reference - Cliente Module

## Base URL
```
https://your-api-domain.com/api
```

## Authentication
All endpoints require JWT authentication:
```
Authorization: Bearer {your-jwt-token}
```

---

## Cliente Endpoints

### 1. Crear Cliente Completo
**POST** `/clientes/completo`

Crea un cliente con todos sus datos relacionados en una sola petición.

**Request Body**: Ver ejemplo completo en `CLIENTE_MODULE_UPDATE.md`

**Response**:
```json
{
  "message": "Cliente creado exitosamente"
}
```

### 2. Crear Cliente (Legacy)
**POST** `/clientes`

**Request Body**:
```json
{
  "tipoCliente": "Persona",
  "nombre": "Juan Pérez",
  "documentoIdentidad": "001-1234567-8"
}
```

### 3. Obtener Lista de Clientes
**GET** `/clientes`

**Response**:
```json
[
  {
    "id": 1,
    "tipoCliente": "Persona",
    "nombre": "Juan Pérez",
    "documentoIdentidad": "001-1234567-8"
  }
]
```

### 4. Obtener Detalle de Cliente
**GET** `/clientes/{id}`

**Response**:
```json
{
  "id": 1,
  "tipoCliente": "Persona",
  "nombre": "Juan Pérez",
  "url": null,
  "documentoIdentidad": "001-1234567-8",
  "registroComercial": null,
  "fechaNacimiento": "1990-01-15",
  "direcciones": [],
  "contactos": []
}
```

### 5. Actualizar Cliente
**PUT** `/clientes/{id}`

**Request Body**:
```json
{
  "nombre": "Juan Pérez Actualizado",
  "url": "https://example.com"
}
```

### 6. Eliminar Cliente
**DELETE** `/clientes/{id}`

---

## Catálogos Endpoints

### 1. Actividades Económicas
**GET** `/catalogos/actividad-economica`

Retorna el catálogo completo de sectores y actividades económicas.

**Response**:
```json
{
  "actividad": [
    {
      "sector_1_primario": {
        "1100": "Agricultura",
        "1110": "Cultivo de caña de azúcar",
        ...
      },
      "sector_2_secundario": { ... },
      "sector_3_terciario": { ... }
    }
  ]
}
```

### 2. Operaciones
**GET** `/catalogos/operaciones`

Retorna tipos de operaciones por sector.

**Response**:
```json
{
  "Sector Financiero": {
    "Bancos Comerciales": [
      "Préstamos Personales",
      "Préstamos Hipotecarios",
      ...
    ],
    ...
  },
  "Sector No Financiero": { ... }
}
```

### 3. Países
**GET** `/catalogos/paises`

Retorna lista de todos los países.

**Response**:
```json
[
  "República Dominicana",
  "Afghanistan",
  "Albania",
  ...
]
```

### 4. Provincias
**GET** `/catalogos/provincias?pais=República Dominicana`

Retorna provincias de República Dominicana con sus municipios.

**Query Parameters**:
- `pais` (optional): Nombre del país. Default: "República Dominicana"

**Response**:
```json
[
  {
    "provincia": "Distrito Nacional",
    "municipios": [
      { "municipio": "Santo Domingo de Guzmán" }
    ]
  },
  {
    "provincia": "Santo Domingo",
    "municipios": [
      { "municipio": "Santo Domingo Este" },
      { "municipio": "Santo Domingo Norte" },
      ...
    ]
  },
  ...
]
```

### 5. Municipios por Provincia
**GET** `/catalogos/municipios?provincia=Santiago`

Retorna municipios de una provincia específica.

**Query Parameters**:
- `provincia` (required): Nombre de la provincia

**Response**:
```json
[
  { "municipio": "Santiago de los Caballeros" },
  { "municipio": "Bisonó" },
  { "municipio": "Jánico" },
  ...
]
```

### 6. PEPs (Personas Expuestas Políticamente)
**GET** `/catalogos/peps`

Retorna catálogo de cargos PEP.

**Response**:
```json
{
  "1_organos_ejecutivos_nacionales": [
    "Presidente de la República",
    "Vicepresidente(s) de la República",
    ...
  ],
  "2_organos_legislativos": [ ... ],
  "3_gobiernos_locales_administracion_regional": [ ... ],
  ...
}
```

---

## Códigos de Respuesta HTTP

| Código | Descripción |
|--------|-------------|
| 200    | OK - Petición exitosa |
| 400    | Bad Request - Datos inválidos |
| 401    | Unauthorized - Token inválido o ausente |
| 404    | Not Found - Recurso no encontrado |
| 500    | Internal Server Error - Error del servidor |

---

## Ejemplos de Uso (JavaScript/Fetch)

### Crear Cliente Completo

```javascript
const crearCliente = async (clienteData) => {
  const response = await fetch('https://api.example.com/api/clientes/completo', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    },
    body: JSON.stringify(clienteData)
  });
  
  if (!response.ok) {
    throw new Error('Error al crear cliente');
  }
  
  return await response.json();
};
```

### Obtener Provincias

```javascript
const obtenerProvincias = async () => {
  const response = await fetch('https://api.example.com/api/catalogos/provincias?pais=República Dominicana', {
    headers: {
      'Authorization': `Bearer ${token}`
    }
  });
  
  return await response.json();
};
```

### Obtener Municipios de una Provincia

```javascript
const obtenerMunicipios = async (provincia) => {
  const response = await fetch(`https://api.example.com/api/catalogos/municipios?provincia=${encodeURIComponent(provincia)}`, {
    headers: {
      'Authorization': `Bearer ${token}`
    }
  });
  
  return await response.json();
};
```

---

## Notas para el Frontend

1. **Validación de País**: Si el usuario selecciona "República Dominicana", habilite los campos de Provincia y Municipio. De lo contrario, deshabilítelos.

2. **Campos Opcionales**: Todos los campos en `ClienteDto` son opcionales excepto `DatosBasicos`. Valide en el frontend según sus reglas de negocio.

3. **Catálogos**: Los catálogos deben cargarse al inicio de la aplicación o cuando se abra el formulario de creación de cliente.

4. **Autocomplete**: Use los catálogos para crear campos de tipo select/autocomplete en vez de campos de texto libre.

5. **Manejo de Errores**: Implemente manejo de errores apropiado. La API retorna `400 Bad Request` con detalles del error cuando hay problemas de validación.

6. **Token Expirado**: Si recibe `401 Unauthorized`, redirija al usuario al login para obtener un nuevo token.
