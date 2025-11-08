# Módulo FAQ (Preguntas Frecuentes)

## Descripción
Gestión de preguntas frecuentes sobre la Ley 155-17 (Ley Contra el Lavado de Activos y el Financiamiento del Terrorismo). Este módulo permite consultar, agregar, actualizar y eliminar preguntas y respuestas relacionadas con la normativa de compliance.

## Características
- ✅ Consulta de todas las FAQs disponibles
- ✅ Búsqueda inteligente por términos en preguntas y respuestas
- ✅ Creación de nuevas FAQs
- ✅ Actualización de FAQs existentes
- ✅ Eliminación de FAQs
- ✅ Almacenamiento persistente en archivo JSON
- ✅ Validación de duplicados
- ✅ Thread-safe para operaciones concurrentes

## Endpoints

### 1. GET /api/Faq
**Obtener todas las preguntas frecuentes**

**Headers:**
```
Authorization: Bearer {token}
```

**Response (200 OK):**
```json
{
  "success": true,
  "data": [
    {
      "pregunta": "¿Qué es la Ley 155-17?",
      "respuesta": "Es la Ley Contra el Lavado de Activos y el Financiamiento del Terrorismo en la República Dominicana, promulgada en 2017 para prevenir, detectar, sancionar y evitar el uso del sistema financiero y económico del país en actividades ilícitas."
    },
    {
      "pregunta": "¿Cuál es el objetivo principal de la Ley 155-17?",
      "respuesta": "Establecer los actos que tipifican el lavado de activos y el financiamiento del terrorismo, definir las sanciones penales y administrativas aplicables, y crear mecanismos de prevención, detección y cooperación nacional e internacional."
    }
  ],
  "total": 34
}
```

**Response (500 Internal Server Error):**
```json
{
  "success": false,
  "message": "Error al obtener las preguntas frecuentes"
}
```

---

### 2. GET /api/Faq/search
**Buscar preguntas frecuentes por término**

**Headers:**
```
Authorization: Bearer {token}
```

**Query Parameters:**
- `q` (string): Término de búsqueda (busca en preguntas y respuestas)

**Ejemplo de solicitud:**
```
GET /api/Faq/search?q=lavado
```

**Response (200 OK):**
```json
{
  "success": true,
  "data": [
    {
      "pregunta": "¿Qué se entiende por lavado de activos?",
      "respuesta": "Es el proceso mediante el cual personas físicas o jurídicas buscan dar apariencia legítima a bienes o activos que provienen de actividades delictivas o infracciones graves."
    },
    {
      "pregunta": "¿Qué sanciones establece la ley por lavado de activos?",
      "respuesta": "Las sanciones van de 10 a 20 años de prisión, multas de 200 a 400 salarios mínimos, decomiso de bienes y la inhabilitación para ejercer funciones públicas o financieras."
    }
  ],
  "total": 5,
  "searchTerm": "lavado"
}
```

**Response (500 Internal Server Error):**
```json
{
  "success": false,
  "message": "Error al buscar en las preguntas frecuentes"
}
```

---

### 3. POST /api/Faq
**Agregar nueva pregunta frecuente**

**Headers:**
```
Authorization: Bearer {token}
Content-Type: application/json
```

**Request Body:**
```json
{
  "pregunta": "¿Qué es una transacción en efectivo?",
  "respuesta": "Es toda operación comercial o financiera que se realiza mediante la entrega física de billetes o monedas, sin utilizar instrumentos bancarios como transferencias o cheques."
}
```

**Validaciones:**
- `pregunta`: Obligatoria, máximo 500 caracteres
- `respuesta`: Obligatoria, máximo 2000 caracteres

**Response (201 Created):**
```json
{
  "success": true,
  "message": "Pregunta frecuente agregada exitosamente",
  "data": {
    "pregunta": "¿Qué es una transacción en efectivo?",
    "respuesta": "Es toda operación comercial o financiera que se realiza mediante la entrega física de billetes o monedas, sin utilizar instrumentos bancarios como transferencias o cheques."
  }
}
```

**Response (400 Bad Request):**
```json
{
  "success": false,
  "message": "Datos inválidos",
  "errors": [
    "La pregunta es obligatoria",
    "La respuesta no puede exceder 2000 caracteres"
  ]
}
```

**Response (409 Conflict):**
```json
{
  "success": false,
  "message": "Ya existe una FAQ con una pregunta similar"
}
```

**Response (500 Internal Server Error):**
```json
{
  "success": false,
  "message": "Error al agregar la pregunta frecuente"
}
```

---

### 4. PUT /api/Faq
**Actualizar pregunta frecuente existente**

**Headers:**
```
Authorization: Bearer {token}
Content-Type: application/json
```

**Request Body:**
```json
{
  "preguntaOriginal": "¿Qué es la Ley 155-17?",
  "nuevaPregunta": "¿Qué es la Ley 155-17 de República Dominicana?",
  "nuevaRespuesta": "Es la Ley Contra el Lavado de Activos y el Financiamiento del Terrorismo en la República Dominicana, promulgada el 1 de junio de 2017, con el objetivo de prevenir, detectar, sancionar y evitar el uso del sistema financiero y económico del país en actividades ilícitas relacionadas con el lavado de dinero y el financiamiento del terrorismo."
}
```

**Validaciones:**
- `preguntaOriginal`: Obligatoria (identifica la FAQ a actualizar)
- `nuevaPregunta`: Obligatoria, máximo 500 caracteres
- `nuevaRespuesta`: Obligatoria, máximo 2000 caracteres

**Response (200 OK):**
```json
{
  "success": true,
  "message": "Pregunta frecuente actualizada exitosamente",
  "data": {
    "preguntaOriginal": "¿Qué es la Ley 155-17?",
    "nuevaPregunta": "¿Qué es la Ley 155-17 de República Dominicana?",
    "nuevaRespuesta": "Es la Ley Contra el Lavado de Activos y el Financiamiento del Terrorismo en la República Dominicana, promulgada el 1 de junio de 2017, con el objetivo de prevenir, detectar, sancionar y evitar el uso del sistema financiero y económico del país en actividades ilícitas relacionadas con el lavado de dinero y el financiamiento del terrorismo."
  }
}
```

**Response (400 Bad Request):**
```json
{
  "success": false,
  "message": "Datos inválidos",
  "errors": [
    "La pregunta original es obligatoria",
    "La nueva pregunta no puede exceder 500 caracteres"
  ]
}
```

**Response (404 Not Found):**
```json
{
  "success": false,
  "message": "No se encontró la pregunta frecuente a actualizar o ya existe una FAQ con la nueva pregunta"
}
```

**Response (500 Internal Server Error):**
```json
{
  "success": false,
  "message": "Error al actualizar la pregunta frecuente"
}
```

---

### 5. DELETE /api/Faq
**Eliminar pregunta frecuente**

**Headers:**
```
Authorization: Bearer {token}
```

**Query Parameters:**
- `pregunta` (string): Pregunta exacta a eliminar

**Ejemplo de solicitud:**
```
DELETE /api/Faq?pregunta=¿Qué es una transacción en efectivo?
```

**Response (200 OK):**
```json
{
  "success": true,
  "message": "Pregunta frecuente eliminada exitosamente"
}
```

**Response (400 Bad Request):**
```json
{
  "success": false,
  "message": "Debe proporcionar la pregunta a eliminar"
}
```

**Response (404 Not Found):**
```json
{
  "success": false,
  "message": "No se encontró la pregunta frecuente a eliminar"
}
```

**Response (500 Internal Server Error):**
```json
{
  "success": false,
  "message": "Error al eliminar la pregunta frecuente"
}
```

---

## Modelos

### FaqDto
```csharp
public class FaqDto
{
    public string Pregunta { get; set; }
    public string Respuesta { get; set; }
}
```

### CreateFaqDto
```csharp
public class CreateFaqDto
{
    [Required(ErrorMessage = "La pregunta es obligatoria")]
    [StringLength(500, ErrorMessage = "La pregunta no puede exceder 500 caracteres")]
    public string Pregunta { get; set; }

    [Required(ErrorMessage = "La respuesta es obligatoria")]
    [StringLength(2000, ErrorMessage = "La respuesta no puede exceder 2000 caracteres")]
    public string Respuesta { get; set; }
}
```

### UpdateFaqDto
```csharp
public class UpdateFaqDto
{
    [Required(ErrorMessage = "La pregunta original es obligatoria")]
    public string PreguntaOriginal { get; set; }

    [Required(ErrorMessage = "La nueva pregunta es obligatoria")]
    [StringLength(500, ErrorMessage = "La pregunta no puede exceder 500 caracteres")]
    public string NuevaPregunta { get; set; }

    [Required(ErrorMessage = "La nueva respuesta es obligatoria")]
    [StringLength(2000, ErrorMessage = "La respuesta no puede exceder 2000 caracteres")]
    public string NuevaRespuesta { get; set; }
}
```

---

## Almacenamiento
- **Archivo**: `FAQ_Ley_155_17.json` (ubicado en la raíz del proyecto)
- **Formato**: JSON indentado con encoding UTF-8
- **Persistencia**: Los cambios se guardan inmediatamente en el archivo
- **Thread-Safety**: Implementa `SemaphoreSlim` para operaciones concurrentes seguras

---

## Notas Importantes

### Seguridad
- ✅ Todos los endpoints requieren autenticación JWT
- ✅ Solo usuarios autenticados pueden consultar y modificar FAQs
- ✅ Se recomienda implementar roles específicos para operaciones de escritura

### Validaciones
- Las preguntas se comparan ignorando mayúsculas/minúsculas y espacios en blanco
- No se permiten preguntas duplicadas
- Al actualizar, si la nueva pregunta ya existe en otra FAQ, la operación falla

### Búsqueda
- La búsqueda es case-insensitive
- Busca coincidencias parciales en preguntas y respuestas
- Si no se proporciona término de búsqueda, devuelve todas las FAQs

### Logging
- Todas las operaciones generan logs informativos
- Los errores se registran con detalles completos para debugging
- Se recomienda monitorear los logs para detectar problemas

---

## Ejemplos de Uso con cURL

### Obtener todas las FAQs
```bash
curl -X GET "https://localhost:7000/api/Faq" \
  -H "Authorization: Bearer {token}"
```

### Buscar FAQs
```bash
curl -X GET "https://localhost:7000/api/Faq/search?q=beneficiario" \
  -H "Authorization: Bearer {token}"
```

### Agregar nueva FAQ
```bash
curl -X POST "https://localhost:7000/api/Faq" \
  -H "Authorization: Bearer {token}" \
  -H "Content-Type: application/json" \
  -d '{
    "pregunta": "¿Qué es un sujeto obligado?",
    "respuesta": "Es toda persona física o jurídica que por su actividad económica está obligada a implementar medidas de prevención del lavado de activos."
  }'
```

### Actualizar FAQ
```bash
curl -X PUT "https://localhost:7000/api/Faq" \
  -H "Authorization: Bearer {token}" \
  -H "Content-Type: application/json" \
  -d '{
    "preguntaOriginal": "¿Qué es un sujeto obligado?",
    "nuevaPregunta": "¿Qué es un sujeto obligado según la Ley 155-17?",
    "nuevaRespuesta": "Es toda persona física o jurídica que por su actividad económica está obligada a implementar medidas de prevención del lavado de activos y el financiamiento del terrorismo según lo establecido en la Ley 155-17."
  }'
```

### Eliminar FAQ
```bash
curl -X DELETE "https://localhost:7000/api/Faq?pregunta=¿Qué%20es%20un%20sujeto%20obligado?" \
  -H "Authorization: Bearer {token}"
```

---

## Códigos de Estado HTTP
- `200 OK`: Operación exitosa (GET, PUT, DELETE)
- `201 Created`: FAQ creada exitosamente (POST)
- `400 Bad Request`: Datos de entrada inválidos
- `404 Not Found`: FAQ no encontrada
- `409 Conflict`: FAQ duplicada
- `500 Internal Server Error`: Error del servidor

---

## Mejores Prácticas

1. **Antes de agregar una FAQ**: Busca si ya existe una pregunta similar
2. **Al actualizar**: Verifica que la `preguntaOriginal` sea exacta
3. **Al eliminar**: Asegúrate de tener el texto exacto de la pregunta
4. **Búsquedas**: Usa términos específicos para obtener resultados relevantes
5. **Mantenimiento**: Revisa periódicamente el archivo JSON para asegurar su integridad
